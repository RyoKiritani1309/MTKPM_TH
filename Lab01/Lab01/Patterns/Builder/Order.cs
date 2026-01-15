namespace Lab01.Patterns.Builder
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<string> Products { get; set; } = new List<string>();
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double ShippingFee { get; set; }

        public override string ToString()
        {
            return $"Order #{Id} | Khach: {CustomerName} | DC: {Address} | SP: {string.Join(", ", Products)} | Tong: {TotalAmount - Discount + ShippingFee}";
        }
    }
}