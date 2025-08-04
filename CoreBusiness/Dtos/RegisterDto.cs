using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string LoginCode { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int CountryId { get; set; }
        public int AdministrativeDivisionTypeId { get; set; }
        public int AdministrativeDivisionId { get; set; }
    }
}
