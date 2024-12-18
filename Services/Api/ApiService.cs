using System.Net.Http;
using System.Net.Http.Headers;

namespace LojinhaDaPaulinha.Services.Api
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseAddress;

        public ApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseAddress = configuration["ApiSettings:BaseUrl"];
            Console.WriteLine($"BaseAddress: {_apiBaseAddress}");

            ApiServiceConfiguration();
        }

        private void ApiServiceConfiguration(string token = null)
        {
            // Headers.
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Add Authorization header if a token is provided.
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Set timeout for the request.
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<ApiResponse> GetDataAsync(string apiEndpoint, string token = null)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            HttpResponseMessage httpResponseMessage;

            // Try Get.
            try
            {
                // Add token to the Authorization header if provided
                if (!string.IsNullOrWhiteSpace(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                    httpResponseMessage = await _httpClient.GetAsync(_apiBaseAddress + apiEndpoint);
            }
            catch (HttpRequestException ex)
            {
                // Log and return a failure response for HTTP-related exceptions
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Content = $"HTTP Request Error: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Content = $"Unexpected Error: {ex.Message}"
                };
            }

            return new ApiResponse
            {
                IsSuccess = httpResponseMessage.IsSuccessStatusCode,
                StatusCode = (int)httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync(),
            };
        }

        public async Task<ApiResponse> PostDataAsync(string apiEndpoint, object value)
        {
            HttpResponseMessage httpResponseMessage;

            // Try Post.
            try
            {
                httpResponseMessage = await _httpClient.PostAsJsonAsync(_apiBaseAddress + apiEndpoint, value);
            }
            catch
            {
                return ApiErrorResponse.ApiCallFailed;
            }

            return new ApiResponse
            {
                IsSuccess = httpResponseMessage.IsSuccessStatusCode,
                StatusCode = (int)httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync(),
            };
        }

        public async Task<ApiResponse> PutDataAsync(string apiEndpoint, object value)
        {
            HttpResponseMessage httpResponseMessage;

            // Try Put.
            try
            {
                httpResponseMessage = await _httpClient.PutAsJsonAsync(_apiBaseAddress + apiEndpoint, value);
            }
            catch
            {
                return ApiErrorResponse.ApiCallFailed;
            }

            return new ApiResponse
            {
                IsSuccess = httpResponseMessage.IsSuccessStatusCode,
                StatusCode = (int)httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync(),
            };
        }

        public async Task<ApiResponse> DeleteDataAsync(string apiEndpoint)
        {
            HttpResponseMessage httpResponseMessage;

            // Try Delete.
            try
            {
                httpResponseMessage = await _httpClient.DeleteAsync(_apiBaseAddress + apiEndpoint);
            }
            catch
            {
                return ApiErrorResponse.ApiCallFailed;
            }

            return new ApiResponse
            {
                IsSuccess = httpResponseMessage.IsSuccessStatusCode,
                StatusCode = (int)httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync(),
            };
        }
    }
}
