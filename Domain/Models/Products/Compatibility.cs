using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Products
{
    public class Compatibility
    {
        public Compatibility() { }

        [Key]
        public int Id { get; set; }

        public string? RamType { get; set; } // DDR3, DDR4, DDR5
        public string? SocketType { get; set; } // INTEL, AMD
        public string? PowerSupplyType { get; set; } // ATX(normal), SFX(mini)
        public string? GpuType { get; set; } // PCIe 3.0, PCIe 4.0

       // [ForeignKey("ProductId")]
       // public int ProductId { get; set; }
       // public Product? Product { get; set; }
    }
}
