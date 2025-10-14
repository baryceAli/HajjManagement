using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Utils
{
    public static class Permissions
    {
        public static class AdministrativeDivision
        {
            public const string View = "AdministrativeDivision.View";
            public const string Edit = "AdministrativeDivision.Edit";
            public const string Add = "AdministrativeDivision.Add";
        }

        public static class Bag
        {
            public const string View = "Bag.View";
            public const string Edit = "Bag.Edit";
            public const string Add = "Bag.Add";
        }

        public static class Contract
        {
            public const string View = "Contract.View";
            public const string Edit = "Contract.Edit";
            public const string Add = "Contract.Add";
        }

        public static class Country
        {
            public const string View = "Country.View";
            public const string Edit = "Country.Edit";
            public const string Add = "Country.Add";
        }

        public static class CounntryStructure
        {
            public const string View = "CounntryStructure.View";
            public const string Edit = "CounntryStructure.Edit";
            public const string Add = "CounntryStructure.Add";
        }

        public static class Guest
        {
            public const string View = "Guest.View";
            public const string Edit = "Guest.Edit";
            public const string Add = "Guest.Add";
        }

        public static class Hotel
        {
            public const string View = "Hotel.View";
            public const string Edit = "Hotel.Edit";
            public const string Add = "Hotel.Add";
        }

        public static class Log
        {
            public const string View = "Log.View";
            public const string Edit = "Log.Edit";
            public const string Add = "Log.Add";
        }

        public static class Role
        {
            public const string View = "Role.View";
            public const string Edit = "Role.Edit";
            public const string Add = "Role.Add";
        }
        public static class User
        {
            public const string View = "User.View";
            public const string Edit = "User.Edit";
            public const string Add = "User.Add";
        }
    }

}
