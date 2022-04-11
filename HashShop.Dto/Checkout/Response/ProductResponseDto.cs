using System;

namespace HashShop.Dto.Checkout.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitAmount { get; set; }
        public int TotalAmount => UnitAmount * Quantity;
        public int Discount { get; set; }
        public bool IsGift { get; set; }

        public ProductResponseDto(int id, int quantity, int unitAmount, double discount, bool isGift)
        {
            Id = id;
            Quantity = quantity;
            UnitAmount = unitAmount;
            IsGift = isGift;
            Discount = GetDiscount(discount);
        }

        private int GetDiscount(double discount)
        {
            return Convert.ToInt32(discount * UnitAmount * Quantity);
        }
    }
}
