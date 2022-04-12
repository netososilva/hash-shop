using System.Collections.Generic;

namespace HashShop.Models.Dto.Checkout.Response
{
    public class CheckoutResponse
    {
        public int TotalAmount { get; set; }
        public int TotalAmountWithDiscount { get; set; }
        public int TotalDiscount { get; set; }
        public List<ProductResponseDto> Products { get; set; }

        public CheckoutResponse()
        {
            Products = new List<ProductResponseDto>();
        }
    }
}
