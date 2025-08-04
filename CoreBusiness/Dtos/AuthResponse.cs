using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Dtos
{
    public class AuthResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string UserId { get; set; }
        public List<string>? Roles { get; set; }
    }
}
