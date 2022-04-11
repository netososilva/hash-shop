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
        private readonly IDiscountDao _discountDao;

        public OrderProcess(IProductDao productDao, IDiscountDao discountDao)
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
                var productDto = new ProductResponseDto
                {
                    Id = product.Id,
                    Discount = Convert.ToInt32(_discountDao.Get(product.Id) * (productFromDatabase.Amount * product.Quantity)),
                    IsGift = productFromDatabase.IsGift,
                    Quantity = product.Quantity,
                    UnitAmount = productFromDatabase.Amount,
                    TotalAmount = productFromDatabase.Amount * product.Quantity
                };

                response.Products.Add(productDto);

                response.TotalDiscount += productDto.Discount;
                response.TotalAmountWithDiscount += productDto.TotalAmount - productDto.Discount;
                response.TotalAmount += productDto.TotalAmount;
            }

            return response;
        }
    }
}
