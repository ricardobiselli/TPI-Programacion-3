using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Domain.Models.Purchases
{
    public class Payment(decimal amount, string paymentMethod, bool paymentStatus)
    {
        [Key]
        public int? PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = amount;
        public string? PaymentMethod { get; set; } = paymentMethod;
        public bool PaymentStatus { get; set; } = paymentStatus;

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        


    }
}
