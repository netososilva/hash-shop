using HashShop.Handlers.Interfaces;
using HashShop.Models.Dto.Checkout.Request;
using Microsoft.AspNetCore.Mvc;
using System;

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
            if (request == null || request.IsInvalid)
                return new BadRequestResult();

            try
            {
                var response = _handler.Execute(request);

                return new OkObjectResult(response);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
