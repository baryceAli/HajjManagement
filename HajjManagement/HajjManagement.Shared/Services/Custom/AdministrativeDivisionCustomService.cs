using CoreBusiness;
using HajjManagement.Shared.Pages.AdministrativeDivision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services.Custom
{
    public class AdministrativeDivisionCustomService : IAdministrativeDivisionCustomService
    {
        private readonly IGenericAPIService<AdministrativeDivision> administrativeDivisionService;

        public AdministrativeDivisionCustomService(IGenericAPIService<AdministrativeDivision> administrativeDivisionService)
        {
            this.administrativeDivisionService = administrativeDivisionService;
        }

        public async Task<IEnumerable<AdministrativeDivision>> GetParentAsync(
            int administrativeDivisionId,
            List<AdministrativeDivision> administrativeDivisionList)
        {
            try
            {
                var result = new List<AdministrativeDivision>();

                // Find the starting node and its country
                var root = administrativeDivisionList.FirstOrDefault(c => c.AdministrativeDivisionId == administrativeDivisionId);
                if (root == null)
                    return result;

                int rootCountryId = root.CountryId;

                async Task GetParentRecursive(int childId)
                {
                    var parentId = administrativeDivisionList
                        .Where(x => x.AdministrativeDivisionId == childId && x.CountryId == rootCountryId)
                        .Select(x => x.ParentId)
                        .FirstOrDefault();

                    if (parentId == null)
                        return;

                    var parent = administrativeDivisionList
                        .FirstOrDefault(c => c.AdministrativeDivisionId == parentId && c.CountryId == rootCountryId);

                    if (parent != null)
                    {
                        result.Add(parent);
                        await GetParentRecursive(parent.AdministrativeDivisionId); // go up to next parent
                    }
                }

                await GetParentRecursive(administrativeDivisionId);
                return result;
            }
            catch (Exception)
            {
                return new List<AdministrativeDivision>();
            }
        }

        public async Task<IEnumerable<AdministrativeDivision>> GetChildrenAsync(
            int administrativeDivisionId,
            List<AdministrativeDivision> administrativeDivisionList)
        {
            try
            {
                var result = new List<AdministrativeDivision>();

                // Get the country ID of the root node
                var root = administrativeDivisionList.FirstOrDefault(c => c.AdministrativeDivisionId == administrativeDivisionId);
                if (root == null)
                    return result;

                int rootCountryId = root.CountryId;

                async Task GetChildrenRecursive(int parentId)
                {
                    var children = administrativeDivisionList
                        .Where(c => c.ParentId == parentId && c.CountryId == rootCountryId)
                        .ToList();

                    foreach (var child in children)
                    {
                        result.Add(child);
                        await GetChildrenRecursive(child.AdministrativeDivisionId); // recurse deeper
                    }
                }

                await GetChildrenRecursive(administrativeDivisionId);
                return result;
            }
            catch (Exception)
            {
                return new List<AdministrativeDivision>();
            }
        }
    }
}
