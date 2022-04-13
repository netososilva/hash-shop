using HashShop.Handlers.Interfaces;
using HashShop.Models.Dto.Checkout.Request;
using HashShop.Models.Dto.Checkout.Response;
using HashShop.Models.Mapper;

namespace HashShop.Handlers.Base
{
    public class CheckoutBaseHandler : ICheckoutBaseHandler
    {
        private readonly IProductRepositoryHandler _productRepositoryHandler;
        private readonly IDiscountHandler _discountHandler;
        private readonly IInvalidGiftHandler _invalidGiftHandler;
        private readonly IBlackFridayHandler _blackFridayHandler;

        public CheckoutBaseHandler(IProductRepositoryHandler productRepositoryHandler, IDiscountHandler discountHandler, 
            IInvalidGiftHandler invalidGiftHandler, IBlackFridayHandler blackFridayHandler)
        {
            _productRepositoryHandler = productRepositoryHandler;
            _discountHandler = discountHandler;
            _invalidGiftHandler = invalidGiftHandler;
            _blackFridayHandler = blackFridayHandler;
        }

        public CheckoutResponse Execute(CheckoutRequest request)
        {
            var order = CheckoutRequestMapping.ToOrder(request);

            _productRepositoryHandler.SetNext(_discountHandler);
            _discountHandler.SetNext(_invalidGiftHandler);
            _invalidGiftHandler.SetNext(_blackFridayHandler);
            _productRepositoryHandler.Handle(order);

            return OrderMapping.ToCheckoutResponse(order);
        }
    }
}

