using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class AdministrativeDivisionType
    {
        public int AdministrativeDivisionTypeId { get; set; }
        public int CountryId { get; set; }
        //public Country Country { get; set; }
        public int Level { get; set; } // 1 = الأعلى، 2 = تحته، وهكذا
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //public ICollection<AdministrativeDivision>? AdministrativeDivisions { get; set; }


    }
}
