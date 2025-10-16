using System.Collections.Generic;
using System.Linq;

namespace CoreBusiness.Utils
{
    public static class PermissionHelperExtensions
    {
        /// <summary>
        /// Returns all permissions with their Value set to true if the user has them.
        /// </summary>
        public static List<PermissionGroup>MarkUserPermissions(
                                                                List<PermissionGroup> allPermissions,
                                                                IEnumerable<string> userPermissions)
        {
            // ✅ Use HashSet for O(1) lookups
            var userPermissionSet = userPermissions.ToHashSet(System.StringComparer.OrdinalIgnoreCase);

            List<PermissionGroup> updatedPermissionGroups = new();
            

            foreach (var group in allPermissions)
            {
                // Use Select to efficiently build the updated permission list
                var updatedPermissions = group.Permissions.Select(p => new PermissionItem
                {
                    Key = p.Key,
                    Permission = p.Permission,
                    Value = userPermissionSet.Contains(p.Permission)
                }).ToList();

                updatedPermissionGroups.Add(new PermissionGroup
                {
                    Key = group.Key,
                    Ar = group.Ar,
                    En = group.En,
                    Permissions = updatedPermissions
                });

                return updatedPermissionGroups;
            }
            return updatedPermissionGroups;
        }
    }
}