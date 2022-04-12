using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;
using HashShop.Repository.Interfaces;

namespace HashShop.Handlers
{
    public class BlackFridayHandler : BaseHandler<Order>, IBlackFridayHandler
    {
        private bool _isBlackFriday = true;
        private readonly IProductDao _productDao;

        public BlackFridayHandler(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public override void Handle(Order request)
        {
            var giftProduct = _productDao
                .GetAGiftProduct();

            if (_isBlackFriday) request.Products.Add(new ProductOrder(giftProduct.Id, 1, 0,
                giftProduct.IsGift));

            base.Handle(request);
        }
    }
}
