using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; } 

        public List<Product> Products { get; set; } = new List<Product>();


        public ShoppingCart() { }

    }
}
