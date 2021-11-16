using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using TangoRestaurant.MessageBus;
using TangoRestaurant.PaymentGateway;
using TangoRestaurant.Services.PaymentApi.Messages;
using TangoRestaurant.Services.PaymentApi.Middleware;

namespace TangoRestaurant.Services.OrderApi.Middleware
{
    public partial class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _subscriptionPayment;      
        private readonly string _orderPaymentMessageTopic;
        private readonly string _orderUpdatePaymentResultTopic;
     

        private readonly IConfiguration _configuration;
        private readonly IMessageBus _messageBus;
        private readonly IProcessPayment _processPayment;


        private ServiceBusProcessor _orderUpdatePaymentStatusProcessor;

        public AzureServiceBusConsumer(IProcessPayment processPayment, IConfiguration configuration, IMessageBus messageBus)
        {
            _processPayment = processPayment;
            _configuration = configuration;
            _messageBus = messageBus;

            _serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            _subscriptionPayment = _configuration.GetValue<string>("SubscriptionPayment");
            _orderPaymentMessageTopic = _configuration.GetValue<string>("OrderPaymentMessageTopic");
            _orderUpdatePaymentResultTopic = _configuration.GetValue<string>("OrderUpdatePaymentResultTopic");


            var client = new ServiceBusClient(_serviceBusConnectionString);
          
           _orderUpdatePaymentStatusProcessor = client.CreateProcessor(_orderPaymentMessageTopic, _subscriptionPayment);
        }

        public async Task Start()
        {
            _orderUpdatePaymentStatusProcessor.ProcessMessageAsync += OnOrderPaymentProcess;
            _orderUpdatePaymentStatusProcessor.ProcessErrorAsync += ErrorHandler;
            await _orderUpdatePaymentStatusProcessor.StartProcessingAsync(); 
        }

        public async Task Stop()
        { 
           await _orderUpdatePaymentStatusProcessor.StopProcessingAsync();
           await _orderUpdatePaymentStatusProcessor.DisposeAsync();
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task OnOrderPaymentProcess(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            PaymentRequestMessage paymentRequestMessage = JsonConvert.DeserializeObject<PaymentRequestMessage>(body);

            var result = _processPayment.PaymentProcessor();

            UpdatePaymentResultMessage updatePaymentResultMessage = new()
            {
                Status = result,
                OrderId = paymentRequestMessage.OrderId,
                Email = paymentRequestMessage.Email
            };

            try
            {
                await _messageBus.PublishMessage(updatePaymentResultMessage, _orderUpdatePaymentResultTopic);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
