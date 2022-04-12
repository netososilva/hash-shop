using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;

namespace HashShop.Handlers
{
    public class InvalidGiftHandler : BaseHandler<Order>, IInvalidGiftHandler
    {
        public override void Handle(Order request)
        {
            foreach (var product in request.Products)
            {
                if (product.IsGift) request.Products.Remove(product);
            }

            base.Handle(request);
        }
    }
}
