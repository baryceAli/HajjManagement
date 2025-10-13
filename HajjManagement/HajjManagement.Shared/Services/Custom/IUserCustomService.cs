using CoreBusiness;
using CoreBusiness.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services.Custom
{
    public interface IUserCustomService
    {
        public User GetUser(UserDto userDto);
        public UserDto GetUserDto(User user);
    }
}
