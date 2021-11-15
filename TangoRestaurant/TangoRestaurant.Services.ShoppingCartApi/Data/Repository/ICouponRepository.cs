using TangoRestaurant.Services.ShoppingCartApi.Dto;

namespace TangoRestaurant.Services.ShoppingCartApi.Data.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
