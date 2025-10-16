using CoreBusiness.Dtos;
using HajjManagement.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

        public async Task<TResponse> GenericEndPointAsync<TResponse>(
                                            object requestData = null,
                                            string version = "v1",
                                            string controller = "",
                                            string endpoint = "",
                                            HttpMethod method = null
            )
        {

            try
            {
                var client = GetClient();
                SetAuthHeader(client);

                if (string.IsNullOrWhiteSpace(controller))
                    throw new ArgumentException("Controller name cannot be empty.", nameof(controller));

                if (string.IsNullOrWhiteSpace(endpoint))
                    throw new ArgumentException("Endpoint cannot be empty.", nameof(endpoint));

                var url =(endpoint=="?" )? $"api/{version}/{controller}": $"api/{version}/{controller}/{endpoint}";
                HttpResponseMessage response;

                method ??= HttpMethod.Post; // default is POST

                // 🔹 Handle common HTTP methods
                if (method == HttpMethod.Post)
                {
                    response = await client.PostAsJsonAsync(url, requestData);
                }
                else if (method == HttpMethod.Put)
                {
                    response = await client.PutAsJsonAsync(url, requestData);
                }
                else if (method == HttpMethod.Get)
                {
                    if (requestData != null)
                    {
                        var query = string.Join("&", requestData.GetType().GetProperties()
                            .Select(p => $"{p.Name}={Uri.EscapeDataString(p.GetValue(requestData)?.ToString() ?? string.Empty)}"));
                        url += $"?{query}";
                    }
                    response = await client.GetAsync(url);
                }
                else if (method == HttpMethod.Delete)
                {
                    response = await client.DeleteAsync(url);
                }
                else
                {
                    throw new NotSupportedException($"HTTP method {method} is not supported.");
                }

                var contentType = response.Content.Headers.ContentType?.MediaType ?? "text/plain";
                var content = await response.Content.ReadAsStringAsync();

                // Throw if not success
                if (!response.IsSuccessStatusCode)
                {
                    //throw new Exception($"Request failed ({response.StatusCode}): {content}");
                }

                // 🔹 Handle empty response
                if (string.IsNullOrWhiteSpace(content))
                    return default!;

                // 🔹 Auto-handle based on content type
                if (contentType.Contains("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<TResponse>(
                        content,
                        new System.Text.Json.JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        })!;
                }
                else if (contentType.Contains("text/html", StringComparison.OrdinalIgnoreCase) ||
                         contentType.Contains("text/plain", StringComparison.OrdinalIgnoreCase))
                {
                    // Handle plain string or HTML
                    if (typeof(TResponse) == typeof(string))
                        return (TResponse)(object)content;

                    // Handle JSON object
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    try
                    {
                        return JsonSerializer.Deserialize<TResponse>(content, options)!;
                    }
                    catch (JsonException ex)
                    {
                        throw new Exception(
                            $"Failed to deserialize JSON from endpoint '{controller}/{endpoint}' to {typeof(TResponse).Name}: {ex.Message}\nResponse Content: {content}",
                            ex
                        );
                    }
                }

                // Unknown content type
                throw new Exception($"Unsupported content type: {contentType}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calling endpoint '{controller}/{endpoint}': {ex.Message}", ex);
            }
        }

        
    }
}
