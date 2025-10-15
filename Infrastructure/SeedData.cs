using CoreBusiness;
using CoreBusiness.Utils;
using Infrastructure.Plugin.Datastore.SQLServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class SeedData
    {

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }

        
        public static async Task SeedMainSuperAdminAsync(IServiceProvider serviceProvider)
        {
            string superAdminUserName="MainSuperAdmin";
            string superAdminPassword="Admin@1234";

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<CoreBusiness.Role>>();

            // 1️⃣ Ensure the MainSuperAdmin role exists
            var superAdminRole = await roleManager.FindByNameAsync(RoleNames.MainSuperAdmin);
            if (superAdminRole == null)
            {
                superAdminRole = new CoreBusiness.Role
                {
                    Name = RoleNames.MainSuperAdmin,
                    NormalizedName = RoleNames.MainSuperAdmin.ToUpper(),
                    Description = "Full access to all system functionality"
                }; 
                await roleManager.CreateAsync(superAdminRole);
            }

            // 2️⃣ Assign all permissions to MainSuperAdmin role
            var allPermissions = PermissionHelper.GetAllPermissions();
            var existingClaims = await roleManager.GetClaimsAsync(superAdminRole);

            foreach (var permission in allPermissions)
            {
                if (!existingClaims.Any(c => c.Type == "Permission" && c.Value == permission))
                {
                    await roleManager.AddClaimAsync(superAdminRole, new Claim("Permission", permission));
                }
            }

            // 3️⃣ Create MainSuperAdmin user if not exists
            var user = await userManager.FindByNameAsync(superAdminUserName);
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Bashir",
                    LastName = "Mohamed Ali",
                    UserName = superAdminUserName,
                    Passport = string.Empty,
                    IssuePlace = string.Empty,
                    Email = "baryce@gmail.com",
                    Address = "",
                    AdministrativeDivisionId = 1,
                    PhoneNumber = "0574575491",
                    EmailConfirmed = true // optional
                };

                var result = await userManager.CreateAsync(user, superAdminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create super admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }

                // 4️⃣ Assign the MainSuperAdmin role to the user
                await userManager.AddToRoleAsync(user, RoleNames.MainSuperAdmin);

                // 5️⃣ Optionally, add all permissions as claims to user (redundant if role claims are used in JWT)
                foreach (var permission in allPermissions)
                {
                    await userManager.AddClaimAsync(user, new Claim("Permission", permission));
                }

            }
        }
        
        public static void SeedCountries(ModelBuilder modelBuilder)
        {
            // Seed Countries (ISO 3166-1 alpha-2, exhaustive, batch 1)
            // Seed Countries (ISO 3166-1 alpha-2, exhaustive, batch 1)
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "Afghanistan", Code = "AF", Continent = "Asia", Capital = "Kabul", Currency = "AFN", Language = "Pashto/Dari", IsRTL = false, CountryPhoneCode = "+93", FlagUrl = "https://flagcdn.com/af.svg" },
                new Country { CountryId = 2, Name = "Albania", Code = "AL", Continent = "Europe", Capital = "Tirana", Currency = "ALL", Language = "Albanian", IsRTL = false, CountryPhoneCode = "+355", FlagUrl = "https://flagcdn.com/al.svg" },
                new Country { CountryId = 3, Name = "Algeria", Code = "DZ", Continent = "Africa", Capital = "Algiers", Currency = "DZD", Language = "Arabic/Berber", IsRTL = true, CountryPhoneCode = "+213", FlagUrl = "https://flagcdn.com/dz.svg" },
                new Country { CountryId = 4, Name = "Andorra", Code = "AD", Continent = "Europe", Capital = "Andorra la Vella", Currency = "EUR", Language = "Catalan", IsRTL = false, CountryPhoneCode = "+376", FlagUrl = "https://flagcdn.com/ad.svg" },
                new Country { CountryId = 5, Name = "Angola", Code = "AO", Continent = "Africa", Capital = "Luanda", Currency = "AOA", Language = "Portuguese", IsRTL = false, CountryPhoneCode = "+244", FlagUrl = "https://flagcdn.com/ao.svg" },
                new Country { CountryId = 6, Name = "Antigua and Barbuda", Code = "AG", Continent = "North America", Capital = "St. John's", Currency = "XCD", Language = "English", IsRTL = false, CountryPhoneCode = "+1-268", FlagUrl = "https://flagcdn.com/ag.svg" },
                new Country { CountryId = 7, Name = "Argentina", Code = "AR", Continent = "South America", Capital = "Buenos Aires", Currency = "ARS", Language = "Spanish", IsRTL = false, CountryPhoneCode = "+54", FlagUrl = "https://flagcdn.com/ar.svg" },
                new Country { CountryId = 8, Name = "Armenia", Code = "AM", Continent = "Asia", Capital = "Yerevan", Currency = "AMD", Language = "Armenian", IsRTL = false, CountryPhoneCode = "+374", FlagUrl = "https://flagcdn.com/am.svg" },
                new Country { CountryId = 9, Name = "Australia", Code = "AU", Continent = "Oceania", Capital = "Canberra", Currency = "AUD", Language = "English", IsRTL = false, CountryPhoneCode = "+61", FlagUrl = "https://flagcdn.com/au.svg" },
                new Country { CountryId = 10, Name = "Austria", Code = "AT", Continent = "Europe", Capital = "Vienna", Currency = "EUR", Language = "German", IsRTL = false, CountryPhoneCode = "+43", FlagUrl = "https://flagcdn.com/at.svg" },
                new Country { CountryId = 11, Name = "Azerbaijan", Code = "AZ", Continent = "Asia", Capital = "Baku", Currency = "AZN", Language = "Azerbaijani", IsRTL = false, CountryPhoneCode = "+994", FlagUrl = "https://flagcdn.com/az.svg" },
                new Country { CountryId = 12, Name = "Bahamas", Code = "BS", Continent = "North America", Capital = "Nassau", Currency = "BSD", Language = "English", IsRTL = false, CountryPhoneCode = "+1-242", FlagUrl = "https://flagcdn.com/bs.svg" },
                new Country { CountryId = 13, Name = "Bahrain", Code = "BH", Continent = "Asia", Capital = "Manama", Currency = "BHD", Language = "Arabic", IsRTL = true, CountryPhoneCode = "+973", FlagUrl = "https://flagcdn.com/bh.svg" },
                new Country { CountryId = 14, Name = "Bangladesh", Code = "BD", Continent = "Asia", Capital = "Dhaka", Currency = "BDT", Language = "Bengali", IsRTL = false, CountryPhoneCode = "+880", FlagUrl = "https://flagcdn.com/bd.svg" },
                new Country { CountryId = 15, Name = "Barbados", Code = "BB", Continent = "North America", Capital = "Bridgetown", Currency = "BBD", Language = "English", IsRTL = false, CountryPhoneCode = "+1-246", FlagUrl = "https://flagcdn.com/bb.svg" },
                new Country { CountryId = 16, Name = "Belarus", Code = "BY", Continent = "Europe", Capital = "Minsk", Currency = "BYN", Language = "Belarusian/Russian", IsRTL = false, CountryPhoneCode = "+375", FlagUrl = "https://flagcdn.com/by.svg" },
                new Country { CountryId = 17, Name = "Belgium", Code = "BE", Continent = "Europe", Capital = "Brussels", Currency = "EUR", Language = "Dutch/French/German", IsRTL = false, CountryPhoneCode = "+32", FlagUrl = "https://flagcdn.com/be.svg" },
                new Country { CountryId = 18, Name = "Belize", Code = "BZ", Continent = "North America", Capital = "Belmopan", Currency = "BZD", Language = "English", IsRTL = false, CountryPhoneCode = "+501", FlagUrl = "https://flagcdn.com/bz.svg" },
                new Country { CountryId = 19, Name = "Benin", Code = "BJ", Continent = "Africa", Capital = "Porto-Novo", Currency = "XOF", Language = "French", IsRTL = false, CountryPhoneCode = "+229", FlagUrl = "https://flagcdn.com/bj.svg" },
                new Country { CountryId = 20, Name = "Bhutan", Code = "BT", Continent = "Asia", Capital = "Thimphu", Currency = "BTN", Language = "Dzongkha", IsRTL = false, CountryPhoneCode = "+975", FlagUrl = "https://flagcdn.com/bt.svg" },
                new Country { CountryId = 21, Name = "Bolivia", Code = "BO", Continent = "South America", Capital = "Sucre", Currency = "BOB", Language = "Spanish/Aymara/Quechua", IsRTL = false, CountryPhoneCode = "+591", FlagUrl = "https://flagcdn.com/bo.svg" },
                new Country { CountryId = 22, Name = "Bosnia and Herzegovina", Code = "BA", Continent = "Europe", Capital = "Sarajevo", Currency = "BAM", Language = "Bosnian/Croatian/Serbian", IsRTL = false, CountryPhoneCode = "+387", FlagUrl = "https://flagcdn.com/ba.svg" },
                new Country { CountryId = 23, Name = "Botswana", Code = "BW", Continent = "Africa", Capital = "Gaborone", Currency = "BWP", Language = "English/Tswana", IsRTL = false, CountryPhoneCode = "+267", FlagUrl = "https://flagcdn.com/bw.svg" },
                new Country { CountryId = 24, Name = "Brazil", Code = "BR", Continent = "South America", Capital = "Brasília", Currency = "BRL", Language = "Portuguese", IsRTL = false, CountryPhoneCode = "+55", FlagUrl = "https://flagcdn.com/br.svg" },
                new Country { CountryId = 25, Name = "Brunei", Code = "BN", Continent = "Asia", Capital = "Bandar Seri Begawan", Currency = "BND", Language = "Malay", IsRTL = false, CountryPhoneCode = "+673", FlagUrl = "https://flagcdn.com/bn.svg" },
                new Country { CountryId = 26, Name = "Bulgaria", Code = "BG", Continent = "Europe", Capital = "Sofia", Currency = "BGN", Language = "Bulgarian", IsRTL = false, CountryPhoneCode = "+359", FlagUrl = "https://flagcdn.com/bg.svg" },
                new Country { CountryId = 27, Name = "Burkina Faso", Code = "BF", Continent = "Africa", Capital = "Ouagadougou", Currency = "XOF", Language = "French", IsRTL = false, CountryPhoneCode = "+226", FlagUrl = "https://flagcdn.com/bf.svg" },
                new Country { CountryId = 28, Name = "Burundi", Code = "BI", Continent = "Africa", Capital = "Gitega", Currency = "BIF", Language = "Kirundi/French/English", IsRTL = false, CountryPhoneCode = "+257", FlagUrl = "https://flagcdn.com/bi.svg" },
                new Country { CountryId = 29, Name = "Cabo Verde", Code = "CV", Continent = "Africa", Capital = "Praia", Currency = "CVE", Language = "Portuguese", IsRTL = false, CountryPhoneCode = "+238", FlagUrl = "https://flagcdn.com/cv.svg" },
                new Country { CountryId = 30, Name = "Cambodia", Code = "KH", Continent = "Asia", Capital = "Phnom Penh", Currency = "KHR", Language = "Khmer", IsRTL = false, CountryPhoneCode = "+855", FlagUrl = "https://flagcdn.com/kh.svg" },
                new Country { CountryId = 31, Name = "Cameroon", Code = "CM", Continent = "Africa", Capital = "Yaoundé", Currency = "XAF", Language = "French/English", IsRTL = false, CountryPhoneCode = "+237", FlagUrl = "https://flagcdn.com/cm.svg" },
                new Country { CountryId = 32, Name = "Canada", Code = "CA", Continent = "North America", Capital = "Ottawa", Currency = "CAD", Language = "English/French", IsRTL = false, CountryPhoneCode = "+1", FlagUrl = "https://flagcdn.com/ca.svg" },
                new Country { CountryId = 33, Name = "Central African Republic", Code = "CF", Continent = "Africa", Capital = "Bangui", Currency = "XAF", Language = "French/Sango", IsRTL = false, CountryPhoneCode = "+236", FlagUrl = "https://flagcdn.com/cf.svg" },
                new Country { CountryId = 34, Name = "Chad", Code = "TD", Continent = "Africa", Capital = "N'Djamena", Currency = "XAF", Language = "French/Arabic", IsRTL = true, CountryPhoneCode = "+235", FlagUrl = "https://flagcdn.com/td.svg" },
                new Country { CountryId = 35, Name = "Chile", Code = "CL", Continent = "South America", Capital = "Santiago", Currency = "CLP", Language = "Spanish", IsRTL = false, CountryPhoneCode = "+56", FlagUrl = "https://flagcdn.com/cl.svg" },
                new Country { CountryId = 36, Name = "China", Code = "CN", Continent = "Asia", Capital = "Beijing", Currency = "CNY", Language = "Chinese", IsRTL = false, CountryPhoneCode = "+86", FlagUrl = "https://flagcdn.com/cn.svg" },
                new Country { CountryId = 37, Name = "Colombia", Code = "CO", Continent = "South America", Capital = "Bogotá", Currency = "COP", Language = "Spanish", IsRTL = false, CountryPhoneCode = "+57", FlagUrl = "https://flagcdn.com/co.svg" },
                new Country { CountryId = 38, Name = "Comoros", Code = "KM", Continent = "Africa", Capital = "Moroni", Currency = "KMF", Language = "Comorian/Arabic/French", IsRTL = true, CountryPhoneCode = "+269", FlagUrl = "https://flagcdn.com/km.svg" },
                new Country { CountryId = 39, Name = "Congo (Congo-Brazzaville)", Code = "CG", Continent = "Africa", Capital = "Brazzaville", Currency = "XAF", Language = "French/Lingala", IsRTL = false, CountryPhoneCode = "+242", FlagUrl = "https://flagcdn.com/cg.svg" },
                new Country { CountryId = 40, Name = "Congo (Congo-Kinshasa)", Code = "CD", Continent = "Africa", Capital = "Kinshasa", Currency = "CDF", Language = "French/Lingala/Kikongo/Swahili/Tshiluba", IsRTL = false, CountryPhoneCode = "+243", FlagUrl = "https://flagcdn.com/cd.svg" },
                new Country { CountryId = 41, Name = "Costa Rica", Code = "CR", Continent = "North America", Capital = "San José", Currency = "CRC", Language = "Spanish", IsRTL = false, CountryPhoneCode = "+506", FlagUrl = "https://flagcdn.com/cr.svg" },
                new Country { CountryId = 42, Name = "Côte d'Ivoire", Code = "CI", Continent = "Africa", Capital = "Yamoussoukro", Currency = "XOF", Language = "French", IsRTL = false, CountryPhoneCode = "+225", FlagUrl = "https://flagcdn.com/ci.svg" },
                new Country { CountryId = 43, Name = "Croatia", Code = "HR", Continent = "Europe", Capital = "Zagreb", Currency = "EUR", Language = "Croatian", IsRTL = false, CountryPhoneCode = "+385", FlagUrl = "https://flagcdn.com/hr.svg" },
                new Country { CountryId = 44, Name = "Cuba", Code = "CU", Continent = "North America", Capital = "Havana", Currency = "CUP", Language = "Spanish", IsRTL = false, CountryPhoneCode = "+53", FlagUrl = "https://flagcdn.com/cu.svg" },
                new Country { CountryId = 45, Name = "Cyprus", Code = "CY", Continent = "Europe", Capital = "Nicosia", Currency = "EUR", Language = "Greek/Turkish", IsRTL = true, CountryPhoneCode = "+357", FlagUrl = "https://flagcdn.com/cy.svg" },
                new Country { CountryId = 46, Name = "Czechia", Code = "CZ", Continent = "Europe", Capital = "Prague", Currency = "CZK", Language = "Czech", IsRTL = false, CountryPhoneCode = "+420", FlagUrl = "https://flagcdn.com/cz.svg" },
                new Country { CountryId = 47, Name = "Denmark", Code = "DK", Continent = "Europe", Capital = "Copenhagen", Currency = "DKK", Language = "Danish", IsRTL = false, CountryPhoneCode = "+45", FlagUrl = "https://flagcdn.com/dk.svg" },
                new Country { CountryId = 48, Name = "Djibouti", Code = "DJ", Continent = "Africa", Capital = "Djibouti", Currency = "DJF", Language = "French/Arabic", IsRTL = true, CountryPhoneCode = "+253", FlagUrl = "https://flagcdn.com/dj.svg" },
                new Country { CountryId = 49, Name = "Dominica", Code = "DM", Continent = "North America", Capital = "Roseau", Currency = "XCD", Language = "English", IsRTL = false, CountryPhoneCode = "+1-767", FlagUrl = "https://flagcdn.com/dm.svg" },
                new Country { CountryId = 50, Name = "Dominican Republic", Code = "DO", Continent = "North America", Capital = "Santo Domingo", Currency = "DOP", Language = "Spanish", IsRTL = false, CountryPhoneCode = "+1-809", FlagUrl = "https://flagcdn.com/do.svg" }
            );

            modelBuilder.Entity<Country>().HasData(
    new Country { CountryId = 51, Name = "Ecuador", Code = "EC", Continent = "South America", Capital = "Quito", Currency = "USD", Language = "Spanish", FlagUrl = "https://flagcdn.com/ec.svg", IsRTL = false, CountryPhoneCode = "+593" },
    new Country { CountryId = 52, Name = "Egypt", Code = "EG", Continent = "Africa", Capital = "Cairo", Currency = "EGP", Language = "Arabic", FlagUrl = "https://flagcdn.com/eg.svg", IsRTL = true, CountryPhoneCode = "+20" },
    new Country { CountryId = 53, Name = "El Salvador", Code = "SV", Continent = "North America", Capital = "San Salvador", Currency = "USD", Language = "Spanish", FlagUrl = "https://flagcdn.com/sv.svg", IsRTL = false, CountryPhoneCode = "+503" },
    new Country { CountryId = 54, Name = "Equatorial Guinea", Code = "GQ", Continent = "Africa", Capital = "Malabo", Currency = "XAF", Language = "Spanish/French/Portuguese", FlagUrl = "https://flagcdn.com/gq.svg", IsRTL = false, CountryPhoneCode = "+240" },
    new Country { CountryId = 55, Name = "Eritrea", Code = "ER", Continent = "Africa", Capital = "Asmara", Currency = "ERN", Language = "Tigrinya/Arabic/English", FlagUrl = "https://flagcdn.com/er.svg", IsRTL = true, CountryPhoneCode = "+291" },
    new Country { CountryId = 56, Name = "Estonia", Code = "EE", Continent = "Europe", Capital = "Tallinn", Currency = "EUR", Language = "Estonian", FlagUrl = "https://flagcdn.com/ee.svg", IsRTL = false, CountryPhoneCode = "+372" },
    new Country { CountryId = 57, Name = "Eswatini", Code = "SZ", Continent = "Africa", Capital = "Mbabane", Currency = "SZL", Language = "Swazi/English", FlagUrl = "https://flagcdn.com/sz.svg", IsRTL = false, CountryPhoneCode = "+268" },
    new Country { CountryId = 58, Name = "Ethiopia", Code = "ET", Continent = "Africa", Capital = "Addis Ababa", Currency = "ETB", Language = "Amharic", FlagUrl = "https://flagcdn.com/et.svg", IsRTL = false, CountryPhoneCode = "+251" },
    new Country { CountryId = 59, Name = "Fiji", Code = "FJ", Continent = "Oceania", Capital = "Suva", Currency = "FJD", Language = "English/Fijian/Hindi", FlagUrl = "https://flagcdn.com/fj.svg", IsRTL = false, CountryPhoneCode = "+679" },
    new Country { CountryId = 60, Name = "Finland", Code = "FI", Continent = "Europe", Capital = "Helsinki", Currency = "EUR", Language = "Finnish/Swedish", FlagUrl = "https://flagcdn.com/fi.svg", IsRTL = false, CountryPhoneCode = "+358" },
    new Country { CountryId = 61, Name = "France", Code = "FR", Continent = "Europe", Capital = "Paris", Currency = "EUR", Language = "French", FlagUrl = "https://flagcdn.com/fr.svg", IsRTL = false, CountryPhoneCode = "+33" },
    new Country { CountryId = 62, Name = "Gabon", Code = "GA", Continent = "Africa", Capital = "Libreville", Currency = "XAF", Language = "French", FlagUrl = "https://flagcdn.com/ga.svg", IsRTL = false, CountryPhoneCode = "+241" },
    new Country { CountryId = 63, Name = "Gambia", Code = "GM", Continent = "Africa", Capital = "Banjul", Currency = "GMD", Language = "English", FlagUrl = "https://flagcdn.com/gm.svg", IsRTL = false, CountryPhoneCode = "+220" },
    new Country { CountryId = 64, Name = "Georgia", Code = "GE", Continent = "Asia", Capital = "Tbilisi", Currency = "GEL", Language = "Georgian", FlagUrl = "https://flagcdn.com/ge.svg", IsRTL = false, CountryPhoneCode = "+995" },
    new Country { CountryId = 65, Name = "Germany", Code = "DE", Continent = "Europe", Capital = "Berlin", Currency = "EUR", Language = "German", FlagUrl = "https://flagcdn.com/de.svg", IsRTL = false, CountryPhoneCode = "+49" },
    new Country { CountryId = 66, Name = "Ghana", Code = "GH", Continent = "Africa", Capital = "Accra", Currency = "GHS", Language = "English", FlagUrl = "https://flagcdn.com/gh.svg", IsRTL = false, CountryPhoneCode = "+233" },
    new Country { CountryId = 67, Name = "Greece", Code = "GR", Continent = "Europe", Capital = "Athens", Currency = "EUR", Language = "Greek", FlagUrl = "https://flagcdn.com/gr.svg", IsRTL = false, CountryPhoneCode = "+30" },
    new Country { CountryId = 68, Name = "Grenada", Code = "GD", Continent = "North America", Capital = "St. George's", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/gd.svg", IsRTL = false, CountryPhoneCode = "+1-473" },
    new Country { CountryId = 69, Name = "Guatemala", Code = "GT", Continent = "North America", Capital = "Guatemala City", Currency = "GTQ", Language = "Spanish", FlagUrl = "https://flagcdn.com/gt.svg", IsRTL = false, CountryPhoneCode = "+502" },
    new Country { CountryId = 70, Name = "Guinea", Code = "GN", Continent = "Africa", Capital = "Conakry", Currency = "GNF", Language = "French", FlagUrl = "https://flagcdn.com/gn.svg", IsRTL = false, CountryPhoneCode = "+224" },
    new Country { CountryId = 71, Name = "Guinea-Bissau", Code = "GW", Continent = "Africa", Capital = "Bissau", Currency = "XOF", Language = "Portuguese", FlagUrl = "https://flagcdn.com/gw.svg", IsRTL = false, CountryPhoneCode = "+245" },
    new Country { CountryId = 72, Name = "Guyana", Code = "GY", Continent = "South America", Capital = "Georgetown", Currency = "GYD", Language = "English", FlagUrl = "https://flagcdn.com/gy.svg", IsRTL = false, CountryPhoneCode = "+592" },
    new Country { CountryId = 73, Name = "Haiti", Code = "HT", Continent = "North America", Capital = "Port-au-Prince", Currency = "HTG", Language = "French/Haitian Creole", FlagUrl = "https://flagcdn.com/ht.svg", IsRTL = false, CountryPhoneCode = "+509" },
    new Country { CountryId = 74, Name = "Honduras", Code = "HN", Continent = "North America", Capital = "Tegucigalpa", Currency = "HNL", Language = "Spanish", FlagUrl = "https://flagcdn.com/hn.svg", IsRTL = false, CountryPhoneCode = "+504" },
    new Country { CountryId = 75, Name = "Hungary", Code = "HU", Continent = "Europe", Capital = "Budapest", Currency = "HUF", Language = "Hungarian", FlagUrl = "https://flagcdn.com/hu.svg", IsRTL = false, CountryPhoneCode = "+36" },
    new Country { CountryId = 76, Name = "Iceland", Code = "IS", Continent = "Europe", Capital = "Reykjavik", Currency = "ISK", Language = "Icelandic", FlagUrl = "https://flagcdn.com/is.svg", IsRTL = false, CountryPhoneCode = "+354" },
    new Country { CountryId = 77, Name = "India", Code = "IN", Continent = "Asia", Capital = "New Delhi", Currency = "INR", Language = "Hindi/English", FlagUrl = "https://flagcdn.com/in.svg", IsRTL = false, CountryPhoneCode = "+91" },
    new Country { CountryId = 78, Name = "Indonesia", Code = "ID", Continent = "Asia", Capital = "Jakarta", Currency = "IDR", Language = "Indonesian", FlagUrl = "https://flagcdn.com/id.svg", IsRTL = false, CountryPhoneCode = "+62" },
    new Country { CountryId = 79, Name = "Iran", Code = "IR", Continent = "Asia", Capital = "Tehran", Currency = "IRR", Language = "Persian", FlagUrl = "https://flagcdn.com/ir.svg", IsRTL = true, CountryPhoneCode = "+98" },
    new Country { CountryId = 80, Name = "Iraq", Code = "IQ", Continent = "Asia", Capital = "Baghdad", Currency = "IQD", Language = "Arabic/Kurdish", FlagUrl = "https://flagcdn.com/iq.svg", IsRTL = true, CountryPhoneCode = "+964" },
    new Country { CountryId = 81, Name = "Ireland", Code = "IE", Continent = "Europe", Capital = "Dublin", Currency = "EUR", Language = "Irish/English", FlagUrl = "https://flagcdn.com/ie.svg", IsRTL = false, CountryPhoneCode = "+353" },
    new Country { CountryId = 82, Name = "Israel", Code = "IL", Continent = "Asia", Capital = "Jerusalem", Currency = "ILS", Language = "Hebrew/Arabic", FlagUrl = "https://flagcdn.com/il.svg", IsRTL = true, CountryPhoneCode = "+972" },
    new Country { CountryId = 83, Name = "Italy", Code = "IT", Continent = "Europe", Capital = "Rome", Currency = "EUR", Language = "Italian", FlagUrl = "https://flagcdn.com/it.svg", IsRTL = false, CountryPhoneCode = "+39" },
    new Country { CountryId = 84, Name = "Jamaica", Code = "JM", Continent = "North America", Capital = "Kingston", Currency = "JMD", Language = "English", FlagUrl = "https://flagcdn.com/jm.svg", IsRTL = false, CountryPhoneCode = "+1-876" },
    new Country { CountryId = 85, Name = "Japan", Code = "JP", Continent = "Asia", Capital = "Tokyo", Currency = "JPY", Language = "Japanese", FlagUrl = "https://flagcdn.com/jp.svg", IsRTL = false, CountryPhoneCode = "+81" },
    new Country { CountryId = 86, Name = "Jordan", Code = "JO", Continent = "Asia", Capital = "Amman", Currency = "JOD", Language = "Arabic", FlagUrl = "https://flagcdn.com/jo.svg", IsRTL = true, CountryPhoneCode = "+962" },
    new Country { CountryId = 87, Name = "Kazakhstan", Code = "KZ", Continent = "Asia", Capital = "Astana", Currency = "KZT", Language = "Kazakh/Russian", FlagUrl = "https://flagcdn.com/kz.svg", IsRTL = false, CountryPhoneCode = "+7" },
    new Country { CountryId = 88, Name = "Kenya", Code = "KE", Continent = "Africa", Capital = "Nairobi", Currency = "KES", Language = "English/Swahili", FlagUrl = "https://flagcdn.com/ke.svg", IsRTL = false, CountryPhoneCode = "+254" },
    new Country { CountryId = 89, Name = "Kiribati", Code = "KI", Continent = "Oceania", Capital = "Tarawa", Currency = "AUD", Language = "English", FlagUrl = "https://flagcdn.com/ki.svg", IsRTL = false, CountryPhoneCode = "+686" },
    new Country { CountryId = 90, Name = "Kuwait", Code = "KW", Continent = "Asia", Capital = "Kuwait City", Currency = "KWD", Language = "Arabic", FlagUrl = "https://flagcdn.com/kw.svg", IsRTL = true, CountryPhoneCode = "+965" },
    new Country { CountryId = 91, Name = "Kyrgyzstan", Code = "KG", Continent = "Asia", Capital = "Bishkek", Currency = "KGS", Language = "Kyrgyz/Russian", FlagUrl = "https://flagcdn.com/kg.svg", IsRTL = false, CountryPhoneCode = "+996" },
    new Country { CountryId = 92, Name = "Laos", Code = "LA", Continent = "Asia", Capital = "Vientiane", Currency = "LAK", Language = "Lao", FlagUrl = "https://flagcdn.com/la.svg", IsRTL = false, CountryPhoneCode = "+856" },
    new Country { CountryId = 93, Name = "Latvia", Code = "LV", Continent = "Europe", Capital = "Riga", Currency = "EUR", Language = "Latvian", FlagUrl = "https://flagcdn.com/lv.svg", IsRTL = false, CountryPhoneCode = "+371" },
    new Country { CountryId = 94, Name = "Lebanon", Code = "LB", Continent = "Asia", Capital = "Beirut", Currency = "LBP", Language = "Arabic", FlagUrl = "https://flagcdn.com/lb.svg", IsRTL = true, CountryPhoneCode = "+961" },
    new Country { CountryId = 95, Name = "Lesotho", Code = "LS", Continent = "Africa", Capital = "Maseru", Currency = "LSL", Language = "English/Sesotho", FlagUrl = "https://flagcdn.com/ls.svg", IsRTL = false, CountryPhoneCode = "+266" },
    new Country { CountryId = 96, Name = "Liberia", Code = "LR", Continent = "Africa", Capital = "Monrovia", Currency = "LRD", Language = "English", FlagUrl = "https://flagcdn.com/lr.svg", IsRTL = false, CountryPhoneCode = "+231" },
    new Country { CountryId = 97, Name = "Libya", Code = "LY", Continent = "Africa", Capital = "Tripoli", Currency = "LYD", Language = "Arabic", FlagUrl = "https://flagcdn.com/ly.svg", IsRTL = true, CountryPhoneCode = "+218" },
    new Country { CountryId = 98, Name = "Liechtenstein", Code = "LI", Continent = "Europe", Capital = "Vaduz", Currency = "CHF", Language = "German", FlagUrl = "https://flagcdn.com/li.svg", IsRTL = false, CountryPhoneCode = "+423" },
    new Country { CountryId = 99, Name = "Lithuania", Code = "LT", Continent = "Europe", Capital = "Vilnius", Currency = "EUR", Language = "Lithuanian", FlagUrl = "https://flagcdn.com/lt.svg", IsRTL = false, CountryPhoneCode = "+370" },
    new Country { CountryId = 100, Name = "Luxembourg", Code = "LU", Continent = "Europe", Capital = "Luxembourg", Currency = "EUR", Language = "Luxembourgish/French/German", FlagUrl = "https://flagcdn.com/lu.svg", IsRTL = false, CountryPhoneCode = "+352" }
);

            // Seed Countries (ISO 3166-1 alpha-2, exhaustive, batch 3)
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 101, Name = "Madagascar", Code = "MG", Continent = "Africa", Capital = "Antananarivo", Currency = "MGA", Language = "Malagasy/French", FlagUrl = "https://flagcdn.com/mg.svg", IsRTL = false, CountryPhoneCode = "+261" },
                new Country { CountryId = 102, Name = "Malawi", Code = "MW", Continent = "Africa", Capital = "Lilongwe", Currency = "MWK", Language = "English/Chichewa", FlagUrl = "https://flagcdn.com/mw.svg", IsRTL = false, CountryPhoneCode = "+265" },
                new Country { CountryId = 103, Name = "Malaysia", Code = "MY", Continent = "Asia", Capital = "Kuala Lumpur", Currency = "MYR", Language = "Malay", FlagUrl = "https://flagcdn.com/my.svg", IsRTL = false, CountryPhoneCode = "+60" },
                new Country { CountryId = 104, Name = "Maldives", Code = "MV", Continent = "Asia", Capital = "Malé", Currency = "MVR", Language = "Dhivehi", FlagUrl = "https://flagcdn.com/mv.svg", IsRTL = false, CountryPhoneCode = "+960" },
                new Country { CountryId = 105, Name = "Mali", Code = "ML", Continent = "Africa", Capital = "Bamako", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/ml.svg", IsRTL = false, CountryPhoneCode = "+223" },
                new Country { CountryId = 106, Name = "Malta", Code = "MT", Continent = "Europe", Capital = "Valletta", Currency = "EUR", Language = "Maltese/English", FlagUrl = "https://flagcdn.com/mt.svg", IsRTL = false, CountryPhoneCode = "+356" },
                new Country { CountryId = 107, Name = "Marshall Islands", Code = "MH", Continent = "Oceania", Capital = "Majuro", Currency = "USD", Language = "Marshallese/English", FlagUrl = "https://flagcdn.com/mh.svg", IsRTL = false, CountryPhoneCode = "+692" },
                new Country { CountryId = 108, Name = "Mauritania", Code = "MR", Continent = "Africa", Capital = "Nouakchott", Currency = "MRU", Language = "Arabic", FlagUrl = "https://flagcdn.com/mr.svg", IsRTL = true, CountryPhoneCode = "+222" },
                new Country { CountryId = 109, Name = "Mauritius", Code = "MU", Continent = "Africa", Capital = "Port Louis", Currency = "MUR", Language = "English/French", FlagUrl = "https://flagcdn.com/mu.svg", IsRTL = false, CountryPhoneCode = "+230" },
                new Country { CountryId = 110, Name = "Mexico", Code = "MX", Continent = "North America", Capital = "Mexico City", Currency = "MXN", Language = "Spanish", FlagUrl = "https://flagcdn.com/mx.svg", IsRTL = false, CountryPhoneCode = "+52" },
                new Country { CountryId = 111, Name = "Micronesia", Code = "FM", Continent = "Oceania", Capital = "Palikir", Currency = "USD", Language = "English", FlagUrl = "https://flagcdn.com/fm.svg", IsRTL = false, CountryPhoneCode = "+691" },
                new Country { CountryId = 112, Name = "Moldova", Code = "MD", Continent = "Europe", Capital = "Chisinau", Currency = "MDL", Language = "Romanian", FlagUrl = "https://flagcdn.com/md.svg", IsRTL = false, CountryPhoneCode = "+373" },
                new Country { CountryId = 113, Name = "Monaco", Code = "MC", Continent = "Europe", Capital = "Monaco", Currency = "EUR", Language = "French", FlagUrl = "https://flagcdn.com/mc.svg", IsRTL = false, CountryPhoneCode = "+377" },
                new Country { CountryId = 114, Name = "Mongolia", Code = "MN", Continent = "Asia", Capital = "Ulaanbaatar", Currency = "MNT", Language = "Mongolian", FlagUrl = "https://flagcdn.com/mn.svg", IsRTL = false, CountryPhoneCode = "+976" },
                new Country { CountryId = 115, Name = "Montenegro", Code = "ME", Continent = "Europe", Capital = "Podgorica", Currency = "EUR", Language = "Montenegrin", FlagUrl = "https://flagcdn.com/me.svg", IsRTL = false, CountryPhoneCode = "+382" },
                new Country { CountryId = 116, Name = "Morocco", Code = "MA", Continent = "Africa", Capital = "Rabat", Currency = "MAD", Language = "Arabic/Berber", FlagUrl = "https://flagcdn.com/ma.svg", IsRTL = true, CountryPhoneCode = "+212" },
                new Country { CountryId = 117, Name = "Mozambique", Code = "MZ", Continent = "Africa", Capital = "Maputo", Currency = "MZN", Language = "Portuguese", FlagUrl = "https://flagcdn.com/mz.svg", IsRTL = false, CountryPhoneCode = "+258" },
                new Country { CountryId = 118, Name = "Myanmar", Code = "MM", Continent = "Asia", Capital = "Naypyidaw", Currency = "MMK", Language = "Burmese", FlagUrl = "https://flagcdn.com/mm.svg", IsRTL = false, CountryPhoneCode = "+95" },
                new Country { CountryId = 119, Name = "Namibia", Code = "NA", Continent = "Africa", Capital = "Windhoek", Currency = "NAD", Language = "English", FlagUrl = "https://flagcdn.com/na.svg", IsRTL = false, CountryPhoneCode = "+264" },
                new Country { CountryId = 120, Name = "Nauru", Code = "NR", Continent = "Oceania", Capital = "Yaren", Currency = "AUD", Language = "Nauruan/English", FlagUrl = "https://flagcdn.com/nr.svg", IsRTL = false, CountryPhoneCode = "+674" },
                new Country { CountryId = 121, Name = "Nepal", Code = "NP", Continent = "Asia", Capital = "Kathmandu", Currency = "NPR", Language = "Nepali", FlagUrl = "https://flagcdn.com/np.svg", IsRTL = false, CountryPhoneCode = "+977" },
                new Country { CountryId = 122, Name = "Netherlands", Code = "NL", Continent = "Europe", Capital = "Amsterdam", Currency = "EUR", Language = "Dutch", FlagUrl = "https://flagcdn.com/nl.svg", IsRTL = false, CountryPhoneCode = "+31" },
                new Country { CountryId = 123, Name = "New Zealand", Code = "NZ", Continent = "Oceania", Capital = "Wellington", Currency = "NZD", Language = "English/Māori", FlagUrl = "https://flagcdn.com/nz.svg", IsRTL = false, CountryPhoneCode = "+64" },
                new Country { CountryId = 124, Name = "Nicaragua", Code = "NI", Continent = "North America", Capital = "Managua", Currency = "NIO", Language = "Spanish", FlagUrl = "https://flagcdn.com/ni.svg", IsRTL = false, CountryPhoneCode = "+505" },
                new Country { CountryId = 125, Name = "Niger", Code = "NE", Continent = "Africa", Capital = "Niamey", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/ne.svg", IsRTL = false, CountryPhoneCode = "+227" },
                new Country { CountryId = 126, Name = "Nigeria", Code = "NG", Continent = "Africa", Capital = "Abuja", Currency = "NGN", Language = "English", FlagUrl = "https://flagcdn.com/ng.svg", IsRTL = false, CountryPhoneCode = "+234" },
                new Country { CountryId = 127, Name = "North Korea", Code = "KP", Continent = "Asia", Capital = "Pyongyang", Currency = "KPW", Language = "Korean", FlagUrl = "https://flagcdn.com/kp.svg", IsRTL = false, CountryPhoneCode = "+850" },
                new Country { CountryId = 128, Name = "North Macedonia", Code = "MK", Continent = "Europe", Capital = "Skopje", Currency = "MKD", Language = "Macedonian", FlagUrl = "https://flagcdn.com/mk.svg", IsRTL = false, CountryPhoneCode = "+389" },
                new Country { CountryId = 129, Name = "Norway", Code = "NO", Continent = "Europe", Capital = "Oslo", Currency = "NOK", Language = "Norwegian", FlagUrl = "https://flagcdn.com/no.svg", IsRTL = false, CountryPhoneCode = "+47" },
                new Country { CountryId = 130, Name = "Oman", Code = "OM", Continent = "Asia", Capital = "Muscat", Currency = "OMR", Language = "Arabic", FlagUrl = "https://flagcdn.com/om.svg", IsRTL = true, CountryPhoneCode = "+968" },
                new Country { CountryId = 131, Name = "Pakistan", Code = "PK", Continent = "Asia", Capital = "Islamabad", Currency = "PKR", Language = "Urdu/English", FlagUrl = "https://flagcdn.com/pk.svg", IsRTL = true, CountryPhoneCode = "+92" },
                new Country { CountryId = 132, Name = "Palau", Code = "PW", Continent = "Oceania", Capital = "Ngerulmud", Currency = "USD", Language = "Palauan/English", FlagUrl = "https://flagcdn.com/pw.svg", IsRTL = false, CountryPhoneCode = "+680" },
                new Country { CountryId = 133, Name = "Palestine", Code = "PS", Continent = "Asia", Capital = "East Jerusalem", Currency = "ILS", Language = "Arabic", FlagUrl = "https://flagcdn.com/ps.svg", IsRTL = true, CountryPhoneCode = "+970" },
                new Country { CountryId = 134, Name = "Panama", Code = "PA", Continent = "North America", Capital = "Panama City", Currency = "PAB/USD", Language = "Spanish", FlagUrl = "https://flagcdn.com/pa.svg", IsRTL = false, CountryPhoneCode = "+507" },
                new Country { CountryId = 135, Name = "Papua New Guinea", Code = "PG", Continent = "Oceania", Capital = "Port Moresby", Currency = "PGK", Language = "English/Hiri Motu/Tok Pisin", FlagUrl = "https://flagcdn.com/pg.svg", IsRTL = false, CountryPhoneCode = "+675" },
                new Country { CountryId = 136, Name = "Paraguay", Code = "PY", Continent = "South America", Capital = "Asunción", Currency = "PYG", Language = "Spanish/Guarani", FlagUrl = "https://flagcdn.com/py.svg", IsRTL = false, CountryPhoneCode = "+595" },
                new Country { CountryId = 137, Name = "Peru", Code = "PE", Continent = "South America", Capital = "Lima", Currency = "PEN", Language = "Spanish/Quechua/Aymara", FlagUrl = "https://flagcdn.com/pe.svg", IsRTL = false, CountryPhoneCode = "+51" },
                new Country { CountryId = 138, Name = "Philippines", Code = "PH", Continent = "Asia", Capital = "Manila", Currency = "PHP", Language = "Filipino/English", FlagUrl = "https://flagcdn.com/ph.svg", IsRTL = false, CountryPhoneCode = "+63" },
                new Country { CountryId = 139, Name = "Poland", Code = "PL", Continent = "Europe", Capital = "Warsaw", Currency = "PLN", Language = "Polish", FlagUrl = "https://flagcdn.com/pl.svg", IsRTL = false, CountryPhoneCode = "+48" },
                new Country { CountryId = 140, Name = "Portugal", Code = "PT", Continent = "Europe", Capital = "Lisbon", Currency = "EUR", Language = "Portuguese", FlagUrl = "https://flagcdn.com/pt.svg", IsRTL = false, CountryPhoneCode = "+351" },
                new Country { CountryId = 141, Name = "Qatar", Code = "QA", Continent = "Asia", Capital = "Doha", Currency = "QAR", Language = "Arabic", FlagUrl = "https://flagcdn.com/qa.svg", IsRTL = true, CountryPhoneCode = "+974" },
                new Country { CountryId = 142, Name = "Romania", Code = "RO", Continent = "Europe", Capital = "Bucharest", Currency = "RON", Language = "Romanian", FlagUrl = "https://flagcdn.com/ro.svg", IsRTL = false, CountryPhoneCode = "+40" },
                new Country { CountryId = 143, Name = "Russia", Code = "RU", Continent = "Europe/Asia", Capital = "Moscow", Currency = "RUB", Language = "Russian", FlagUrl = "https://flagcdn.com/ru.svg", IsRTL = false, CountryPhoneCode = "+7" },
                new Country { CountryId = 144, Name = "Rwanda", Code = "RW", Continent = "Africa", Capital = "Kigali", Currency = "RWF", Language = "Kinyarwanda/French/English", FlagUrl = "https://flagcdn.com/rw.svg", IsRTL = false, CountryPhoneCode = "+250" },
                new Country { CountryId = 145, Name = "Saint Kitts and Nevis", Code = "KN", Continent = "North America", Capital = "Basseterre", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/kn.svg", IsRTL = false, CountryPhoneCode = "+1869" },
                new Country { CountryId = 146, Name = "Saint Lucia", Code = "LC", Continent = "North America", Capital = "Castries", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/lc.svg", IsRTL = false, CountryPhoneCode = "+1758" },
                new Country { CountryId = 147, Name = "Saint Vincent and the Grenadines", Code = "VC", Continent = "North America", Capital = "Kingstown", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/vc.svg", IsRTL = false, CountryPhoneCode = "+1784" },
                new Country { CountryId = 148, Name = "Samoa", Code = "WS", Continent = "Oceania", Capital = "Apia", Currency = "WST", Language = "Samoan/English", FlagUrl = "https://flagcdn.com/ws.svg", IsRTL = false, CountryPhoneCode = "+685" },
                new Country { CountryId = 149, Name = "San Marino", Code = "SM", Continent = "Europe", Capital = "San Marino", Currency = "EUR", Language = "Italian", FlagUrl = "https://flagcdn.com/sm.svg", IsRTL = false, CountryPhoneCode = "+378" },
                new Country { CountryId = 150, Name = "Sao Tome and Principe", Code = "ST", Continent = "Africa", Capital = "São Tomé", Currency = "STN", Language = "Portuguese", FlagUrl = "https://flagcdn.com/st.svg", IsRTL = false, CountryPhoneCode = "+239" }
            );

            modelBuilder.Entity<Country>().HasData(
    new Country { CountryId = 151, Name = "Saudi Arabia", Code = "SA", Continent = "Asia", Capital = "Riyadh", Currency = "SAR", Language = "Arabic", FlagUrl = "https://flagcdn.com/sa.svg", IsRTL = true, CountryPhoneCode = "966" },
    new Country { CountryId = 152, Name = "Senegal", Code = "SN", Continent = "Africa", Capital = "Dakar", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/sn.svg", IsRTL = false, CountryPhoneCode = "221" },
    new Country { CountryId = 153, Name = "Serbia", Code = "RS", Continent = "Europe", Capital = "Belgrade", Currency = "RSD", Language = "Serbian", FlagUrl = "https://flagcdn.com/rs.svg", IsRTL = false, CountryPhoneCode = "381" },
    new Country { CountryId = 154, Name = "Seychelles", Code = "SC", Continent = "Africa", Capital = "Victoria", Currency = "SCR", Language = "Seychellois Creole/English/French", FlagUrl = "https://flagcdn.com/sc.svg", IsRTL = false, CountryPhoneCode = "248" },
    new Country { CountryId = 155, Name = "Sierra Leone", Code = "SL", Continent = "Africa", Capital = "Freetown", Currency = "SLL", Language = "English", FlagUrl = "https://flagcdn.com/sl.svg", IsRTL = false, CountryPhoneCode = "232" },
    new Country { CountryId = 156, Name = "Singapore", Code = "SG", Continent = "Asia", Capital = "Singapore", Currency = "SGD", Language = "English/Malay/Mandarin/Tamil", FlagUrl = "https://flagcdn.com/sg.svg", IsRTL = false, CountryPhoneCode = "65" },
    new Country { CountryId = 157, Name = "Slovakia", Code = "SK", Continent = "Europe", Capital = "Bratislava", Currency = "EUR", Language = "Slovak", FlagUrl = "https://flagcdn.com/sk.svg", IsRTL = false, CountryPhoneCode = "421" },
    new Country { CountryId = 158, Name = "Slovenia", Code = "SI", Continent = "Europe", Capital = "Ljubljana", Currency = "EUR", Language = "Slovene", FlagUrl = "https://flagcdn.com/si.svg", IsRTL = false, CountryPhoneCode = "386" },
    new Country { CountryId = 159, Name = "Solomon Islands", Code = "SB", Continent = "Oceania", Capital = "Honiara", Currency = "SBD", Language = "English", FlagUrl = "https://flagcdn.com/sb.svg", IsRTL = false, CountryPhoneCode = "677" },
    new Country { CountryId = 160, Name = "Somalia", Code = "SO", Continent = "Africa", Capital = "Mogadishu", Currency = "SOS", Language = "Somali/Arabic", FlagUrl = "https://flagcdn.com/so.svg", IsRTL = true, CountryPhoneCode = "252" },
    new Country { CountryId = 161, Name = "South Africa", Code = "ZA", Continent = "Africa", Capital = "Pretoria", Currency = "ZAR", Language = "English/Afrikaans/Zulu", FlagUrl = "https://flagcdn.com/za.svg", IsRTL = false, CountryPhoneCode = "27" },
    new Country { CountryId = 162, Name = "South Korea", Code = "KR", Continent = "Asia", Capital = "Seoul", Currency = "KRW", Language = "Korean", FlagUrl = "https://flagcdn.com/kr.svg", IsRTL = false, CountryPhoneCode = "82" },
    new Country { CountryId = 163, Name = "South Sudan", Code = "SS", Continent = "Africa", Capital = "Juba", Currency = "SSP", Language = "English", FlagUrl = "https://flagcdn.com/ss.svg", IsRTL = false, CountryPhoneCode = "211" },
    new Country { CountryId = 164, Name = "Spain", Code = "ES", Continent = "Europe", Capital = "Madrid", Currency = "EUR", Language = "Spanish", FlagUrl = "https://flagcdn.com/es.svg", IsRTL = false, CountryPhoneCode = "34" },
    new Country { CountryId = 165, Name = "Sri Lanka", Code = "LK", Continent = "Asia", Capital = "Sri Jayawardenepura Kotte", Currency = "LKR", Language = "Sinhala/Tamil", FlagUrl = "https://flagcdn.com/lk.svg", IsRTL = false, CountryPhoneCode = "94" },
    new Country { CountryId = 166, Name = "Sudan", Code = "SD", Continent = "Africa", Capital = "Khartoum", Currency = "SDG", Language = "Arabic/English", FlagUrl = "https://flagcdn.com/sd.svg", IsRTL = true, CountryPhoneCode = "249" },
    new Country { CountryId = 167, Name = "Suriname", Code = "SR", Continent = "South America", Capital = "Paramaribo", Currency = "SRD", Language = "Dutch", FlagUrl = "https://flagcdn.com/sr.svg", IsRTL = false, CountryPhoneCode = "597" },
    new Country { CountryId = 168, Name = "Sweden", Code = "SE", Continent = "Europe", Capital = "Stockholm", Currency = "SEK", Language = "Swedish", FlagUrl = "https://flagcdn.com/se.svg", IsRTL = false, CountryPhoneCode = "46" },
    new Country { CountryId = 169, Name = "Switzerland", Code = "CH", Continent = "Europe", Capital = "Bern", Currency = "CHF", Language = "German/French/Italian/Romansh", FlagUrl = "https://flagcdn.com/ch.svg", IsRTL = false, CountryPhoneCode = "41" },
    new Country { CountryId = 170, Name = "Syria", Code = "SY", Continent = "Asia", Capital = "Damascus", Currency = "SYP", Language = "Arabic", FlagUrl = "https://flagcdn.com/sy.svg", IsRTL = true, CountryPhoneCode = "963" },
    new Country { CountryId = 171, Name = "Tajikistan", Code = "TJ", Continent = "Asia", Capital = "Dushanbe", Currency = "TJS", Language = "Tajik", FlagUrl = "https://flagcdn.com/tj.svg", IsRTL = false, CountryPhoneCode = "992" },
    new Country { CountryId = 172, Name = "Tanzania", Code = "TZ", Continent = "Africa", Capital = "Dodoma", Currency = "TZS", Language = "Swahili/English", FlagUrl = "https://flagcdn.com/tz.svg", IsRTL = false, CountryPhoneCode = "255" },
    new Country { CountryId = 173, Name = "Thailand", Code = "TH", Continent = "Asia", Capital = "Bangkok", Currency = "THB", Language = "Thai", FlagUrl = "https://flagcdn.com/th.svg", IsRTL = false, CountryPhoneCode = "66" },
    new Country { CountryId = 174, Name = "Timor-Leste", Code = "TL", Continent = "Asia", Capital = "Dili", Currency = "USD", Language = "Tetum/Portuguese", FlagUrl = "https://flagcdn.com/tl.svg", IsRTL = false, CountryPhoneCode = "670" },
    new Country { CountryId = 175, Name = "Togo", Code = "TG", Continent = "Africa", Capital = "Lomé", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/tg.svg", IsRTL = false, CountryPhoneCode = "228" },
    new Country { CountryId = 176, Name = "Tonga", Code = "TO", Continent = "Oceania", Capital = "Nukuʻalofa", Currency = "TOP", Language = "Tongan/English", FlagUrl = "https://flagcdn.com/to.svg", IsRTL = false, CountryPhoneCode = "676" },
    new Country { CountryId = 177, Name = "Trinidad and Tobago", Code = "TT", Continent = "North America", Capital = "Port of Spain", Currency = "TTD", Language = "English", FlagUrl = "https://flagcdn.com/tt.svg", IsRTL = false, CountryPhoneCode = "1-868" },
    new Country { CountryId = 178, Name = "Tunisia", Code = "TN", Continent = "Africa", Capital = "Tunis", Currency = "TND", Language = "Arabic", FlagUrl = "https://flagcdn.com/tn.svg", IsRTL = true, CountryPhoneCode = "216" },
    new Country { CountryId = 179, Name = "Turkey", Code = "TR", Continent = "Europe/Asia", Capital = "Ankara", Currency = "TRY", Language = "Turkish", FlagUrl = "https://flagcdn.com/tr.svg", IsRTL = false, CountryPhoneCode = "90" },
    new Country { CountryId = 180, Name = "Turkmenistan", Code = "TM", Continent = "Asia", Capital = "Ashgabat", Currency = "TMT", Language = "Turkmen", FlagUrl = "https://flagcdn.com/tm.svg", IsRTL = false, CountryPhoneCode = "993" },
    new Country { CountryId = 181, Name = "Tuvalu", Code = "TV", Continent = "Oceania", Capital = "Funafuti", Currency = "AUD", Language = "Tuvaluan/English", FlagUrl = "https://flagcdn.com/tv.svg", IsRTL = false, CountryPhoneCode = "688" },
    new Country { CountryId = 182, Name = "Uganda", Code = "UG", Continent = "Africa", Capital = "Kampala", Currency = "UGX", Language = "English/Swahili", FlagUrl = "https://flagcdn.com/ug.svg", IsRTL = false, CountryPhoneCode = "256" },
    new Country { CountryId = 183, Name = "Ukraine", Code = "UA", Continent = "Europe", Capital = "Kyiv", Currency = "UAH", Language = "Ukrainian", FlagUrl = "https://flagcdn.com/ua.svg", IsRTL = false, CountryPhoneCode = "380" },
    new Country { CountryId = 184, Name = "United Arab Emirates", Code = "AE", Continent = "Asia", Capital = "Abu Dhabi", Currency = "AED", Language = "Arabic", FlagUrl = "https://flagcdn.com/ae.svg", IsRTL = true, CountryPhoneCode = "971" },
    new Country { CountryId = 185, Name = "United Kingdom", Code = "GB", Continent = "Europe", Capital = "London", Currency = "GBP", Language = "English", FlagUrl = "https://flagcdn.com/gb.svg", IsRTL = false, CountryPhoneCode = "44" },
    new Country { CountryId = 186, Name = "United States", Code = "US", Continent = "North America", Capital = "Washington, D.C.", Currency = "USD", Language = "English", FlagUrl = "https://flagcdn.com/us.svg", IsRTL = false, CountryPhoneCode = "1" },
    new Country { CountryId = 187, Name = "Uruguay", Code = "UY", Continent = "South America", Capital = "Montevideo", Currency = "UYU", Language = "Spanish", FlagUrl = "https://flagcdn.com/uy.svg", IsRTL = false, CountryPhoneCode = "598" },
    new Country { CountryId = 188, Name = "Uzbekistan", Code = "UZ", Continent = "Asia", Capital = "Tashkent", Currency = "UZS", Language = "Uzbek", FlagUrl = "https://flagcdn.com/uz.svg", IsRTL = false, CountryPhoneCode = "998" },
    new Country { CountryId = 189, Name = "Vanuatu", Code = "VU", Continent = "Oceania", Capital = "Port Vila", Currency = "VUV", Language = "Bislama/English/French", FlagUrl = "https://flagcdn.com/vu.svg", IsRTL = false, CountryPhoneCode = "678" },
    new Country { CountryId = 190, Name = "Vatican City", Code = "VA", Continent = "Europe", Capital = "Vatican City", Currency = "EUR", Language = "Italian/Latin", FlagUrl = "https://flagcdn.com/va.svg", IsRTL = false, CountryPhoneCode = "39" },
    new Country { CountryId = 191, Name = "Venezuela", Code = "VE", Continent = "South America", Capital = "Caracas", Currency = "VES", Language = "Spanish", FlagUrl = "https://flagcdn.com/ve.svg", IsRTL = false, CountryPhoneCode = "58" },
    new Country { CountryId = 192, Name = "Vietnam", Code = "VN", Continent = "Asia", Capital = "Hanoi", Currency = "VND", Language = "Vietnamese", FlagUrl = "https://flagcdn.com/vn.svg", IsRTL = false, CountryPhoneCode = "84" },
    new Country { CountryId = 193, Name = "Yemen", Code = "YE", Continent = "Asia", Capital = "Sana'a", Currency = "YER", Language = "Arabic", FlagUrl = "https://flagcdn.com/ye.svg", IsRTL = true, CountryPhoneCode = "967" },
    new Country { CountryId = 194, Name = "Zambia", Code = "ZM", Continent = "Africa", Capital = "Lusaka", Currency = "ZMW", Language = "English", FlagUrl = "https://flagcdn.com/zm.svg", IsRTL = false, CountryPhoneCode = "260" },
    new Country { CountryId = 195, Name = "Zimbabwe", Code = "ZW", Continent = "Africa", Capital = "Harare", Currency = "ZWL", Language = "English/Shona/Sindebele", FlagUrl = "https://flagcdn.com/zw.svg", IsRTL = false, CountryPhoneCode = "263" }
);

        }

        //public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        //{
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        //    List<Role> roles = new List<Role>
        //    {
        //        new Role {  Name = RoleNames.MainSuperAdmin, NormalizedName = RoleNames.MainSuperAdmin.ToUpper(), Description = "Create users of all levels" },
        //        new Role { Name = RoleNames.MainAdmin, NormalizedName = RoleNames.MainAdmin.ToUpper(), Description = "Create users of all levels under him" },
        //        new Role { Name = RoleNames.MainDataEntry, NormalizedName = RoleNames.MainDataEntry.ToUpper(), Description = "Modify data of all levels" },
        //        new Role { Name = RoleNames.CompanySuperAdmin, NormalizedName = RoleNames.CompanySuperAdmin.ToUpper(), Description = "Create users of all levels" },
        //        new Role { Name = RoleNames.CompanyAdmin, NormalizedName = RoleNames.CompanyAdmin.ToUpper(), Description = "Create users of all levels under him" },
        //        new Role { Name = RoleNames.CompanyDataEntry, NormalizedName = RoleNames.CompanyDataEntry.ToUpper(), Description = "Modify data of all levels" },
        //        new Role { Name = RoleNames.CountrySuperAdmin, NormalizedName = RoleNames.CountrySuperAdmin.ToUpper(), Description = "Create users of all levels within a country" },
        //        new Role { Name = RoleNames.CountryAdmin, NormalizedName = RoleNames.CountryAdmin.ToUpper(), Description = "Create users of all levels under him within a country" },
        //        new Role { Name = RoleNames.CountryDataEntry, NormalizedName = RoleNames.CountryDataEntry.ToUpper(), Description = "Modify data of all levels within a country" },
        //        new Role { Name = RoleNames.CountrySupervisor, NormalizedName = RoleNames.CountrySupervisor.ToUpper(), Description = "Enter Guests Data within his supervision" },
        //        new Role { Name = RoleNames.Guest, NormalizedName = RoleNames.Guest.ToUpper(), Description = "Guest can view some data only" }

        //    };
        //    try
        //    {


        //        foreach (var role in roles)
        //        {
        //            if (!await roleManager.RoleExistsAsync(role.Name!))
        //            {
        //                await roleManager.CreateAsync(role);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var st = ex.ToString();
        //        throw;
        //    }

        //    string mainSuperAdminPassword = "Admin@123";
        //    User user = new User
        //    {
        //        FirstName = "Bashir",
        //        LastName = "Mohamed Ali",
        //        UserName = "MainSuperAdmin",
        //        Passport = string.Empty,
        //        IssuePlace = string.Empty,
        //        Email = "",
        //        Address = "",
        //        AdministrativeDivisionId = 1,
        //        PhoneNumber = "0000000000",
        //    };

        //    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        //    var existingUser = await userManager.FindByNameAsync(user.UserName);

        //    if (existingUser==null)
        //    {
        //        var result = await userManager.CreateAsync(user, mainSuperAdminPassword);
        //        if (result.Succeeded)
        //        {
        //            //var rolesList1= await roleManager.Roles.Select(r => r.Name).ToListAsync();
        //            foreach (var role in roles)
        //            {
        //                await userManager.AddToRoleAsync(user, role.Name!);
        //            }
        //            foreach(var permission in PermissionHelper.GetAllPermissions())
        //            {
        //                await userManager.AddClaimAsync(user, new Claim("Permission", permission));
        //            }
        //        }
        //    }
        //}

    }
}
