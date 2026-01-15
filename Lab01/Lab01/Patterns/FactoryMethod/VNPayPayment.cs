namespace Lab01.Patterns.FactoryMethod
{
    public class VNPayPayment : IPayment
    {
        public string ProcessPayment()
        {
            return "Thanh toan qua VNPAY QR thanh cong!)";
        }
    }
}