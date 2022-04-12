namespace HashShop.Models.Dto.Checkout.Request
{
    public class ProductRequestDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public ProductRequestDto()
        {

        }

        public ProductRequestDto(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}
