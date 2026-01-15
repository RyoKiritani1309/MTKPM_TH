namespace Lab01.Patterns.Builder
{
    public class OrderBuilder
    {
        private Order _order = new Order();

        public OrderBuilder SetId(int id)
        {
            _order.Id = id;
            return this;
        }

        public OrderBuilder SetCustomer(string name, string address)
        {
            _order.CustomerName = name;
            _order.Address = address;
            return this;
        }

        public OrderBuilder AddProduct(string productName, double price)
        {
            _order.Products.Add(productName);
            _order.TotalAmount += price;
            return this;
        }

        public OrderBuilder ApplyDiscount(double discount)
        {
            _order.Discount = discount;
            return this;
        }

        public OrderBuilder SetShipping(double fee)
        {
            _order.ShippingFee = fee;
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }
}