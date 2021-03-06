using System.Collections.Generic;

namespace HashShop.Dto.Checkout.Request
{
    public class CheckoutRequest
    {
        public List<ProductRequestDto> Products { get; set; }

        public bool IsValid => Products != null && Products.Count > 0;
    }
}
