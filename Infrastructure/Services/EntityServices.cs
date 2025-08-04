
using CoreBusiness;
using Infrastructure.Interfaces;
using Infrastructure.Plugin.Datastore.SQLServer;

namespace Infrastructure.Services
{
    public class CountryService : GenericService<Country>, ICountryService
    {
        public CountryService(ApplicationDbContext context) : base(context) { }
    }
    public class AdministrativeDivisionTypeService : GenericService<AdministrativeDivisionType>, IAdministrativeDivisionTypeService
    {
        public AdministrativeDivisionTypeService(ApplicationDbContext context) : base(context) { }
    }
    public class AdministrativeDivisionService : GenericService<AdministrativeDivision>, IAdministrativeDivisionService
    {
        public AdministrativeDivisionService(ApplicationDbContext context) : base(context) { }
    }
    public class ContractService : GenericService<Contract>, IContractService
    {
        public ContractService(ApplicationDbContext context) : base(context) { }
    }
    public class BagService : GenericService<Bag>, IBagService
    {
        public BagService(ApplicationDbContext context) : base(context) { }
    }
    public class HotelService : GenericService<Hotel>, IHotelService
    {
        public HotelService(ApplicationDbContext context) : base(context) { }
    }
    
    public class GuestService : GenericService<Guest>, IGuestService
    {
        public GuestService(ApplicationDbContext context) : base(context) { }
    }
    public class LogService:GenericService<Log>, ILogService
    {
        public LogService(ApplicationDbContext context) : base(context) { }
    }


    public class UserService : GenericService<User>, IUserService
    {
        public UserService(ApplicationDbContext context) : base(context) { }
    }
    public class RoleService : GenericService<Role>, IRoleService
    {
        public RoleService(ApplicationDbContext context) : base(context) { }
    }
    //public class TempUserRoleService : GenericService<TempUserRole>, ITempUserRoleService
    //{
    //    public TempUserRoleService(ApplicationDbContext context) : base(context) { }
    //}
}
