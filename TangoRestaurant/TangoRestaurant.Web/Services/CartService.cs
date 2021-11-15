using TangoRestaurant.Web.Models;
using TangoRestaurant.Web.Models.Dto;

namespace TangoRestaurant.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.POST,
                Data = cartDto,
                ApiUrl = ServiceLocator.ShoppingCartApiBase + "/api/cart/AddCart",
                AccessToken = token
            });
        }

        public async Task<T> ApplyCoupon<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.POST,
                Data = cartDto,
                ApiUrl = ServiceLocator.ShoppingCartApiBase + "/api/cart/ApplyCoupon",
                AccessToken = token
            });
        }

        public async Task<T> Checkout<T>(CartHeaderDto cartHeader, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.POST,
                Data = cartHeader,
                ApiUrl = ServiceLocator.ShoppingCartApiBase + "/api/cart/checkout",
                AccessToken = token
            });
        }

        public async Task<T> GetCartByUserIdAsnyc<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.GET,
                ApiUrl = ServiceLocator.ShoppingCartApiBase + "/api/cart/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveCoupon<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.POST,
                Data = userId,
                ApiUrl = ServiceLocator.ShoppingCartApiBase + "/api/cart/RemoveCoupon",
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.POST,
                Data = cartId,
                ApiUrl = ServiceLocator.ShoppingCartApiBase + "/api/cart/RemoveCart",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.POST,
                Data = cartDto,
                ApiUrl = ServiceLocator.ShoppingCartApiBase + "/api/cart/UpdateCart",
                AccessToken = token
            });
        }
    }
}
