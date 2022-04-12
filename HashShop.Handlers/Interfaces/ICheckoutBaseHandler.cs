using HashShop.Models.Dto.Checkout.Request;
using HashShop.Models.Dto.Checkout.Response;

namespace HashShop.Handlers.Interfaces
{
    public interface ICheckoutBaseHandler
    {
        CheckoutResponse Execute(CheckoutRequest request);
    }
}
