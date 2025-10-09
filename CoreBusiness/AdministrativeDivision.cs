using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class AdministrativeDivision
    {
        public int AdministrativeDivisionId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        [Required(ErrorMessage =" Country Structure is required")]
        public int CountryStructureId { get; set; }

    }
}
