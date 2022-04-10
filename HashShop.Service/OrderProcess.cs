using HashShop.Dto.Checkout.Request;
using HashShop.Dto.Checkout.Response;
using HashShop.Infrastructure.Interfaces;
using HashShop.Service.Interfaces;
using System;
using System.Linq;

namespace HashShop.Service
{
    public class OrderProcess : IOrderProcess
    {
        private readonly IProductDao _productDao;

        public OrderProcess(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public CheckoutResponse Execute(CheckoutRequest request)
        {
            var response = new CheckoutResponse();
            var products = _productDao.GetAll();

            foreach(var product in request.Products)
            {
                var productFromDatabase = products.FirstOrDefault(x => x.Id == product.Id);
                var productDto = new ProductResponseDto
                {
                    Id = product.Id,
                    Discount = 0,
                    IsGift = productFromDatabase.IsGift,
                    Quantity = product.Quantity,
                    UnitAmount = productFromDatabase.Amount,
                    TotalAmount = productFromDatabase.Amount * product.Quantity
                };

                response.Products.Add(productDto);

                response.TotalDiscount = 0;
                response.TotalAmountWithDiscount += productDto.TotalAmount;
                response.TotalAmount += productDto.TotalAmount;
            }

            return response;
        }
    }
}
