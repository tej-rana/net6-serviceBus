namespace TangoRestaurant.Services.PaymentApi.Middleware
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
