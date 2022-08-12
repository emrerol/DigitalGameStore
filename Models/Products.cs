using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalGameStore.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public AgeRatings AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Photos> Photos { get; set; }
        public int PublisherID { get; set; }

        [ForeignKey("PublisherID")]
        public Publisher Publisher { get; set; }
        public int GenreID { get; set; }

        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }
    }
    public enum AgeRatings
    {
        AllAge,
        Adults
    }
}
