using System.Collections.Generic;
using System.Linq;

namespace HashShop.Models.Dto.Checkout.Request
{
    public class CheckoutRequest
    {
        public List<ProductRequestDto> Products { get; set; }

        public bool IsInvalid => !IsValid();

        public bool IsValid()
        {
            if (IsProductNull()) return false;
            if (IsProductEmpty()) return false;
            if (IsAnyProductWithInvalidId()) return false;
            if (IsAnyProductWithInvalidQuantity()) return false;

            return true;
        }

        private bool IsProductNull()
        {
            return Products == null;
        }

        private bool IsProductEmpty()
        {
            return Products.Count == 0;
        }

        private bool IsAnyProductWithInvalidId()
        {
            return Products.Any(product => product.Id == 0 || product.Id < 0);
        }

        private bool IsAnyProductWithInvalidQuantity()
        {
            return Products.Any(product => product.Quantity == 0 || product.Quantity < 0);
        }
    }
}
