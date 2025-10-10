using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "الرجاء ادخال البريد الإلكتروني")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "الرجاء إدخال رقم الهاتف")]
        //[Phone(ErrorMessage = "رقم الهاتف غير صالح")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "الرجاء ادخال الاسم الأول")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "الرجاء ادخال الاسم الأخير")]
        public string LastName { get; set; } = string.Empty;

        public string? Passport { get; set; }
        public string? IssuePlace { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "الرجاء اختيار الدولة")]
        public int CountryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "الرجاء ادخال الوحدة الإدارية")]
        public int AdministrativeDivisionId { get; set; }
    }
}
