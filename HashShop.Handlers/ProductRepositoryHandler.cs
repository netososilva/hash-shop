using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;
using HashShop.Repository.Interfaces;
using System;
using System.Linq;

namespace HashShop.Handlers
{
    public class ProductRepositoryHandler : BaseHandler<Order>, IProductRepositoryHandler
    {
        private readonly IProductDao _productDao;

        public ProductRepositoryHandler(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public override void Handle(Order request)
        {
            var products = _productDao.GetAll();

            foreach (var product in request.Products)
            {
                var productFromDatabase = products.FirstOrDefault(x => x.Id == product.Id);

                if (productFromDatabase == null) 
                    throw new ArgumentOutOfRangeException($"Product id {product.Id} not found");

                if (productFromDatabase.IsGift)
                    throw new ArgumentOutOfRangeException("Invalid gift product");

                product.UnitAmount = productFromDatabase.Amount;
            }

            base.Handle(request);
        }
    }
}
