using System;

namespace HashShop.Models.Dto.Checkout.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitAmount { get; set; }
        public int TotalAmount => UnitAmount * Quantity;
        public int Discount { get; private set; }
        public bool IsGift { get; set; }

        public ProductResponseDto()
        {

        }

        public ProductResponseDto(int id, int quantity, int unitAmount, float discount, bool isGift)
        {
            Id = id;
            Quantity = quantity;
            UnitAmount = unitAmount;
            IsGift = isGift;
            Discount = GetDiscount(discount);
        }

        public void SetDiscount(float discount)
        {
            Discount = GetDiscount(discount);
        }

        private int GetDiscount(float discount)
        {
            return Convert.ToInt32(discount * UnitAmount * Quantity);
        }
    }
}
