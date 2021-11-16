namespace TangoRestaurant.Services.OrderApi.Middleware
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
