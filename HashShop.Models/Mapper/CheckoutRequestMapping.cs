using HashShop.Models.Dto.Checkout.Request;

namespace HashShop.Models.Mapper
{
    public static class CheckoutRequestMapping
    {
        public static Order ToOrder(CheckoutRequest request)
        {
            var order = new Order();

            foreach (var product in request.Products)
            {
                order.Products.Add(new ProductOrder(product.Id, product.Quantity));
            }

            return order;
        }
    }
}
