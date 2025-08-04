using CoreBusiness;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICountryService : IGenericService<Country> { }    
    public interface IAdministrativeDivisionTypeService : IGenericService<AdministrativeDivisionType> { }
    public interface IAdministrativeDivisionService : IGenericService<AdministrativeDivision> { }
    public interface IContractService : IGenericService<Contract> { }
    public interface IBagService : IGenericService<Bag> { }
    public interface IHotelService : IGenericService<Hotel>{}
    public interface IGuestService : IGenericService<Guest> { }
    public interface ILogService: IGenericService<Log> { }
    public interface IUserService: IGenericService<User> { }
    public interface IRoleService: IGenericService<Role> { }
    //public interface ITempUserRoleService : IGenericService<TempUserRole> { }
    //public interface IGuest : IGenericService<Guest> { }





}
