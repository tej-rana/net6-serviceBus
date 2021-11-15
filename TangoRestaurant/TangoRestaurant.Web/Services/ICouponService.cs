namespace TangoRestaurant.Web.Services
{
    public interface ICouponService
    {
        Task<T> GetCoupon<T>(string couponCode, string token = null);

    }
}
