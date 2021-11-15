using TangoRestaurant.Services.CouponApi.Dto;

namespace TangoRestaurant.Services.CouponApi.Data.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
