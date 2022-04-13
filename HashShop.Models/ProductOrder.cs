using System;

namespace HashShop.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitAmount { get; set; }
        public bool IsGift { get; set; }
        public int TotalAmount => UnitAmount * Quantity;
        public int Discount { get; private set; }

        public void SetDiscount(float discount)
        {
            Discount = Convert.ToInt32(discount * UnitAmount * Quantity);
        }

        public ProductOrder()
        {
        }

        public ProductOrder(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public ProductOrder(int id, int quantity, int unitAmount, bool isGift) : this(id, quantity)
        {
            UnitAmount = unitAmount;
            IsGift = isGift;
        }

        public static ProductOrder CreateGiftProduct(int id)
        {
            return new ProductOrder(id, 1, 0, true);
        }
    }
}
