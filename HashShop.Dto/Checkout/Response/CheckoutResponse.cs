using System.Collections.Generic;
using System.Linq;

namespace HashShop.Dto.Checkout.Response
{
    public class CheckoutResponse
    {
        public int TotalAmount => Products.Sum(product => product.TotalAmount);
        public int TotalAmountWithDiscount => TotalAmount - TotalDiscount;
        public int TotalDiscount => Products.Sum(product => product.Discount);
        public List<ProductResponseDto> Products { get; set; }

        public CheckoutResponse()
        {
            Products = new List<ProductResponseDto>();
        }
    }
}
