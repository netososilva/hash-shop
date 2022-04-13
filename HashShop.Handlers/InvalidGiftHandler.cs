using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;
using System;

namespace HashShop.Handlers
{
    public class InvalidGiftHandler : BaseHandler<Order>, IInvalidGiftHandler
    {
        public override void Handle(Order request)
        {
            foreach (var product in request.Products)
            {
                if (product.IsGift) 
                    throw new ArgumentOutOfRangeException($"ID: {product.Id} are invalid, " +
                        $"please try again without a gift product in your cart");
            }

            base.Handle(request);
        }
    }
}
