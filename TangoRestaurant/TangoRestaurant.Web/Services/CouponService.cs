using TangoRestaurant.Web.Models;

namespace TangoRestaurant.Web.Services
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CouponService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetCoupon<T>(string couponCode, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceLocator.ApiType.GET,
                ApiUrl = ServiceLocator.CouponApiBase + "/api/coupon/" + couponCode,
                AccessToken = token
            });
        }
    }
}
