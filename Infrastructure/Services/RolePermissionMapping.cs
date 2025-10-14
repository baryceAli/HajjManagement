using CoreBusiness.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public static class RolePermissionMapping
    {
        public static List<string> GetPermissionsForRole(string roleName)
        {
            var allPermissions = PermissionHelper.GetAllPermissions();

            return roleName switch
            {
                RoleNames.MainSuperAdmin => allPermissions, // full access

                RoleNames.MainAdmin => allPermissions
                    .Where(p => !p.StartsWith("Role.") && !p.StartsWith("Permission.")) // cannot manage Main roles
                    .ToList(),

                RoleNames.CountrySuperAdmin => allPermissions
                    .Where(p => !p.StartsWith("Role.") && !p.StartsWith("Permission.")) // full country data
                    .ToList(),

                RoleNames.CountryAdmin => allPermissions
                    .Where(p => !p.StartsWith("Role.") && !p.StartsWith("Permission.")) // cannot modify CountrySuperAdmin
                    .ToList(),

                RoleNames.CountrySupervisor => allPermissions
                    .Where(p => p.EndsWith(".View")) // only view
                    .ToList(),

                RoleNames.CompanySuperAdmin => allPermissions
                    .Where(p => !p.StartsWith("Role.") && !p.StartsWith("Permission.")) // full company data
                    .ToList(),

                RoleNames.CompanyAdmin => allPermissions
                    .Where(p => !p.StartsWith("Role.") && !p.StartsWith("Permission.")) // cannot modify CompanySuperAdmin
                    .ToList(),

                RoleNames.MainDataEntry or RoleNames.CompanyDataEntry or RoleNames.CountryDataEntry =>
                    allPermissions.Where(p => p.EndsWith(".Add") || p.EndsWith(".Edit")).ToList(),

                RoleNames.Guest => allPermissions.Where(p => p.EndsWith(".View")).ToList(),

                _ => new List<string>()
            };
        }
    }

}
