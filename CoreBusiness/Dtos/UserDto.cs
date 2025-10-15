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
        public bool isProfileCompleted { get; set; } = false;

        public static User GetUser(UserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserName = userDto.Email,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Passport = userDto.Passport,
                IssuePlace = userDto.IssuePlace,
                IssueDate = userDto.IssueDate,
                ExpiryDate = userDto.ExpiryDate,
                DateOfBirth = userDto.DateOfBirth,
                Address = userDto.Address,
                ProfilePictureUrl = userDto.ProfilePictureUrl,
                isProfileCompleted = userDto.isProfileCompleted,
                CountryId = userDto.CountryId,
                AdministrativeDivisionId = userDto.AdministrativeDivisionId,

            };
        }
        public static UserDto GetUserDto(User user)
        {
            return new UserDto { 
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Passport = user.Passport,
                    IssuePlace = user.IssuePlace,
                    IssueDate = user.IssueDate,
                    ExpiryDate = user.ExpiryDate,
                    DateOfBirth = user.DateOfBirth,
                    Address = user.Address,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    CountryId = user.CountryId,
                    AdministrativeDivisionId = user.AdministrativeDivisionId,
                    isProfileCompleted = user.isProfileCompleted,
            };
    }
    }
}
