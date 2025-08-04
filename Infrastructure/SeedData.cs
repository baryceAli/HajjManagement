using CoreBusiness;
using Infrastructure.Plugin.Datastore.SQLServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        public static void SeedUser(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //        new User { Id=1,CountryId= 151 ,Email= "baryce@gmail.com", EmailConfirmed=true,FirstName="Bashir", LastName="Mohamed Ali",
            //            NormalizedUserName="Bashir", NormalizedEmail="Bashir",UserName="Bashir"
            //        }
            //    );
        }
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role {Id=1,Name="SuperAdmin",NormalizedName="SuperAdmin",Description=string.Empty},
                    new Role {Id=2,Name="MainAdmin",NormalizedName= "MainAdmin", Description=string.Empty},
                    new Role {Id=3,Name= "MainDataEntry", NormalizedName= "MainDataEntry", Description=string.Empty},
                    new Role {Id=4,Name="CountrySuperAdmin",NormalizedName= "CountrySuperAdmin", Description=string.Empty},
                    new Role {Id=5,Name="Admin",NormalizedName="Admin",Description=string.Empty },
                    new Role {Id=6,Name= "Supervisor", NormalizedName= "Supervisor", Description=string.Empty }

                );
        }
        public static void SeedCountries(ApplicationDbContext context)
        {
            if (!context.Countries.Any())
            {
                context.Countries.AddRange(
                   new Country { CountryId = 1, Name = "Afghanistan", Code = "AF", Continent = "Asia", Capital = "Kabul", Currency = "AFN", Language = "Pashto/Dari", FlagUrl = "https://flagcdn.com/af.svg" }
                
                   );
                context.SaveChanges();
            }
        }
        public static void SeedCountries(ModelBuilder modelBuilder)
        {
            // Seed Countries (ISO 3166-1 alpha-2, exhaustive, batch 1)
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "Afghanistan", Code = "AF", Continent = "Asia", Capital = "Kabul", Currency = "AFN", Language = "Pashto/Dari", FlagUrl = "https://flagcdn.com/af.svg" },
                new Country { CountryId =2, Name = "Albania", Code = "AL", Continent = "Europe", Capital = "Tirana", Currency = "ALL", Language = "Albanian", FlagUrl = "https://flagcdn.com/al.svg" },
                new Country { CountryId =3, Name = "Algeria", Code = "DZ", Continent = "Africa", Capital = "Algiers", Currency = "DZD", Language = "Arabic/Berber", FlagUrl = "https://flagcdn.com/dz.svg" },
                new Country { CountryId =4, Name = "Andorra", Code = "AD", Continent = "Europe", Capital = "Andorra la Vella", Currency = "EUR", Language = "Catalan", FlagUrl = "https://flagcdn.com/ad.svg" },
                new Country { CountryId =5, Name = "Angola", Code = "AO", Continent = "Africa", Capital = "Luanda", Currency = "AOA", Language = "Portuguese", FlagUrl = "https://flagcdn.com/ao.svg" },
                new Country { CountryId =6, Name = "Antigua and Barbuda", Code = "AG", Continent = "North America", Capital = "St. John's", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/ag.svg" },
                new Country { CountryId =7, Name = "Argentina", Code = "AR", Continent = "South America", Capital = "Buenos Aires", Currency = "ARS", Language = "Spanish", FlagUrl = "https://flagcdn.com/ar.svg" },
                new Country { CountryId =8, Name = "Armenia", Code = "AM", Continent = "Asia", Capital = "Yerevan", Currency = "AMD", Language = "Armenian", FlagUrl = "https://flagcdn.com/am.svg" },
                new Country { CountryId =9, Name = "Australia", Code = "AU", Continent = "Oceania", Capital = "Canberra", Currency = "AUD", Language = "English", FlagUrl = "https://flagcdn.com/au.svg" },
                new Country { CountryId =10, Name = "Austria", Code = "AT", Continent = "Europe", Capital = "Vienna", Currency = "EUR", Language = "German", FlagUrl = "https://flagcdn.com/at.svg" },
                new Country { CountryId =11, Name = "Azerbaijan", Code = "AZ", Continent = "Asia", Capital = "Baku", Currency = "AZN", Language = "Azerbaijani", FlagUrl = "https://flagcdn.com/az.svg" },
                new Country { CountryId =12, Name = "Bahamas", Code = "BS", Continent = "North America", Capital = "Nassau", Currency = "BSD", Language = "English", FlagUrl = "https://flagcdn.com/bs.svg" },
                new Country { CountryId =13, Name = "Bahrain", Code = "BH", Continent = "Asia", Capital = "Manama", Currency = "BHD", Language = "Arabic", FlagUrl = "https://flagcdn.com/bh.svg" },
                new Country { CountryId =14, Name = "Bangladesh", Code = "BD", Continent = "Asia", Capital = "Dhaka", Currency = "BDT", Language = "Bengali", FlagUrl = "https://flagcdn.com/bd.svg" },
                new Country { CountryId =15, Name = "Barbados", Code = "BB", Continent = "North America", Capital = "Bridgetown", Currency = "BBD", Language = "English", FlagUrl = "https://flagcdn.com/bb.svg" },
                new Country { CountryId =16, Name = "Belarus", Code = "BY", Continent = "Europe", Capital = "Minsk", Currency = "BYN", Language = "Belarusian/Russian", FlagUrl = "https://flagcdn.com/by.svg" },
                new Country { CountryId =17, Name = "Belgium", Code = "BE", Continent = "Europe", Capital = "Brussels", Currency = "EUR", Language = "Dutch/French/German", FlagUrl = "https://flagcdn.com/be.svg" },
                new Country { CountryId =18, Name = "Belize", Code = "BZ", Continent = "North America", Capital = "Belmopan", Currency = "BZD", Language = "English", FlagUrl = "https://flagcdn.com/bz.svg" },
                new Country { CountryId =19, Name = "Benin", Code = "BJ", Continent = "Africa", Capital = "Porto-Novo", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/bj.svg" },
                new Country { CountryId =20, Name = "Bhutan", Code = "BT", Continent = "Asia", Capital = "Thimphu", Currency = "BTN", Language = "Dzongkha", FlagUrl = "https://flagcdn.com/bt.svg" },
                new Country { CountryId =21, Name = "Bolivia", Code = "BO", Continent = "South America", Capital = "Sucre", Currency = "BOB", Language = "Spanish/Aymara/Quechua", FlagUrl = "https://flagcdn.com/bo.svg" },
                new Country { CountryId =22, Name = "Bosnia and Herzegovina", Code = "BA", Continent = "Europe", Capital = "Sarajevo", Currency = "BAM", Language = "Bosnian/Croatian/Serbian", FlagUrl = "https://flagcdn.com/ba.svg" },
                new Country { CountryId =23, Name = "Botswana", Code = "BW", Continent = "Africa", Capital = "Gaborone", Currency = "BWP", Language = "English/Tswana", FlagUrl = "https://flagcdn.com/bw.svg" },
                new Country { CountryId =24, Name = "Brazil", Code = "BR", Continent = "South America", Capital = "Brasília", Currency = "BRL", Language = "Portuguese", FlagUrl = "https://flagcdn.com/br.svg" },
                new Country { CountryId =25, Name = "Brunei", Code = "BN", Continent = "Asia", Capital = "Bandar Seri Begawan", Currency = "BND", Language = "Malay", FlagUrl = "https://flagcdn.com/bn.svg" },
                new Country { CountryId =26, Name = "Bulgaria", Code = "BG", Continent = "Europe", Capital = "Sofia", Currency = "BGN", Language = "Bulgarian", FlagUrl = "https://flagcdn.com/bg.svg" },
                new Country { CountryId =27, Name = "Burkina Faso", Code = "BF", Continent = "Africa", Capital = "Ouagadougou", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/bf.svg" },
                new Country { CountryId =28, Name = "Burundi", Code = "BI", Continent = "Africa", Capital = "Gitega", Currency = "BIF", Language = "Kirundi/French/English", FlagUrl = "https://flagcdn.com/bi.svg" },
                new Country { CountryId =29, Name = "Cabo Verde", Code = "CV", Continent = "Africa", Capital = "Praia", Currency = "CVE", Language = "Portuguese", FlagUrl = "https://flagcdn.com/cv.svg" },
                new Country { CountryId =30, Name = "Cambodia", Code = "KH", Continent = "Asia", Capital = "Phnom Penh", Currency = "KHR", Language = "Khmer", FlagUrl = "https://flagcdn.com/kh.svg" },
                new Country { CountryId =31, Name = "Cameroon", Code = "CM", Continent = "Africa", Capital = "Yaoundé", Currency = "XAF", Language = "French/English", FlagUrl = "https://flagcdn.com/cm.svg" },
                new Country { CountryId =32, Name = "Canada", Code = "CA", Continent = "North America", Capital = "Ottawa", Currency = "CAD", Language = "English/French", FlagUrl = "https://flagcdn.com/ca.svg" },
                new Country { CountryId =33, Name = "Central African Republic", Code = "CF", Continent = "Africa", Capital = "Bangui", Currency = "XAF", Language = "French/Sango", FlagUrl = "https://flagcdn.com/cf.svg" },
                new Country { CountryId =34, Name = "Chad", Code = "TD", Continent = "Africa", Capital = "N'Djamena", Currency = "XAF", Language = "French/Arabic", FlagUrl = "https://flagcdn.com/td.svg" },
                new Country { CountryId =35, Name = "Chile", Code = "CL", Continent = "South America", Capital = "Santiago", Currency = "CLP", Language = "Spanish", FlagUrl = "https://flagcdn.com/cl.svg" },
                new Country { CountryId =36, Name = "China", Code = "CN", Continent = "Asia", Capital = "Beijing", Currency = "CNY", Language = "Chinese", FlagUrl = "https://flagcdn.com/cn.svg" },
                new Country { CountryId =37, Name = "Colombia", Code = "CO", Continent = "South America", Capital = "Bogotá", Currency = "COP", Language = "Spanish", FlagUrl = "https://flagcdn.com/co.svg" },
                new Country { CountryId =38, Name = "Comoros", Code = "KM", Continent = "Africa", Capital = "Moroni", Currency = "KMF", Language = "Comorian/Arabic/French", FlagUrl = "https://flagcdn.com/km.svg" },
                new Country { CountryId =39, Name = "Congo (Congo-Brazzaville)", Code = "CG", Continent = "Africa", Capital = "Brazzaville", Currency = "XAF", Language = "French/Lingala", FlagUrl = "https://flagcdn.com/cg.svg" },
                new Country { CountryId =40, Name = "Congo (Congo-Kinshasa)", Code = "CD", Continent = "Africa", Capital = "Kinshasa", Currency = "CDF", Language = "French/Lingala/Kikongo/Swahili/Tshiluba", FlagUrl = "https://flagcdn.com/cd.svg" },
                new Country { CountryId =41, Name = "Costa Rica", Code = "CR", Continent = "North America", Capital = "San José", Currency = "CRC", Language = "Spanish", FlagUrl = "https://flagcdn.com/cr.svg" },
                new Country { CountryId =42, Name = "Côte d'Ivoire", Code = "CI", Continent = "Africa", Capital = "Yamoussoukro", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/ci.svg" },
                new Country { CountryId =43, Name = "Croatia", Code = "HR", Continent = "Europe", Capital = "Zagreb", Currency = "EUR", Language = "Croatian", FlagUrl = "https://flagcdn.com/hr.svg" },
                new Country { CountryId =44, Name = "Cuba", Code = "CU", Continent = "North America", Capital = "Havana", Currency = "CUP", Language = "Spanish", FlagUrl = "https://flagcdn.com/cu.svg" },
                new Country { CountryId =45, Name = "Cyprus", Code = "CY", Continent = "Europe", Capital = "Nicosia", Currency = "EUR", Language = "Greek/Turkish", FlagUrl = "https://flagcdn.com/cy.svg" },
                new Country { CountryId =46, Name = "Czechia", Code = "CZ", Continent = "Europe", Capital = "Prague", Currency = "CZK", Language = "Czech", FlagUrl = "https://flagcdn.com/cz.svg" },
                new Country { CountryId =47, Name = "Denmark", Code = "DK", Continent = "Europe", Capital = "Copenhagen", Currency = "DKK", Language = "Danish", FlagUrl = "https://flagcdn.com/dk.svg" },
                new Country { CountryId =48, Name = "Djibouti", Code = "DJ", Continent = "Africa", Capital = "Djibouti", Currency = "DJF", Language = "French/Arabic", FlagUrl = "https://flagcdn.com/dj.svg" },
                new Country { CountryId =49, Name = "Dominica", Code = "DM", Continent = "North America", Capital = "Roseau", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/dm.svg" },
                new Country { CountryId =50, Name = "Dominican Republic", Code = "DO", Continent = "North America", Capital = "Santo Domingo", Currency = "DOP", Language = "Spanish", FlagUrl = "https://flagcdn.com/do.svg" }
            );

            // Seed Countries (ISO 3166-1 alpha-2, exhaustive, batch 2)
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId =51, Name = "Ecuador", Code = "EC", Continent = "South America", Capital = "Quito", Currency = "USD", Language = "Spanish", FlagUrl = "https://flagcdn.com/ec.svg" },
                new Country { CountryId =52, Name = "Egypt", Code = "EG", Continent = "Africa", Capital = "Cairo", Currency = "EGP", Language = "Arabic", FlagUrl = "https://flagcdn.com/eg.svg" },
                new Country { CountryId =53, Name = "El Salvador", Code = "SV", Continent = "North America", Capital = "San Salvador", Currency = "USD", Language = "Spanish", FlagUrl = "https://flagcdn.com/sv.svg" },
                new Country { CountryId =54, Name = "Equatorial Guinea", Code = "GQ", Continent = "Africa", Capital = "Malabo", Currency = "XAF", Language = "Spanish/French/Portuguese", FlagUrl = "https://flagcdn.com/gq.svg" },
                new Country { CountryId =55, Name = "Eritrea", Code = "ER", Continent = "Africa", Capital = "Asmara", Currency = "ERN", Language = "Tigrinya/Arabic/English", FlagUrl = "https://flagcdn.com/er.svg" },
                new Country { CountryId =56, Name = "Estonia", Code = "EE", Continent = "Europe", Capital = "Tallinn", Currency = "EUR", Language = "Estonian", FlagUrl = "https://flagcdn.com/ee.svg" },
                new Country { CountryId =57, Name = "Eswatini", Code = "SZ", Continent = "Africa", Capital = "Mbabane", Currency = "SZL", Language = "Swazi/English", FlagUrl = "https://flagcdn.com/sz.svg" },
                new Country { CountryId =58, Name = "Ethiopia", Code = "ET", Continent = "Africa", Capital = "Addis Ababa", Currency = "ETB", Language = "Amharic", FlagUrl = "https://flagcdn.com/et.svg" },
                new Country { CountryId =59, Name = "Fiji", Code = "FJ", Continent = "Oceania", Capital = "Suva", Currency = "FJD", Language = "English/Fijian/Hindi", FlagUrl = "https://flagcdn.com/fj.svg" },
                new Country { CountryId =60, Name = "Finland", Code = "FI", Continent = "Europe", Capital = "Helsinki", Currency = "EUR", Language = "Finnish/Swedish", FlagUrl = "https://flagcdn.com/fi.svg" },
                new Country { CountryId =61, Name = "France", Code = "FR", Continent = "Europe", Capital = "Paris", Currency = "EUR", Language = "French", FlagUrl = "https://flagcdn.com/fr.svg" },
                new Country { CountryId =62, Name = "Gabon", Code = "GA", Continent = "Africa", Capital = "Libreville", Currency = "XAF", Language = "French", FlagUrl = "https://flagcdn.com/ga.svg" },
                new Country { CountryId =63, Name = "Gambia", Code = "GM", Continent = "Africa", Capital = "Banjul", Currency = "GMD", Language = "English", FlagUrl = "https://flagcdn.com/gm.svg" },
                new Country { CountryId =64, Name = "Georgia", Code = "GE", Continent = "Asia", Capital = "Tbilisi", Currency = "GEL", Language = "Georgian", FlagUrl = "https://flagcdn.com/ge.svg" },
                new Country { CountryId =65, Name = "Germany", Code = "DE", Continent = "Europe", Capital = "Berlin", Currency = "EUR", Language = "German", FlagUrl = "https://flagcdn.com/de.svg" },
                new Country { CountryId =66, Name = "Ghana", Code = "GH", Continent = "Africa", Capital = "Accra", Currency = "GHS", Language = "English", FlagUrl = "https://flagcdn.com/gh.svg" },
                new Country { CountryId =67, Name = "Greece", Code = "GR", Continent = "Europe", Capital = "Athens", Currency = "EUR", Language = "Greek", FlagUrl = "https://flagcdn.com/gr.svg" },
                new Country { CountryId =68, Name = "Grenada", Code = "GD", Continent = "North America", Capital = "St. George's", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/gd.svg" },
                new Country { CountryId =69, Name = "Guatemala", Code = "GT", Continent = "North America", Capital = "Guatemala City", Currency = "GTQ", Language = "Spanish", FlagUrl = "https://flagcdn.com/gt.svg" },
                new Country { CountryId =70, Name = "Guinea", Code = "GN", Continent = "Africa", Capital = "Conakry", Currency = "GNF", Language = "French", FlagUrl = "https://flagcdn.com/gn.svg" },
                new Country { CountryId =71, Name = "Guinea-Bissau", Code = "GW", Continent = "Africa", Capital = "Bissau", Currency = "XOF", Language = "Portuguese", FlagUrl = "https://flagcdn.com/gw.svg" },
                new Country { CountryId =72, Name = "Guyana", Code = "GY", Continent = "South America", Capital = "Georgetown", Currency = "GYD", Language = "English", FlagUrl = "https://flagcdn.com/gy.svg" },
                new Country { CountryId =73, Name = "Haiti", Code = "HT", Continent = "North America", Capital = "Port-au-Prince", Currency = "HTG", Language = "French/Haitian Creole", FlagUrl = "https://flagcdn.com/ht.svg" },
                new Country { CountryId =74, Name = "Honduras", Code = "HN", Continent = "North America", Capital = "Tegucigalpa", Currency = "HNL", Language = "Spanish", FlagUrl = "https://flagcdn.com/hn.svg" },
                new Country { CountryId =75, Name = "Hungary", Code = "HU", Continent = "Europe", Capital = "Budapest", Currency = "HUF", Language = "Hungarian", FlagUrl = "https://flagcdn.com/hu.svg" },
                new Country { CountryId =76, Name = "Iceland", Code = "IS", Continent = "Europe", Capital = "Reykjavik", Currency = "ISK", Language = "Icelandic", FlagUrl = "https://flagcdn.com/is.svg" },
                new Country { CountryId =77, Name = "India", Code = "IN", Continent = "Asia", Capital = "New Delhi", Currency = "INR", Language = "Hindi/English", FlagUrl = "https://flagcdn.com/in.svg" },
                new Country { CountryId =78, Name = "Indonesia", Code = "ID", Continent = "Asia", Capital = "Jakarta", Currency = "IDR", Language = "Indonesian", FlagUrl = "https://flagcdn.com/id.svg" },
                new Country { CountryId =79, Name = "Iran", Code = "IR", Continent = "Asia", Capital = "Tehran", Currency = "IRR", Language = "Persian", FlagUrl = "https://flagcdn.com/ir.svg" },
                new Country { CountryId =80, Name = "Iraq", Code = "IQ", Continent = "Asia", Capital = "Baghdad", Currency = "IQD", Language = "Arabic/Kurdish", FlagUrl = "https://flagcdn.com/iq.svg" },
                new Country { CountryId =81, Name = "Ireland", Code = "IE", Continent = "Europe", Capital = "Dublin", Currency = "EUR", Language = "Irish/English", FlagUrl = "https://flagcdn.com/ie.svg" },
                new Country { CountryId =82, Name = "Israel", Code = "IL", Continent = "Asia", Capital = "Jerusalem", Currency = "ILS", Language = "Hebrew/Arabic", FlagUrl = "https://flagcdn.com/il.svg" },
                new Country { CountryId =83, Name = "Italy", Code = "IT", Continent = "Europe", Capital = "Rome", Currency = "EUR", Language = "Italian", FlagUrl = "https://flagcdn.com/it.svg" },
                new Country { CountryId =84, Name = "Jamaica", Code = "JM", Continent = "North America", Capital = "Kingston", Currency = "JMD", Language = "English", FlagUrl = "https://flagcdn.com/jm.svg" },
                new Country { CountryId =85, Name = "Japan", Code = "JP", Continent = "Asia", Capital = "Tokyo", Currency = "JPY", Language = "Japanese", FlagUrl = "https://flagcdn.com/jp.svg" },
                new Country { CountryId =86, Name = "Jordan", Code = "JO", Continent = "Asia", Capital = "Amman", Currency = "JOD", Language = "Arabic", FlagUrl = "https://flagcdn.com/jo.svg" },
                new Country { CountryId =87, Name = "Kazakhstan", Code = "KZ", Continent = "Asia", Capital = "Astana", Currency = "KZT", Language = "Kazakh/Russian", FlagUrl = "https://flagcdn.com/kz.svg" },
                new Country { CountryId =88, Name = "Kenya", Code = "KE", Continent = "Africa", Capital = "Nairobi", Currency = "KES", Language = "English/Swahili", FlagUrl = "https://flagcdn.com/ke.svg" },
                new Country { CountryId =89, Name = "Kiribati", Code = "KI", Continent = "Oceania", Capital = "Tarawa", Currency = "AUD", Language = "English", FlagUrl = "https://flagcdn.com/ki.svg" },
                new Country { CountryId =90, Name = "Kuwait", Code = "KW", Continent = "Asia", Capital = "Kuwait City", Currency = "KWD", Language = "Arabic", FlagUrl = "https://flagcdn.com/kw.svg" },
                new Country { CountryId =91, Name = "Kyrgyzstan", Code = "KG", Continent = "Asia", Capital = "Bishkek", Currency = "KGS", Language = "Kyrgyz/Russian", FlagUrl = "https://flagcdn.com/kg.svg" },
                new Country { CountryId =92, Name = "Laos", Code = "LA", Continent = "Asia", Capital = "Vientiane", Currency = "LAK", Language = "Lao", FlagUrl = "https://flagcdn.com/la.svg" },
                new Country { CountryId =93, Name = "Latvia", Code = "LV", Continent = "Europe", Capital = "Riga", Currency = "EUR", Language = "Latvian", FlagUrl = "https://flagcdn.com/lv.svg" },
                new Country { CountryId =94, Name = "Lebanon", Code = "LB", Continent = "Asia", Capital = "Beirut", Currency = "LBP", Language = "Arabic", FlagUrl = "https://flagcdn.com/lb.svg" },
                new Country { CountryId =95, Name = "Lesotho", Code = "LS", Continent = "Africa", Capital = "Maseru", Currency = "LSL", Language = "English/Sesotho", FlagUrl = "https://flagcdn.com/ls.svg" },
                new Country { CountryId =96, Name = "Liberia", Code = "LR", Continent = "Africa", Capital = "Monrovia", Currency = "LRD", Language = "English", FlagUrl = "https://flagcdn.com/lr.svg" },
                new Country { CountryId =97, Name = "Libya", Code = "LY", Continent = "Africa", Capital = "Tripoli", Currency = "LYD", Language = "Arabic", FlagUrl = "https://flagcdn.com/ly.svg" },
                new Country { CountryId =98, Name = "Liechtenstein", Code = "LI", Continent = "Europe", Capital = "Vaduz", Currency = "CHF", Language = "German", FlagUrl = "https://flagcdn.com/li.svg" },
                new Country { CountryId =99, Name = "Lithuania", Code = "LT", Continent = "Europe", Capital = "Vilnius", Currency = "EUR", Language = "Lithuanian", FlagUrl = "https://flagcdn.com/lt.svg" },
                new Country { CountryId =100, Name = "Luxembourg", Code = "LU", Continent = "Europe", Capital = "Luxembourg", Currency = "EUR", Language = "Luxembourgish/French/German", FlagUrl = "https://flagcdn.com/lu.svg" }
            );

            // Seed Countries (ISO 3166-1 alpha-2, exhaustive, batch 3)
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId =101, Name = "Madagascar", Code = "MG", Continent = "Africa", Capital = "Antananarivo", Currency = "MGA", Language = "Malagasy/French", FlagUrl = "https://flagcdn.com/mg.svg" },
                new Country { CountryId =102, Name = "Malawi", Code = "MW", Continent = "Africa", Capital = "Lilongwe", Currency = "MWK", Language = "English/Chichewa", FlagUrl = "https://flagcdn.com/mw.svg" },
                new Country { CountryId =103, Name = "Malaysia", Code = "MY", Continent = "Asia", Capital = "Kuala Lumpur", Currency = "MYR", Language = "Malay", FlagUrl = "https://flagcdn.com/my.svg" },
                new Country { CountryId =104, Name = "Maldives", Code = "MV", Continent = "Asia", Capital = "Malé", Currency = "MVR", Language = "Dhivehi", FlagUrl = "https://flagcdn.com/mv.svg" },
                new Country { CountryId =105, Name = "Mali", Code = "ML", Continent = "Africa", Capital = "Bamako", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/ml.svg" },
                new Country { CountryId =106, Name = "Malta", Code = "MT", Continent = "Europe", Capital = "Valletta", Currency = "EUR", Language = "Maltese/English", FlagUrl = "https://flagcdn.com/mt.svg" },
                new Country { CountryId =107, Name = "Marshall Islands", Code = "MH", Continent = "Oceania", Capital = "Majuro", Currency = "USD", Language = "Marshallese/English", FlagUrl = "https://flagcdn.com/mh.svg" },
                new Country { CountryId =108, Name = "Mauritania", Code = "MR", Continent = "Africa", Capital = "Nouakchott", Currency = "MRU", Language = "Arabic", FlagUrl = "https://flagcdn.com/mr.svg" },
                new Country { CountryId =109, Name = "Mauritius", Code = "MU", Continent = "Africa", Capital = "Port Louis", Currency = "MUR", Language = "English/French", FlagUrl = "https://flagcdn.com/mu.svg" },
                new Country { CountryId =110, Name = "Mexico", Code = "MX", Continent = "North America", Capital = "Mexico City", Currency = "MXN", Language = "Spanish", FlagUrl = "https://flagcdn.com/mx.svg" },
                new Country { CountryId =111, Name = "Micronesia", Code = "FM", Continent = "Oceania", Capital = "Palikir", Currency = "USD", Language = "English", FlagUrl = "https://flagcdn.com/fm.svg" },
                new Country { CountryId =112, Name = "Moldova", Code = "MD", Continent = "Europe", Capital = "Chisinau", Currency = "MDL", Language = "Romanian", FlagUrl = "https://flagcdn.com/md.svg" },
                new Country { CountryId =113, Name = "Monaco", Code = "MC", Continent = "Europe", Capital = "Monaco", Currency = "EUR", Language = "French", FlagUrl = "https://flagcdn.com/mc.svg" },
                new Country { CountryId =114, Name = "Mongolia", Code = "MN", Continent = "Asia", Capital = "Ulaanbaatar", Currency = "MNT", Language = "Mongolian", FlagUrl = "https://flagcdn.com/mn.svg" },
                new Country { CountryId =115, Name = "Montenegro", Code = "ME", Continent = "Europe", Capital = "Podgorica", Currency = "EUR", Language = "Montenegrin", FlagUrl = "https://flagcdn.com/me.svg" },
                new Country { CountryId =116, Name = "Morocco", Code = "MA", Continent = "Africa", Capital = "Rabat", Currency = "MAD", Language = "Arabic/Berber", FlagUrl = "https://flagcdn.com/ma.svg" },
                new Country { CountryId =117, Name = "Mozambique", Code = "MZ", Continent = "Africa", Capital = "Maputo", Currency = "MZN", Language = "Portuguese", FlagUrl = "https://flagcdn.com/mz.svg" },
                new Country { CountryId =118, Name = "Myanmar", Code = "MM", Continent = "Asia", Capital = "Naypyidaw", Currency = "MMK", Language = "Burmese", FlagUrl = "https://flagcdn.com/mm.svg" },
                new Country { CountryId =119, Name = "Namibia", Code = "NA", Continent = "Africa", Capital = "Windhoek", Currency = "NAD", Language = "English", FlagUrl = "https://flagcdn.com/na.svg" },
                new Country { CountryId =120, Name = "Nauru", Code = "NR", Continent = "Oceania", Capital = "Yaren", Currency = "AUD", Language = "Nauruan/English", FlagUrl = "https://flagcdn.com/nr.svg" },
                new Country { CountryId =121, Name = "Nepal", Code = "NP", Continent = "Asia", Capital = "Kathmandu", Currency = "NPR", Language = "Nepali", FlagUrl = "https://flagcdn.com/np.svg" },
                new Country { CountryId =122, Name = "Netherlands", Code = "NL", Continent = "Europe", Capital = "Amsterdam", Currency = "EUR", Language = "Dutch", FlagUrl = "https://flagcdn.com/nl.svg" },
                new Country { CountryId =123, Name = "New Zealand", Code = "NZ", Continent = "Oceania", Capital = "Wellington", Currency = "NZD", Language = "English/Māori", FlagUrl = "https://flagcdn.com/nz.svg" },
                new Country { CountryId =124, Name = "Nicaragua", Code = "NI", Continent = "North America", Capital = "Managua", Currency = "NIO", Language = "Spanish", FlagUrl = "https://flagcdn.com/ni.svg" },
                new Country { CountryId =125, Name = "Niger", Code = "NE", Continent = "Africa", Capital = "Niamey", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/ne.svg" },
                new Country { CountryId =126, Name = "Nigeria", Code = "NG", Continent = "Africa", Capital = "Abuja", Currency = "NGN", Language = "English", FlagUrl = "https://flagcdn.com/ng.svg" },
                new Country { CountryId =127, Name = "North Korea", Code = "KP", Continent = "Asia", Capital = "Pyongyang", Currency = "KPW", Language = "Korean", FlagUrl = "https://flagcdn.com/kp.svg" },
                new Country { CountryId =128, Name = "North Macedonia", Code = "MK", Continent = "Europe", Capital = "Skopje", Currency = "MKD", Language = "Macedonian", FlagUrl = "https://flagcdn.com/mk.svg" },
                new Country { CountryId =129, Name = "Norway", Code = "NO", Continent = "Europe", Capital = "Oslo", Currency = "NOK", Language = "Norwegian", FlagUrl = "https://flagcdn.com/no.svg" },
                new Country { CountryId =130, Name = "Oman", Code = "OM", Continent = "Asia", Capital = "Muscat", Currency = "OMR", Language = "Arabic", FlagUrl = "https://flagcdn.com/om.svg" },
                new Country { CountryId =131, Name = "Pakistan", Code = "PK", Continent = "Asia", Capital = "Islamabad", Currency = "PKR", Language = "Urdu/English", FlagUrl = "https://flagcdn.com/pk.svg" },
                new Country { CountryId =132, Name = "Palau", Code = "PW", Continent = "Oceania", Capital = "Ngerulmud", Currency = "USD", Language = "Palauan/English", FlagUrl = "https://flagcdn.com/pw.svg" },
                new Country { CountryId =133, Name = "Palestine", Code = "PS", Continent = "Asia", Capital = "East Jerusalem", Currency = "ILS", Language = "Arabic", FlagUrl = "https://flagcdn.com/ps.svg" },
                new Country { CountryId =134, Name = "Panama", Code = "PA", Continent = "North America", Capital = "Panama City", Currency = "PAB/USD", Language = "Spanish", FlagUrl = "https://flagcdn.com/pa.svg" },
                new Country { CountryId =135, Name = "Papua New Guinea", Code = "PG", Continent = "Oceania", Capital = "Port Moresby", Currency = "PGK", Language = "English/Hiri Motu/Tok Pisin", FlagUrl = "https://flagcdn.com/pg.svg" },
                new Country { CountryId =136, Name = "Paraguay", Code = "PY", Continent = "South America", Capital = "Asunción", Currency = "PYG", Language = "Spanish/Guarani", FlagUrl = "https://flagcdn.com/py.svg" },
                new Country { CountryId =137, Name = "Peru", Code = "PE", Continent = "South America", Capital = "Lima", Currency = "PEN", Language = "Spanish/Quechua/Aymara", FlagUrl = "https://flagcdn.com/pe.svg" },
                new Country { CountryId =138, Name = "Philippines", Code = "PH", Continent = "Asia", Capital = "Manila", Currency = "PHP", Language = "Filipino/English", FlagUrl = "https://flagcdn.com/ph.svg" },
                new Country { CountryId =139, Name = "Poland", Code = "PL", Continent = "Europe", Capital = "Warsaw", Currency = "PLN", Language = "Polish", FlagUrl = "https://flagcdn.com/pl.svg" },
                new Country { CountryId =140, Name = "Portugal", Code = "PT", Continent = "Europe", Capital = "Lisbon", Currency = "EUR", Language = "Portuguese", FlagUrl = "https://flagcdn.com/pt.svg" },
                new Country { CountryId =141, Name = "Qatar", Code = "QA", Continent = "Asia", Capital = "Doha", Currency = "QAR", Language = "Arabic", FlagUrl = "https://flagcdn.com/qa.svg" },
                new Country { CountryId =142, Name = "Romania", Code = "RO", Continent = "Europe", Capital = "Bucharest", Currency = "RON", Language = "Romanian", FlagUrl = "https://flagcdn.com/ro.svg" },
                new Country { CountryId =143, Name = "Russia", Code = "RU", Continent = "Europe/Asia", Capital = "Moscow", Currency = "RUB", Language = "Russian", FlagUrl = "https://flagcdn.com/ru.svg" },
                new Country { CountryId =144, Name = "Rwanda", Code = "RW", Continent = "Africa", Capital = "Kigali", Currency = "RWF", Language = "Kinyarwanda/French/English", FlagUrl = "https://flagcdn.com/rw.svg" },
                new Country { CountryId =145, Name = "Saint Kitts and Nevis", Code = "KN", Continent = "North America", Capital = "Basseterre", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/kn.svg" },
                new Country { CountryId =146, Name = "Saint Lucia", Code = "LC", Continent = "North America", Capital = "Castries", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/lc.svg" },
                new Country { CountryId =147, Name = "Saint Vincent and the Grenadines", Code = "VC", Continent = "North America", Capital = "Kingstown", Currency = "XCD", Language = "English", FlagUrl = "https://flagcdn.com/vc.svg" },
                new Country { CountryId =148, Name = "Samoa", Code = "WS", Continent = "Oceania", Capital = "Apia", Currency = "WST", Language = "Samoan/English", FlagUrl = "https://flagcdn.com/ws.svg" },
                new Country { CountryId =149, Name = "San Marino", Code = "SM", Continent = "Europe", Capital = "San Marino", Currency = "EUR", Language = "Italian", FlagUrl = "https://flagcdn.com/sm.svg" },
                new Country { CountryId =150, Name = "Sao Tome and Principe", Code = "ST", Continent = "Africa", Capital = "São Tomé", Currency = "STN", Language = "Portuguese", FlagUrl = "https://flagcdn.com/st.svg" }
            );

            // Seed Countries (ISO 3166-1 alpha-2, exhaustive, final batch)
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId =151, Name = "Saudi Arabia", Code = "SA", Continent = "Asia", Capital = "Riyadh", Currency = "SAR", Language = "Arabic", FlagUrl = "https://flagcdn.com/sa.svg" },
                new Country { CountryId =152, Name = "Senegal", Code = "SN", Continent = "Africa", Capital = "Dakar", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/sn.svg" },
                new Country { CountryId =153, Name = "Serbia", Code = "RS", Continent = "Europe", Capital = "Belgrade", Currency = "RSD", Language = "Serbian", FlagUrl = "https://flagcdn.com/rs.svg" },
                new Country { CountryId =154, Name = "Seychelles", Code = "SC", Continent = "Africa", Capital = "Victoria", Currency = "SCR", Language = "Seychellois Creole/English/French", FlagUrl = "https://flagcdn.com/sc.svg" },
                new Country { CountryId =155, Name = "Sierra Leone", Code = "SL", Continent = "Africa", Capital = "Freetown", Currency = "SLL", Language = "English", FlagUrl = "https://flagcdn.com/sl.svg" },
                new Country { CountryId =156, Name = "Singapore", Code = "SG", Continent = "Asia", Capital = "Singapore", Currency = "SGD", Language = "English/Malay/Mandarin/Tamil", FlagUrl = "https://flagcdn.com/sg.svg" },
                new Country { CountryId =157, Name = "Slovakia", Code = "SK", Continent = "Europe", Capital = "Bratislava", Currency = "EUR", Language = "Slovak", FlagUrl = "https://flagcdn.com/sk.svg" },
                new Country { CountryId =158, Name = "Slovenia", Code = "SI", Continent = "Europe", Capital = "Ljubljana", Currency = "EUR", Language = "Slovene", FlagUrl = "https://flagcdn.com/si.svg" },
                new Country { CountryId =159, Name = "Solomon Islands", Code = "SB", Continent = "Oceania", Capital = "Honiara", Currency = "SBD", Language = "English", FlagUrl = "https://flagcdn.com/sb.svg" },
                new Country { CountryId =160, Name = "Somalia", Code = "SO", Continent = "Africa", Capital = "Mogadishu", Currency = "SOS", Language = "Somali/Arabic", FlagUrl = "https://flagcdn.com/so.svg" },
                new Country { CountryId =161, Name = "South Africa", Code = "ZA", Continent = "Africa", Capital = "Pretoria", Currency = "ZAR", Language = "English/Afrikaans/Zulu", FlagUrl = "https://flagcdn.com/za.svg" },
                new Country { CountryId =162, Name = "South Korea", Code = "KR", Continent = "Asia", Capital = "Seoul", Currency = "KRW", Language = "Korean", FlagUrl = "https://flagcdn.com/kr.svg" },
                new Country { CountryId =163, Name = "South Sudan", Code = "SS", Continent = "Africa", Capital = "Juba", Currency = "SSP", Language = "English", FlagUrl = "https://flagcdn.com/ss.svg" },
                new Country { CountryId =164, Name = "Spain", Code = "ES", Continent = "Europe", Capital = "Madrid", Currency = "EUR", Language = "Spanish", FlagUrl = "https://flagcdn.com/es.svg" },
                new Country { CountryId =165, Name = "Sri Lanka", Code = "LK", Continent = "Asia", Capital = "Sri Jayawardenepura Kotte", Currency = "LKR", Language = "Sinhala/Tamil", FlagUrl = "https://flagcdn.com/lk.svg" },
                new Country { CountryId =166, Name = "Sudan", Code = "SD", Continent = "Africa", Capital = "Khartoum", Currency = "SDG", Language = "Arabic/English", FlagUrl = "https://flagcdn.com/sd.svg" },
                new Country { CountryId =167, Name = "Suriname", Code = "SR", Continent = "South America", Capital = "Paramaribo", Currency = "SRD", Language = "Dutch", FlagUrl = "https://flagcdn.com/sr.svg" },
                new Country { CountryId =168, Name = "Sweden", Code = "SE", Continent = "Europe", Capital = "Stockholm", Currency = "SEK", Language = "Swedish", FlagUrl = "https://flagcdn.com/se.svg" },
                new Country { CountryId =169, Name = "Switzerland", Code = "CH", Continent = "Europe", Capital = "Bern", Currency = "CHF", Language = "German/French/Italian/Romansh", FlagUrl = "https://flagcdn.com/ch.svg" },
                new Country { CountryId =170, Name = "Syria", Code = "SY", Continent = "Asia", Capital = "Damascus", Currency = "SYP", Language = "Arabic", FlagUrl = "https://flagcdn.com/sy.svg" },
                new Country { CountryId =171, Name = "Tajikistan", Code = "TJ", Continent = "Asia", Capital = "Dushanbe", Currency = "TJS", Language = "Tajik", FlagUrl = "https://flagcdn.com/tj.svg" },
                new Country { CountryId =172, Name = "Tanzania", Code = "TZ", Continent = "Africa", Capital = "Dodoma", Currency = "TZS", Language = "Swahili/English", FlagUrl = "https://flagcdn.com/tz.svg" },
                new Country { CountryId =173, Name = "Thailand", Code = "TH", Continent = "Asia", Capital = "Bangkok", Currency = "THB", Language = "Thai", FlagUrl = "https://flagcdn.com/th.svg" },
                new Country { CountryId =174, Name = "Timor-Leste", Code = "TL", Continent = "Asia", Capital = "Dili", Currency = "USD", Language = "Tetum/Portuguese", FlagUrl = "https://flagcdn.com/tl.svg" },
                new Country { CountryId =175, Name = "Togo", Code = "TG", Continent = "Africa", Capital = "Lomé", Currency = "XOF", Language = "French", FlagUrl = "https://flagcdn.com/tg.svg" },
                new Country { CountryId =176, Name = "Tonga", Code = "TO", Continent = "Oceania", Capital = "Nukuʻalofa", Currency = "TOP", Language = "Tongan/English", FlagUrl = "https://flagcdn.com/to.svg" },
                new Country { CountryId =177, Name = "Trinidad and Tobago", Code = "TT", Continent = "North America", Capital = "Port of Spain", Currency = "TTD", Language = "English", FlagUrl = "https://flagcdn.com/tt.svg" },
                new Country { CountryId =178, Name = "Tunisia", Code = "TN", Continent = "Africa", Capital = "Tunis", Currency = "TND", Language = "Arabic", FlagUrl = "https://flagcdn.com/tn.svg" },
                new Country { CountryId =179, Name = "Turkey", Code = "TR", Continent = "Europe/Asia", Capital = "Ankara", Currency = "TRY", Language = "Turkish", FlagUrl = "https://flagcdn.com/tr.svg" },
                new Country { CountryId =180, Name = "Turkmenistan", Code = "TM", Continent = "Asia", Capital = "Ashgabat", Currency = "TMT", Language = "Turkmen", FlagUrl = "https://flagcdn.com/tm.svg" },
                new Country { CountryId =181, Name = "Tuvalu", Code = "TV", Continent = "Oceania", Capital = "Funafuti", Currency = "AUD", Language = "Tuvaluan/English", FlagUrl = "https://flagcdn.com/tv.svg" },
                new Country { CountryId =182, Name = "Uganda", Code = "UG", Continent = "Africa", Capital = "Kampala", Currency = "UGX", Language = "English/Swahili", FlagUrl = "https://flagcdn.com/ug.svg" },
                new Country { CountryId =183, Name = "Ukraine", Code = "UA", Continent = "Europe", Capital = "Kyiv", Currency = "UAH", Language = "Ukrainian", FlagUrl = "https://flagcdn.com/ua.svg" },
                new Country { CountryId =184, Name = "United Arab Emirates", Code = "AE", Continent = "Asia", Capital = "Abu Dhabi", Currency = "AED", Language = "Arabic", FlagUrl = "https://flagcdn.com/ae.svg" },
                new Country { CountryId =185, Name = "United Kingdom", Code = "GB", Continent = "Europe", Capital = "London", Currency = "GBP", Language = "English", FlagUrl = "https://flagcdn.com/gb.svg" },
                new Country { CountryId =186, Name = "United States", Code = "US", Continent = "North America", Capital = "Washington, D.C.", Currency = "USD", Language = "English", FlagUrl = "https://flagcdn.com/us.svg" },
                new Country { CountryId =187, Name = "Uruguay", Code = "UY", Continent = "South America", Capital = "Montevideo", Currency = "UYU", Language = "Spanish", FlagUrl = "https://flagcdn.com/uy.svg" },
                new Country { CountryId =188, Name = "Uzbekistan", Code = "UZ", Continent = "Asia", Capital = "Tashkent", Currency = "UZS", Language = "Uzbek", FlagUrl = "https://flagcdn.com/uz.svg" },
                new Country { CountryId =189, Name = "Vanuatu", Code = "VU", Continent = "Oceania", Capital = "Port Vila", Currency = "VUV", Language = "Bislama/English/French", FlagUrl = "https://flagcdn.com/vu.svg" },
                new Country { CountryId =190, Name = "Vatican City", Code = "VA", Continent = "Europe", Capital = "Vatican City", Currency = "EUR", Language = "Italian/Latin", FlagUrl = "https://flagcdn.com/va.svg" },
                new Country { CountryId =191, Name = "Venezuela", Code = "VE", Continent = "South America", Capital = "Caracas", Currency = "VES", Language = "Spanish", FlagUrl = "https://flagcdn.com/ve.svg" },
                new Country { CountryId =192, Name = "Vietnam", Code = "VN", Continent = "Asia", Capital = "Hanoi", Currency = "VND", Language = "Vietnamese", FlagUrl = "https://flagcdn.com/vn.svg" },
                new Country { CountryId =193, Name = "Yemen", Code = "YE", Continent = "Asia", Capital = "Sana'a", Currency = "YER", Language = "Arabic", FlagUrl = "https://flagcdn.com/ye.svg" },
                new Country { CountryId =194, Name = "Zambia", Code = "ZM", Continent = "Africa", Capital = "Lusaka", Currency = "ZMW", Language = "English", FlagUrl = "https://flagcdn.com/zm.svg" },
                new Country { CountryId =195, Name = "Zimbabwe", Code = "ZW", Continent = "Africa", Capital = "Harare", Currency = "ZWL", Language = "English/Shona/Sindebele", FlagUrl = "https://flagcdn.com/zw.svg" }
            );

        }
    }
}
