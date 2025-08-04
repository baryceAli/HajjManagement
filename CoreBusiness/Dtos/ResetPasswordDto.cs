using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Dtos
{
    public class ResetPasswordDto
    {
        public string userName { get; set; }
        public string NewPassword { get; set; }
    }
}
