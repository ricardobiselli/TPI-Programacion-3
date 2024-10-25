namespace Application.Models.Requests
{
    public class AddOrRemoveProductToCartDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
