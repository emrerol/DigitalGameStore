using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalGameStore.Models
{
    public class Cart
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Products Product { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        public bool OrderConfirmed { get; set; } = false;

        [NotMapped]
        private int count;
        public int Count
        {
            set
            {
                this.count = 1;
            }
            get
            {
                return count;
            }
        }

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
