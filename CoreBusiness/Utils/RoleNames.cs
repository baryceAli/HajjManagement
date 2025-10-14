using CoreBusiness;

namespace CoreBusiness.Utils
{
    public static class RoleNames
    {
        public const string MainSuperAdmin = "MainSuperAdmin";
        public const string MainAdmin = "MainAdmin";
        public const string MainDataEntry = "MainDataEntry";
        public const string CompanySuperAdmin = "CompanySuperAdmin";
        public const string CompanyAdmin = "CompanyAdmin";
        public const string CompanyDataEntry = "CompanyDataEntry";
        public const string CountrySuperAdmin = "SuperAdmin";
        public const string CountryAdmin = "Admin";
        public const string CountryDataEntry = "DataEntry";
        public const string CountrySupervisor = "Supervisor";
        public const string Guest = "Guest";

        public static List<string> GetRoles()
        {
            return new List<string>
            {
                RoleNames.MainSuperAdmin,
                RoleNames.MainAdmin,
                RoleNames.MainDataEntry,
                RoleNames.CompanySuperAdmin,
                RoleNames.CompanyAdmin,
                RoleNames.CompanyDataEntry,
                RoleNames.CountrySuperAdmin,
                RoleNames.CountryAdmin,
                RoleNames.CountryDataEntry,
                RoleNames.CountrySupervisor,
                RoleNames.Guest
            };
        }
        public static List<string> GetMainRoles()
        {
            return new List<string>
            {
                RoleNames.MainSuperAdmin,
                RoleNames.MainAdmin,
                RoleNames.MainDataEntry,
            };
        }
        public static List<string> GetCompanyRoles()
        {
            return new List<string>
            {
                RoleNames.CompanySuperAdmin,
                RoleNames.CompanyAdmin,
                RoleNames.CompanyDataEntry,
            };
        }
        public static List<string> GetCountryRoles()
        {
            return new List<string>
            {
                RoleNames.CountrySuperAdmin,
                RoleNames.CountryAdmin,
                RoleNames.CountryDataEntry,
                RoleNames.CountrySupervisor,
                RoleNames.Guest
            };
        }
    }
}
