using TangoRestaurant.Services.EmailApi.Data.Models;
using TangoRestaurant.Services.EmailApi.Messages;

namespace TangoRestaurant.Services.EmailApi.Data.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
