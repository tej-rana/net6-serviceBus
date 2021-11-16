using TangoRestaurant.Services.OrderApi.Data.Models;

namespace TangoRestaurant.Services.OrderApi.Data.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
