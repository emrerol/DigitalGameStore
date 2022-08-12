using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalGameStore.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RefundDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderCode { get; set; }
        public string Description { get; set; }
        public double TotalCost { get; set; }
        public double Discount { get; set; }
    }
    public enum PaymentType
    {
        BankCart,
        CreditCart
    }
    public enum OrderStatus
    {
        Completed,
        Refunded
    }
}
