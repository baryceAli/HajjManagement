using CoreBusiness;
using HajjManagement.Shared.Pages.AdministrativeDivision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services.Custom
{
    public class AdministrativeDivisionCustomService : IAdministrativeDivisionCustomService
    {
        private readonly IGenericAPIService<AdministrativeDivision> countryStructureService;

        public AdministrativeDivisionCustomService(IGenericAPIService<AdministrativeDivision> countryStructureService)
        {
            this.countryStructureService = countryStructureService;
        }
        public async Task<IEnumerable<AdministrativeDivision>> GetParentAsync(int administrativeDivisionId, List<AdministrativeDivision> administrativeDivisionList)
        {
            try
            {
                var result = new List<AdministrativeDivision>();

                async Task GetParentRecursive(int childId)
                {
                    var parent = administrativeDivisionList
                        .FirstOrDefault(c => c.AdministrativeDivisionId ==
                            administrativeDivisionList
                                .Where(x => x.AdministrativeDivisionId == childId)
                                .Select(x => x.ParentId)
                                .FirstOrDefault());

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

        public async Task<IEnumerable<AdministrativeDivision>> GetChildrenAsync(int administrativeDivisionId, List<AdministrativeDivision> administrativeDivisionList)
        {
            try
            {
                var result = new List<AdministrativeDivision>();

                async Task GetChildrenRecursive(int parentId)
                {
                    var children = administrativeDivisionList
                        .Where(c => c.ParentId == parentId)
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
