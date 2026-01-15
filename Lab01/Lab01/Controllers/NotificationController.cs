using Microsoft.AspNetCore.Mvc;
using Lab01.Patterns.AbstractFactory;

namespace Lab01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        [HttpGet]
        public IActionResult SendNotification([FromQuery] string level)
        {
            INotificationFactory factory;

            // Chọn nhà máy dựa trên level
            if (level.ToLower() == "high")
            {
                factory = new HighPriorityNotificationFactory();
            }
            else
            {
                factory = new RegularNotificationFactory();
            }

            // Nhà máy tạo ra sản phẩm tương ứng
            var emailService = factory.CreateEmail();
            var smsService = factory.CreateSms();

            return Ok(new
            {
                Level = level,
                EmailResult = emailService.SendEmail(),
                SmsResult = smsService.SendSms()
            });
        }
    }
}