using HashShop.Handlers.Interfaces;
using HashShop.Models.Dto.Checkout.Request;
using Microsoft.AspNetCore.Mvc;

namespace HashShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutBaseHandler _handler;

        public CheckoutController(ICheckoutBaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Post(CheckoutRequest request)
        {
            if (request == null || !request.IsValid)
                return new BadRequestResult();

            var response = _handler.Execute(request);

            return new OkObjectResult(response);
        }
    }
}
