using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalGameStore.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Products Product { get; set; }


        public int Count { get; set; }

        public double UnitPrice { get; set; }

        [NotMapped]
        public double TotalPrice
        {
            get
            {
                return Count * UnitPrice;
            }
        }
    }
}
