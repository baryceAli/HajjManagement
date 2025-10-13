using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Dtos
{
    public class ApiResponseMessage
    {
        public string FriendlyMessage { get; set; } = string.Empty;
        public string SytemMessage { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;
        public string? ErorrCode { get; set; }
        public string? DetailedError { get; set; }
    }
}
