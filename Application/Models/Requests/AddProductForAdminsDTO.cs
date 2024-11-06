using Domain.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Models.Requests
{
    public class AddProductForAdminsDTO
    {
        [Required(ErrorMessage = "Name field is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description field is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price field is required")]
        [Range(0, 99999, ErrorMessage = "Price must be between 0 and 99999")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock  field is required")]
        [Range(0, 99999, ErrorMessage = "Stock value must be between 0 and 99999")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category field is required")]
        [StringLength(20, MinimumLength = 3)]
        public string? Category { get; set; }

        [Required(ErrorMessage = "power consumption field is required")]
        [Range(0, 999, ErrorMessage = "Power consumption value must be between 0 and 999")]
        public decimal PowerConsumption { get; set; }

        

    }
}
