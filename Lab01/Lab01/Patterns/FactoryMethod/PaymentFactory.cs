namespace Lab01.Patterns.FactoryMethod
{
    public class PaymentFactory
    {
        public static IPayment CreatePayment(string type)
        {
            return type.ToLower() switch
            {
                "cash" => new CashPayment(),
                "paypal" => new PaypalPayment(),
                "vnpay" => new VNPayPayment(),
                _ => throw new ArgumentException("Kieu thanh toan khong hop le"),
            };
        }
    }
}