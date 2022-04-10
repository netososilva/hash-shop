using System.Collections.Generic;

namespace HashShop.Models
{
    public class ProductRequest
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
