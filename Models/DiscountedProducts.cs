using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalGameStore.Models
{
    public class DiscountedProducts
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Products Porduct { get; set; }
        public double DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool OtherCampaign { get; set; } = true;
    }
}
