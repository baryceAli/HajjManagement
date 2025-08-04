using Microsoft.AspNetCore.Identity;

namespace CoreBusiness
{
    public class User:IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
        public int CountryId { get; set; }
        public int AdministrativeDivisionTypeId { get; set; } // Added AdministrativeDivisionType
        public int AdministrativeDivisionId { get; set; }
        //public Country Country { get; set; }
        //public AdministrativeDivision AdministrativeDivision { get; set; }
        //public AdministrativeDivisionType? AdministrativeDivisionType { get; set; } // Updated to nullable
        //public ICollection<Guest>? Guests { get; set; }
    }

}
