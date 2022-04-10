namespace HashShop.Dto.Checkout.Request
{
    public class ProductRequestDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        
        public ProductRequestDto(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}
