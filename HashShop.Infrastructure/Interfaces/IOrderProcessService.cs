using HashShop.Dto.Checkout.Request;
using HashShop.Dto.Checkout.Response;

namespace HashShop.Infrastructure.Interfaces
{
    public interface IOrderProcessService : IExecute<CheckoutResponse, CheckoutRequest>
    {
    }
}
