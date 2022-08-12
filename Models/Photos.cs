using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalGameStore.Models
{
    public class Photos
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Products Product { get; set; }
    }
}
