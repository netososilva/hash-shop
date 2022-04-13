using HashShop.Handlers.Base;
using HashShop.Handlers.Interfaces;
using HashShop.Models;
using HashShop.Repository.Interfaces;

namespace HashShop.Handlers
{
    public class BlackFridayHandler : BaseHandler<Order>, IBlackFridayHandler
    {
        private readonly IProductDao _productDao;
        private readonly ISpecialDateDao _specialDateDao;

        public BlackFridayHandler(IProductDao productDao,
            ISpecialDateDao specialDateDao)
        {
            _productDao = productDao;
            _specialDateDao = specialDateDao;
        }

        public override void Handle(Order request)
        {
            var giftProduct = _productDao.GetAGiftProduct();

            if (_specialDateDao.IsBlackFriday()) 
                request.Products.Add(ProductOrder.CreateGiftProduct(giftProduct.Id));

            base.Handle(request);
        }
    }
}
