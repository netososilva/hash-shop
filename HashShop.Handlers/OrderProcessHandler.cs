using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;
using HashShop.Repository.Interfaces;
using System.Linq;

namespace HashShop.Handlers
{
    public class OrderProcessHandler : BaseHandler<Order>, IOrderProcessHandler
    {
        private readonly IProductDao _productDao;

        public OrderProcessHandler(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public override void Handle(Order request)
        {
            var products = _productDao.GetAll();

            foreach (var product in request.Products)
            {
                var productFromDatabase = products.FirstOrDefault(x => x.Id == product.Id);

                product.IsGift = productFromDatabase.IsGift;
                product.UnitAmount = productFromDatabase.Amount;
            }

            base.Handle(request);
        }
    }
}
