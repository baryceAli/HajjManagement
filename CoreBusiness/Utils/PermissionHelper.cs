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

        public static List<PermissionGroup> GetAllPermissionsDetailed()
        {
            var result = new List<PermissionGroup>();
            var nestedTypes = typeof(Permissions).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);

            foreach (var type in nestedTypes)
            {
                var arMethod = type.GetMethod("Ar", BindingFlags.Public | BindingFlags.Static);
                var enMethod = type.GetMethod("En", BindingFlags.Public | BindingFlags.Static);

                var arName = arMethod?.Invoke(null, null)?.ToString() ?? type.Name;
                var enName = enMethod?.Invoke(null, null)?.ToString() ?? type.Name;

                var group = new PermissionGroup
                {
                    Key = type.Name,
                    Ar = arName,
                    En = enName,
                };

                var permissionFields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                    .Where(f => f.FieldType == typeof(string) && f.IsLiteral && !f.IsInitOnly);

                foreach (var field in permissionFields)
                {
                    string permissionName = field.GetRawConstantValue()?.ToString()!;
                    string valueFieldName = field.Name + "Value";

                    var valueField = type.GetField(valueFieldName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                    bool defaultValue = valueField != null ? (bool)valueField.GetRawConstantValue()! : false;

                    group.Permissions.Add(new PermissionItem
                    {
                        Key = type.Name,
                        Permission = permissionName,
                        Value = defaultValue
                    });
                }

                result.Add(group);
            }

            return result;
        }
    }
}
