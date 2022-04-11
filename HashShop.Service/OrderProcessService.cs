using HashShop.Dto.Checkout.Request;
using HashShop.Dto.Checkout.Response;
using HashShop.Infrastructure.Interfaces;
using HashShop.Service.Interfaces;
using System;
using System.Linq;

namespace HashShop.Service
{
    public class OrderProcessService : IOrderProcessService
    {
        private readonly IProductDao _productDao;
        private readonly IDiscountDao _discountDao;

        public OrderProcessService(IProductDao productDao, IDiscountDao discountDao)
        {
            _productDao = productDao;
            _discountDao = discountDao;
        }

        public CheckoutResponse Execute(CheckoutRequest request)
        {
            var response = new CheckoutResponse();
            var products = _productDao.GetAll();

            foreach(var product in request.Products)
            {
                var productFromDatabase = products.FirstOrDefault(x => x.Id == product.Id);
                var discount = _discountDao.Get(product.Id);
                var productDto = new ProductResponseDto(product.Id, product.Quantity,
                    productFromDatabase.Amount, discount, productFromDatabase.IsGift);
                
                response.Products.Add(productDto);
            }

            return response;
        }
    }
}
