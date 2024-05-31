using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Payment( decimal amount, string paymentMethod, bool paymentStatus)
    {
        public int? PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = amount;
        public Client Client { get; set; } 
        public string PaymentMethod { get; set; } = paymentMethod;
        public bool PaymentStatus { get; set; } = paymentStatus;
    }
}
