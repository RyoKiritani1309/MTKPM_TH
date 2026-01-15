namespace Lab01.Patterns.FactoryMethod
{
    public class CashPayment : IPayment
    {
        public string ProcessPayment()
        {
            return "Thanh toan bang TIEN MAT thanh cong!";
        }
    }
}