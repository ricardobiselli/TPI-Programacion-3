using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OrderDTO
    {
        public decimal TotalAmount { get; set; }
        public int ClientId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}