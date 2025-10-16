namespace CoreBusiness.Utils
{
    public class PermissionGroup
    {
        public string Key { get; set; } = string.Empty;
        public string Ar { get; set; } = string.Empty;
        public string En { get; set; } = string.Empty;
        public List<PermissionItem> Permissions { get; set; } = new();
    }
}
