using Microsoft.AspNetCore.Mvc;
using Lab01.Patterns.Builder;
using System; // Cần cái này để dùng Random

namespace Lab01.Controllers
{
    // 1. Định nghĩa class OrderRequest (DTO) để nhận dữ liệu từ giao diện
    // Đặt class này nằm trong Namespace, nhưng ở bên ngoài class OrderController
    public class OrderRequest
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool IsFastShipping { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        // 2. API GET cũ (Giữ nguyên để test code cứng nếu muốn)
        [HttpGet]
        public IActionResult CreateOrder()
        {
            Order order1 = new OrderBuilder()
                .SetId(101)
                .SetCustomer("Nguyen Van A", "Ha Noi")
                .AddProduct("Laptop Dell", 15000000)
                .Build();

            return Ok(new
            {
                Message = "Test hard-code thành công",
                OrderSimple = order1.ToString()
            });
        }

        // 3. API POST mới (Nhận dữ liệu từ Website để Build đơn hàng)
        // Hàm này bắt buộc phải nằm TRONG cặp ngoặc nhọn của class OrderController
        [HttpPost]
        public IActionResult CreateOrderFromUI([FromBody] OrderRequest request)
        {
            // Bắt đầu áp dụng Builder Pattern
            var builder = new OrderBuilder()
                .SetId(new Random().Next(100, 999)) // Random ID đơn hàng
                .SetCustomer(request.CustomerName, request.Address)
                .AddProduct(request.ProductName, request.Price);

            // Logic xử lý ship
            if (request.IsFastShipping)
            {
                builder.SetShipping(50000); // Phí ship nhanh
            }
            else
            {
                builder.SetShipping(15000); // Phí tiêu chuẩn
            }

            // Kết thúc việc xây dựng
            var order = builder.Build();

            return Ok(new
            {
                Message = "Tạo đơn hàng thành công bằng Builder!",
                OrderData = order.ToString()
            });
        }
    }
}