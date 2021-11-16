using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace TangoRestaurant.MessageBus
{
    public class AzureServiceBus : IMessageBus
    {
        //TODO:  move this
        private string connectionString = "Endpoint=sb://tangorestaurant.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NGHuYvFO6ajQbLTiEzwp80nRpnVSG01ti8SkYOqo8+Q=";
        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finalMessage);

            await client.DisposeAsync();

        }
    }
}
