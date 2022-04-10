using HashShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace HashShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        [HttpGet]
        public StatusCodeResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public ObjectResult Post(ProductRequest request)
        {
            return new OkObjectResult(request);
        }
    }
}
