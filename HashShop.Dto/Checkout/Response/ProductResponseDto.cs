namespace HashShop.Dto.Checkout.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UnitAmount { get; set; }
        public int TotalAmount { get; set; }
        public int Discount { get; set; }
        public bool IsGift { get; set; }
    }
}
