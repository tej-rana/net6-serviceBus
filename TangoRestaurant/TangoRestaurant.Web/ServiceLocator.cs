namespace TangoRestaurant.Web
{
    public class ServiceLocator
    {
        public static string ProductApiBase { get; set; }

        public static string CouponApiBase { get; set; }

        public static string ShoppingCartApiBase { get; set; }

        public enum ApiType {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
