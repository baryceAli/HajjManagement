using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class AdministrativeDivision
    {
        public int AdministrativeDivisionId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CountryId { get; set; }

    }
}
