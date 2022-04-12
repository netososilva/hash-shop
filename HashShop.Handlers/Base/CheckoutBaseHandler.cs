using HashShop.Handlers.Interfaces;
using HashShop.Models.Dto.Checkout.Request;
using HashShop.Models.Dto.Checkout.Response;
using HashShop.Models.Mapper;

namespace HashShop.Handlers.Base
{
    public class CheckoutBaseHandler : ICheckoutBaseHandler
    {
        private readonly IOrderProcessHandler _orderProcessHandler;
        private readonly IDiscountHandler _discountHandler;
        private readonly IInvalidGiftHandler _invalidGiftHandler;
        private readonly IBlackFridayHandler _blackFridayHandler;

        public CheckoutBaseHandler(IOrderProcessHandler orderProcessHandler, IDiscountHandler discountHandler, 
            IInvalidGiftHandler invalidGiftHandler, IBlackFridayHandler blackFridayHandler)
        {
            _orderProcessHandler = orderProcessHandler;
            _discountHandler = discountHandler;
            _invalidGiftHandler = invalidGiftHandler;
            _blackFridayHandler = blackFridayHandler;
        }

        public CheckoutResponse Execute(CheckoutRequest request)
        {
            var order = CheckoutRequestMapping.ToOrder(request);

            _orderProcessHandler.SetNext(_discountHandler);
            _discountHandler.SetNext(_invalidGiftHandler);
            _invalidGiftHandler.SetNext(_blackFridayHandler);

            _orderProcessHandler.Handle(order);

            return OrderMapping.ToCheckoutResponse(order);
        }
    }
}

