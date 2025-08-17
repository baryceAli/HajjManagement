using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Utilities
{
    public static class GlobalData
    {
        public static User? User { get; set; } // This will hold the current user data, if logged in
        public static string? Token { get; set; }
    }
}
