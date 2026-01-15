namespace Lab01.Patterns.FactoryMethod
{
    public class PaypalPayment : IPayment
    {
        public string ProcessPayment()
        {
            return "Thanh toan qua PAYPAL thanh cong! (Fee: 1%)";
        }
    }
}