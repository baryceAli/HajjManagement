using CoreBusiness;
using CoreBusiness.Utils;
using Microsoft.AspNetCore.Components.Authorization;
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
        public static int CurrentCountryId { get; set; }

        public static bool IsAdmin(AuthenticationState AuthState)
        {
            if(AuthState.User.IsInRole(RoleNames.MainSuperAdmin) ||
                AuthState.User.IsInRole(RoleNames.MainAdmin) ||
                AuthState.User.IsInRole(RoleNames.CompanySuperAdmin) ||
                AuthState.User.IsInRole(RoleNames.CompanyAdmin) ||
                AuthState.User.IsInRole(RoleNames.CountrySuperAdmin) ||
                AuthState.User.IsInRole(RoleNames.CountryAdmin)
                ) 
                { return true; }
            return false;
        }
    }
}
