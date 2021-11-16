namespace TangoRestaurant.Services.EmailApi.Middleware
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
