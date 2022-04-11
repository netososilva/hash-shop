using HashShop.Dto.Checkout.Request;
using HashShop.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HashShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IOrderProcessService _processOrder;

        public CheckoutController(IOrderProcessService processOrder)
        {
            _processOrder = processOrder;
        }

        [HttpPost]
        public IActionResult Post(CheckoutRequest request)
        {
            if (request == null || !request.IsValid)
                return new BadRequestResult();

            var response = _processOrder.Execute(request);

            return new OkObjectResult(response);
        }
    }
}
