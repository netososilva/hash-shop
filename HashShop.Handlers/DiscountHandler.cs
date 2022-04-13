using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;
using HashShop.Repository.Interfaces;
using System;

namespace HashShop.Handlers
{
    public class DiscountHandler : BaseHandler<Order>, IDiscountHandler
    {
        private readonly IDiscountDao _discountDao;

        public DiscountHandler(IDiscountDao discountDao)
        {
            _discountDao = discountDao;
        }

        public override void Handle(Order request)
        {
            foreach (var product in request.Products)
            {
                try
                {
                    product.SetDiscount(_discountDao.Get(product.Id));
                }
                catch (Exception ex)
                {
                    product.SetDiscount(0);
                }
            }

            base.Handle(request);
        }
    }
}
