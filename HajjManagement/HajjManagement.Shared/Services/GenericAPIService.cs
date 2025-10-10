using CoreBusiness.Dtos;
using HajjManagement.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Services
{
    public class GenericAPIService<T> : IGenericAPIService<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GenericAPIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient() =>
            _httpClientFactory.CreateClient("GenericApiClient");

        private void SetAuthHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Remove("Authorization");
            if (!string.IsNullOrWhiteSpace(GlobalData.Token))
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {GlobalData.Token}");
        }

        public async Task<IEnumerable<T>> GetAllAsync(string version = "v1")
        {
            var client = GetClient();
            SetAuthHeader(client);
            return await client.GetFromJsonAsync<IEnumerable<T>>($"api/{version}/{typeof(T).Name}/") ?? new List<T>();
        }

        public async Task<T> GetByIdAsync(int id, string version = "v1")
        {
            var client = GetClient();
            SetAuthHeader(client);
            return await client.GetFromJsonAsync<T>($"api/{version}/{typeof(T).Name}/{id}");
        }

        public async Task<T> AddAsync(T entity, string version = "v1")
        {
            try
            {
                var client = GetClient();
                SetAuthHeader(client);
                var response = await client.PostAsJsonAsync($"api/{version}/{typeof(T).Name}/", entity);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<AuthResponse> LoginAsync(T entity, string version = "v1", string endPoint = "")
        {
            try
            {
                var client = GetClient();
                string entityName =string.IsNullOrWhiteSpace( endPoint) ? typeof(T).Name.ToLower():endPoint;
                var response = await client.PostAsJsonAsync($"api/{version}/{entityName}/login", entity);

                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Login failed: {response.StatusCode} - {content}");

                return await response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Login error: {ex.Message}", ex);
            }
        }

        public async Task<T> UpdateAsync(T entity, string version = "v1")
        {
            var client = GetClient();
            SetAuthHeader(client);
            var response = await client.PutAsJsonAsync($"api/{version}/{typeof(T).Name}/", entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<bool> DeleteAsync(int id, string version = "v1")
        {
            var client = GetClient();
            SetAuthHeader(client);
            var response = await client.DeleteAsync($"api/{version}/{typeof(T).Name}/{id}");
            return response.IsSuccessStatusCode;
        }
        //private readonly HttpClient _httpClient;
        //private readonly string _endpoint;

        //public GenericAPIService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //    // Extract the endpoint from the BaseAddress path
        //    _endpoint = httpClient.BaseAddress?.AbsolutePath.Trim('/') ?? throw new ArgumentNullException("BaseAddress must contain endpoint path.");
        //}

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    //var ss = GlobalData.Token;
        //    //_httpClient.DefaultRequestHeaders.Accept.Clear();
        //    //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
        //    SetAuthHeader();
        //    return await _httpClient.GetFromJsonAsync<IEnumerable<T>>($"") ?? new List<T>();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
        //    return await _httpClient.GetFromJsonAsync<T>($"{id}");

        //}

        //public async Task<T> AddAsync(T entity)
        //{
        //    try
        //    {
        //        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
        //        var response = await _httpClient.PostAsJsonAsync($"", entity);

        //        response.EnsureSuccessStatusCode();
        //        return await response.Content.ReadFromJsonAsync<T>();
        //    }
        //    catch (Exception ex)
        //    {
        //        var mes=ex.ToString();
        //        //return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        //        throw;
        //    }
        //}
        //public async Task<AuthResponse> LoginAsync(T entity)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PostAsJsonAsync($"", entity);

        //        // Read response content first
        //        var content = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            // You can throw a detailed exception or handle it
        //            throw new Exception($"Login failed: {response.StatusCode} - {content}");
        //        }
        //        //response.EnsureSuccessStatusCode();
        //        return await response.Content.ReadFromJsonAsync<AuthResponse>();
        //    }
        //    catch (Exception ex)
        //    {
        //        var mes = ex.ToString();
        //        //return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        //        throw;
        //    }
        //}

        //public async Task<T> UpdateAsync(T entity)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
        //    var response = await _httpClient.PutAsJsonAsync($"", entity);
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadFromJsonAsync<T>();
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GlobalData.Token);
        //    var response = await _httpClient.DeleteAsync($"{id}");
        //    return response.IsSuccessStatusCode;
        //}
        //private void SetAuthHeader()
        //{
        //    _httpClient.DefaultRequestHeaders.Remove("Authorization");
        //    if (!string.IsNullOrWhiteSpace(GlobalData.Token))
        //        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GlobalData.Token}");
        //}

    }
}
