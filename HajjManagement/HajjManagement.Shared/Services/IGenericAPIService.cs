using CoreBusiness.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services
{
    public interface IGenericAPIService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<AuthResponse> LoginAsync(T entity);
        //public async Task<T> AddAsync(string additionalURLPart, T entity)
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
