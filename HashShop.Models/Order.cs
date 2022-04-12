using System.Collections.Generic;
using System.Linq;

namespace HashShop.Models
{
    public class Order
    {
        public int TotalAmount => Products.Sum(product => product.TotalAmount);
        public int TotalAmountWithDiscount => TotalAmount - TotalDiscount;
        public int TotalDiscount => Products.Sum(product => product.Discount);
        public List<ProductOrder> Products { get; set; }

        public Order()
        {
            Products = new List<ProductOrder>();
        }
    }
}
