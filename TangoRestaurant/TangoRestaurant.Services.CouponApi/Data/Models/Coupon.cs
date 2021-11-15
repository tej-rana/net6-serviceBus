using System.ComponentModel.DataAnnotations;

namespace TangoRestaurant.Services.CouponApi.Dto
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
