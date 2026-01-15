using Microsoft.AspNetCore.Mvc;
using Lab01.Patterns.FactoryMethod;

namespace Lab01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Pay([FromQuery] string type)
        {
            try
            {
                IPayment payment = PaymentFactory.CreatePayment(type);

                string result = payment.ProcessPayment();
                return Ok(new { Method = type, Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}