using Microsoft.AspNetCore.Mvc;
using Lab01.Patterns.Builder;
using Lab01.Patterns.Singleton; // Import Singleton
using System;

namespace Lab01.Controllers
{
    // 1. DTO (Data Transfer Object) cho Request
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
        private readonly ILoggerService _logger;

        public OrderController(ILoggerService logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateOrderFromUI([FromBody] OrderRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.CustomerName) || string.IsNullOrEmpty(request.ProductName))
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Tên khách hàng và tên sản phẩm không được để trống."
                    });
                }

                _logger.Log($"OrderController: Đang xử lý đơn hàng cho {request.CustomerName}");

                double shippingFee;
                if (request.IsFastShipping)
                {
                    shippingFee = 50000;
                }
                else
                {
                    shippingFee = 15000;
                }

                var builder = new OrderBuilder()
                    .SetId(new Random().Next(1000, 9999))
                    .SetCustomer(request.CustomerName, request.Address)
                    .AddProduct(request.ProductName, request.Price)
                    .SetShipping(shippingFee);

                var order = builder.Build();

                return Ok(new
                {
                    Success = true,
                    Message = "Tạo đơn hàng thành công!",
                    Data = order
                });
            }
            catch (Exception ex)
            {
                _logger.Log($"Lỗi: {ex.Message}");
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Lỗi hệ thống: " + ex.Message
                });
            }
        }
    }
}