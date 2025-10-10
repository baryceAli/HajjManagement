using CoreBusiness;
using CoreBusiness.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services.Custom
{
    public class UserCustomService : IUserCustomService
    {
        public User GetUser(UserDto userDto)
        {
            return new User()
            {
                PhoneNumber = userDto.PhoneNumber,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Passport = userDto.Passport,
                IssuePlace = userDto.IssuePlace,
                IssueDate = userDto.IssueDate,
                ExpiryDate = userDto.ExpiryDate,
                DateOfBirth = userDto.DateOfBirth,
                Address = userDto.Address,
                ProfilePictureUrl = userDto.ProfilePictureUrl,
                CountryId = userDto.CountryId,
                AdministrativeDivisionId = userDto.AdministrativeDivisionId,
            };
        }

        public UserDto GetUserDto(User user)
        {
            return new UserDto()
            {
                PhoneNumber = user.PhoneNumber,
                Email=user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Passport = user.Passport,
                IssuePlace= user.IssuePlace,
                IssueDate= user.IssueDate,
                ExpiryDate= user.ExpiryDate,
                DateOfBirth= user.DateOfBirth,
                Address= user.Address,
                ProfilePictureUrl = user.ProfilePictureUrl,
                CountryId= user.CountryId,
                AdministrativeDivisionId= user.AdministrativeDivisionId,
            };
        }
    }
}
