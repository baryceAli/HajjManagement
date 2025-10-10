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
        Task<IEnumerable<T>> GetAllAsync(string version = "v1");
        Task<T> GetByIdAsync(int id, string version = "v1");
        Task<T> AddAsync(T entity, string version = "v1");
        Task<AuthResponse> LoginAsync(T entity, string version = "v1", string endPoint = "");
        //public async Task<T> AddAsync(string additionalURLPart, T entity)
        Task<T> UpdateAsync(T entity, string version = "v1");
        Task<bool> DeleteAsync(int id, string version = "v1");



        //Task<IEnumerable<T>> GetAllAsync();
        //Task<T> GetByIdAsync(int id);
        //Task<T> AddAsync(T entity);
        //Task<AuthResponse> LoginAsync(T entity);
        ////public async Task<T> AddAsync(string additionalURLPart, T entity)
        //Task<T> UpdateAsync(T entity);
        //Task<bool> DeleteAsync(int id);
    }
}
