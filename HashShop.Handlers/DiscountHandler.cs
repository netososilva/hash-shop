using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;
using HashShop.Repository.Interfaces;

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
                product.SetDiscount(_discountDao.Get(product.Id));
            }

            base.Handle(request);
        }
    }
}
