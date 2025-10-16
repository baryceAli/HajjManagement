using CoreBusiness.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoreBusiness.Utils.PermissionHelper;

namespace CoreBusiness.Dtos
{
    public class RolePermissions
    {
        public Role Role { get; set; }
        public List<PermissionGroup> Permissions { get; set; } = new();
    }
}
