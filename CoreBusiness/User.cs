using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class User:IdentityUser<int>
    {
        [Required(ErrorMessage ="الرجاء ادخال الاسم الأول")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "الرجاء ادخال الاسم الأخير")]
        public string LastName { get; set; } = string.Empty;
        
        //[Required(ErrorMessage = "الرجاء ادخال رقم الجواز")]
        public string? Passport { get; set; } = string.Empty;
        
        //[Required(ErrorMessage = "الرجاء ادخال مكان الاصدار")]
        public string? IssuePlace { get; set; }
        
        //[Required(ErrorMessage = "الرجاء ادخال تاريخ اصدار الجواز")]
        public DateTime? IssueDate { get; set; }
        
        //[Required(ErrorMessage = "الرجاء ادخال تاريخ انتهاء الجواز")]
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public string? Address { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "الرجاء اختيار الدولة")]
        public int CountryId { get; set; }
        
        //[Required(ErrorMessage = "الرجاء اختيار الوحدة الإدارية")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid administrative division.")]
        public int AdministrativeDivisionId { get; set; }    

        [Required(ErrorMessage = "الرجاء ادخال رقم الهاتف")]
        [Phone]
        public string PhoneNumber { get; set; }
        
        public string? PhoneOtp { get; set; }
        public DateTime? PhoneOtpExpiry { get; set; }
    }
    
}
