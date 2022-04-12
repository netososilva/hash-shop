using HashShop.Models.Dto.Checkout.Response;

namespace HashShop.Models.Mapper
{
    public static class OrderMapping
    {
        public static CheckoutResponse ToCheckoutResponse(Order order)
        {
            CheckoutResponse response = new CheckoutResponse();

            foreach (var product in order.Products)
            {
                response.Products.Add(new ProductResponseDto(product.Id, product.Quantity, product.UnitAmount,
                    product.TotalAmount, product.Discount, product.IsGift));
            }

            response.TotalAmount = order.TotalAmount;
            response.TotalDiscount = order.TotalDiscount;
            response.TotalAmountWithDiscount = order.TotalAmountWithDiscount;
            
            return response;
        }
    }
}
