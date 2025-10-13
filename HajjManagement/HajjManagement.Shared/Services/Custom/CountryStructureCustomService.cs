using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services.Custom
{
    public class CountryStructureCustomService : ICountryStructureCustomService
    {
        private readonly IGenericAPIService<CountryStructure> countryStructureService;

        public CountryStructureCustomService(IGenericAPIService<CountryStructure> countryStructureService)
        {
            this.countryStructureService = countryStructureService;
        }

        public async Task<IEnumerable<CountryStructure>> GetParentAsync(
            int countryStructureId,
            List<CountryStructure> countryStructureList)
        {
            try
            {
                var result = new List<CountryStructure>();

                // Find the starting structure and its country
                var root = countryStructureList.FirstOrDefault(c => c.CountryStructureId == countryStructureId);
                if (root == null)
                    return result;

                int rootCountryId = root.CountryId;

                async Task GetParentRecursive(int childId)
                {
                    var parentId = countryStructureList
                        .Where(x => x.CountryStructureId == childId && x.CountryId == rootCountryId)
                        .Select(x => x.ParentCountryStructureId)
                        .FirstOrDefault();

                    if (parentId == null)
                        return;

                    var parent = countryStructureList
                        .FirstOrDefault(c => c.CountryStructureId == parentId && c.CountryId == rootCountryId);

                    if (parent != null)
                    {
                        result.Add(parent);
                        await GetParentRecursive(parent.CountryStructureId); // go up to next parent
                    }
                }

                await GetParentRecursive(countryStructureId);
                return result;
            }
            catch (Exception)
            {
                return new List<CountryStructure>();
            }
        }

        public async Task<IEnumerable<CountryStructure>> GetChildrenAsync(
            int countryStructureId,
            List<CountryStructure> countryStructureList)
        {
            try
            {
                var result = new List<CountryStructure>();

                // Get the country ID of the root node
                var root = countryStructureList.FirstOrDefault(c => c.CountryStructureId == countryStructureId);
                if (root == null)
                    return result;

                int rootCountryId = root.CountryId;

                async Task GetChildrenRecursive(int parentId)
                {
                    var children = countryStructureList
                        .Where(c => c.ParentCountryStructureId == parentId && c.CountryId == rootCountryId)
                        .ToList();

                    foreach (var child in children)
                    {
                        result.Add(child);
                        await GetChildrenRecursive(child.CountryStructureId); // recurse deeper
                    }
                }

                await GetChildrenRecursive(countryStructureId);
                return result;
            }
            catch (Exception)
            {
                return new List<CountryStructure>();
            }
        }
    }
}
