using Domain.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class AddOrRemoveProductToCartDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]

        public int Quantity { get; set; }

       
    }
}
