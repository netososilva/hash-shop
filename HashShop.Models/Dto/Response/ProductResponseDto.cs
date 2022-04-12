using System;

namespace HashShop.Models.Dto.Checkout.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitAmount { get; set; }
        public int TotalAmount { get; set; }
        public int Discount { get; set; }
        public bool IsGift { get; set; }

        public ProductResponseDto()
        {

        }

        public ProductResponseDto(int id, int quantity, int unitAmount, int totalAmount, 
            int discount, bool isGift)
        {
            Id = id;
            Quantity = quantity;
            UnitAmount = unitAmount;
            TotalAmount = totalAmount;
            IsGift = isGift;
            Discount = discount;
        }
    }
}
