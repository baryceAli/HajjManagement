using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services.Custom
{
    public interface ICountryStructureCustomService
    {
        public Task<IEnumerable<CoreBusiness.CountryStructure>> GetChildrenAsync(int countryStructureId,List<CountryStructure> countryStructureList);
        public Task<IEnumerable<CoreBusiness.CountryStructure>> GetParentAsync(int countryStructureId, List<CountryStructure> countryStructureList);
    }
}
