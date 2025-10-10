using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Dtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Passport { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int CountryId { get; set; }
        public int AdministrativeDivisionId { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneOtp { get; set; }
        public DateTime? PhoneOtpExpiry { get; set; }
        public bool isProfileCompleted { get; set; } = false;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
