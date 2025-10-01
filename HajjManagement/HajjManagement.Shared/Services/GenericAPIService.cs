using CoreBusiness.Dtos;
using HajjManagement.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services
{
    public class GenericAPIService<T> : IGenericAPIService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public GenericAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Extract the endpoint from the BaseAddress path
            _endpoint = httpClient.BaseAddress?.AbsolutePath.Trim('/') ?? throw new ArgumentNullException("BaseAddress must contain endpoint path.");
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
            return await _httpClient.GetFromJsonAsync<IEnumerable<T>>($"") ?? new List<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
            return await _httpClient.GetFromJsonAsync<T>($"{id}");

        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
                var response = await _httpClient.PostAsJsonAsync($"", entity);
                
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                var mes=ex.ToString();
                //return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                throw;
            }
        }
        public async Task<AuthResponse> LoginAsync(T entity)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"", entity);

                // Read response content first
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    // You can throw a detailed exception or handle it
                    throw new Exception($"Login failed: {response.StatusCode} - {content}");
                }
                //response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            catch (Exception ex)
            {
                var mes = ex.ToString();
                //return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
            var response = await _httpClient.PutAsJsonAsync($"", entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
            var response = await _httpClient.DeleteAsync($"{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
