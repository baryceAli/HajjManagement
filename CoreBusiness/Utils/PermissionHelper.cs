using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CoreBusiness.Utils
{
    public static class PermissionHelper
    {
        public static List<string> GetAllPermissions()
        {
            var permissions = new List<string>();

            // Get all nested types (like AdministrativeDivision, Hotel, etc.)
            var nestedTypes = typeof(Permissions).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);

            foreach (var type in nestedTypes)
            {
                // Get all constant string fields inside each nested type
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
    }
}
