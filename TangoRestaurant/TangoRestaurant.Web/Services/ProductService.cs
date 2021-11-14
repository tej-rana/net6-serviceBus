using TangoRestaurant.Web.Models;
using TangoRestaurant.Web.Models.Dto;

namespace TangoRestaurant.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.POST,
                Data = productDto,
                ApiUrl = ServiceLocator.ProductApiBase + "/api/products",
                AccessToken = string.Empty
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.DELETE,
                ApiUrl = ServiceLocator.ProductApiBase + "/api/products/" + id,
                AccessToken = string.Empty
            });
        }

        public async Task<T> GetProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.GET,
                ApiUrl = ServiceLocator.ProductApiBase + "/api/products",
                AccessToken = string.Empty
            });
        }

        public async Task<T> GetProductsByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.GET,
                ApiUrl = ServiceLocator.ProductApiBase + "/api/products/" + id,
                AccessToken = string.Empty
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.PUT,
                Data = productDto,
                ApiUrl = ServiceLocator.ProductApiBase + "/api/products",
                AccessToken = string.Empty
            });
        }
    }
}
