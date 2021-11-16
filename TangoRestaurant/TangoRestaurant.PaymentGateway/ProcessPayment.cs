namespace TangoRestaurant.PaymentGateway
{
    public class ProcessPayment : IProcessPayment
    {
        public bool PaymentProcessor()
        {
            // dummy payment
            return true;
        }
    }
}