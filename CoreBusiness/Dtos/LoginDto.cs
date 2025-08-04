using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Dtos
{
    public class LoginDto
    {
        [Required]
        public string LoginCode { get; set; }
        [Required]
        public string Password { get; set; } 
    }
}
