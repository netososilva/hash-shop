using HashShop.Models.Dto.Checkout.Request;
using HashShop.Models.Dto.Checkout.Response;
using System.Linq;

namespace HashShop.Service
{
    public class OrderProcessService : IOrderProcessService
    {
        private readonly IProductDao _productDao;

        public OrderProcessService(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public CheckoutResponse Execute(CheckoutRequest request)
        {
            var response = new CheckoutResponse();
            var products = _productDao.GetAll();

            foreach (var product in request.Products)
            {
                var productFromDatabase = products.FirstOrDefault(x => x.Id == product.Id);
                var productDto = new ProductResponseDto(product.Id, product.Quantity,
                    productFromDatabase.Amount, 0, productFromDatabase.IsGift);

                response.Products.Add(productDto);
            }

            return response;
        }
    }
}
