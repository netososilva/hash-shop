using System.Collections.Generic;

namespace HashShop.Dto.Checkout.Request
{
    public class CheckoutRequest
    {
        public IEnumerable<ProductRequestDto> Products { get; set; }
    }
}
