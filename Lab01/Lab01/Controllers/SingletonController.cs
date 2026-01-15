using Microsoft.AspNetCore.Mvc;
using Lab01.Patterns.Singleton;

namespace Lab01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SingletonController : ControllerBase
    {
        private readonly ILoggerService _logger;

        // Inject LoggerService vào Constructor
        public SingletonController(ILoggerService logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.Log("SingletonController is running...");
            return Ok(new
            {
                Message = "Check Instance ID inside",
                InstanceId = _logger.GetInstanceId()
            });
        }
    }
}