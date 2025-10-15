using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CoreBusiness.Utils
{
    public static class PermissionHelper
    {
        /// <summary>
        /// Gets all defined permission strings like "User.View", "User.Add", etc.
        /// </summary>
        public static List<string> GetAllPermissions()
        {
            var permissions = new List<string>();

            var nestedTypes = typeof(Permissions).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);

            foreach (var type in nestedTypes)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                 .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string));

                foreach (var field in fields)
                {
                    var value = field.GetRawConstantValue()?.ToString();
                    if (!string.IsNullOrEmpty(value))
                        permissions.Add(value);
                }
            }

            return permissions;
        }

        /// <summary>
        /// Gets each permission group with its Arabic & English names.
        /// Example: { Key = "AdministrativeDivision", Ar = "الهيكل الإداري", En = "Administrative Division" }
        /// </summary>
        public static List<(string Key, string Ar, string En)> GetPermissionGroups()
        {
            var result = new List<(string, string, string)>();

            var nestedTypes = typeof(Permissions).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);

            foreach (var type in nestedTypes)
            {
                try
                {
                    var arMethod = type.GetMethod("Ar", BindingFlags.Public | BindingFlags.Static);
                    var enMethod = type.GetMethod("En", BindingFlags.Public | BindingFlags.Static);

                    var arName = arMethod?.Invoke(null, null)?.ToString() ?? type.Name;
                    var enName = enMethod?.Invoke(null, null)?.ToString() ?? type.Name;

                    result.Add((type.Name, arName, enName));
                }
                catch
                {
                    // Ignore any class missing Ar()/En()
                }
            }

            return result;
        }

        /// <summary>
        /// Gets all permissions grouped by page, including Arabic & English names.
        /// </summary>
        public static List<(string Key, string Ar, string En, List<string> Permissions)> GetAllPermissionsDetailed()
        {
            var result = new List<(string, string, string, List<string>)>();

            var nestedTypes = typeof(Permissions).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);

            foreach (var type in nestedTypes)
            {
                var arMethod = type.GetMethod("Ar", BindingFlags.Public | BindingFlags.Static);
                var enMethod = type.GetMethod("En", BindingFlags.Public | BindingFlags.Static);

                var arName = arMethod?.Invoke(null, null)?.ToString() ?? type.Name;
                var enName = enMethod?.Invoke(null, null)?.ToString() ?? type.Name;

                var permissions = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                      .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
                                      .Select(f => f.GetRawConstantValue()?.ToString())
                                      .Where(v => !string.IsNullOrEmpty(v))
                                      .ToList()!;

                result.Add((type.Name, arName, enName, permissions));
            }

            return result;
        }
    }
}
