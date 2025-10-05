using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services.Custom
{
    public interface IAdministrativeDivisionCustomService
    {
        public Task<IEnumerable<CoreBusiness.AdministrativeDivision>> GetChildrenAsync(int administrativeDivisionId, List<AdministrativeDivision> administrativeDivisionList);
        public Task<IEnumerable<CoreBusiness.AdministrativeDivision>> GetParentAsync(int administrativeDivisionId, List<AdministrativeDivision> administrativeDivisionList);
    }
}
