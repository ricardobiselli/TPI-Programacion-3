using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order( decimal totalAmount)
    {
        public int OrderId { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; } = totalAmount;
        public List<Product>? Products { get; set; } = new List<Product>();
        public Client Client { get; set; }

            
    }
}
