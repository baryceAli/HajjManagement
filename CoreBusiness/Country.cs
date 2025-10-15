using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } // ISO 3166-1 alpha-2 code
        public string Continent { get; set; } // e.g., "Europe", "Asia", etc.
        public string Capital { get; set; } // Capital city of the country
        public string Currency { get; set; } // Currency used in the country
        public string Language { get; set; } // Primary language spoken in the country
        public bool IsRTL { get; set; }
        public string FlagUrl { get; set; } // URL to the country's flag image
        public string CountryPhoneCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        


    }
}
