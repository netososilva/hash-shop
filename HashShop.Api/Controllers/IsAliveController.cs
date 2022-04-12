using Microsoft.AspNetCore.Mvc;

namespace HashShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsAliveController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
