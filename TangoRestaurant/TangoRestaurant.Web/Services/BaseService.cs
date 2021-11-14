using Newtonsoft.Json;
using System.Net.Http.Headers;
using TangoRestaurant.Web.Models;
using TangoRestaurant.Web.Models.Dto;

namespace TangoRestaurant.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto ResponseModel { get; set; }
        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseModel = new ResponseDto();
            HttpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("TangoApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                        System.Text.Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                   client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }

                HttpResponseMessage apiResponse = null;

                switch (apiRequest.ApiType)
                {
                    case ServiceLocator.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ServiceLocator.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ServiceLocator.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                   default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch(Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> {  ex.Message },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
