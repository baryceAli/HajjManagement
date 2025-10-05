using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
        public async Task<IEnumerable<CountryStructure>> GetParentAsync(int countryStructureId, List<CountryStructure> countryStructureList)
        {
            try
            {
                var result = new List<CountryStructure>();

                async Task GetParentRecursive(int childId)
                {
                    var parent = countryStructureList
                        .FirstOrDefault(c => c.CountryStructureId ==
                            countryStructureList
                                .Where(x => x.CountryStructureId == childId)
                                .Select(x => x.ParentCountryStructureId)
                                .FirstOrDefault());

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

        public async Task<IEnumerable<CountryStructure>> GetChildrenAsync(int countryStructureId, List<CountryStructure> countryStructureList)
        {
            try
            {
                var result = new List<CountryStructure>();

                async Task GetChildrenRecursive(int parentId)
                {
                    var children = countryStructureList
                        .Where(c => c.ParentCountryStructureId == parentId)
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
