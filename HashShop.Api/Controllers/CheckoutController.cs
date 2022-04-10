using HashShop.Dto.Checkout.Request;
using HashShop.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HashShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IOrderProcess _processOrder;

        public CheckoutController(IOrderProcess processOrder)
        {
            _processOrder = processOrder;
        }

        [HttpPost]
        public ObjectResult Post(CheckoutRequest request)
        {
            var response = _processOrder.Execute(request);

            return new OkObjectResult(response);
        }
    }
}
