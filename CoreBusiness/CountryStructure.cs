using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class CountryStructure
    {
        public int CountryStructureId { get; set; }
        public string Name { get; set; }
        public int? ParentCountryStructureId { get; set; }
        public int CountryId { get; set; }
    }
}
