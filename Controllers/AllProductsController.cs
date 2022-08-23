using DigitalGameStore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalGameStore.Models;

namespace DigitalGameStore.Controllers
{
    public class AllProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var db = _context.Products;
            return View(db.ToList());
        }
    }
    public class ProductsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        //public AgeRatings AgeRating { get; set; }
        //public DateTime ReleaseDate { get; set; }
        public string PhotoName { get; set; }

        public string Genre { get; set; }

        /*public double DiscountRate { get; set; }
        public double DiscountedPrice
        {
            get
            {
                UnitPrice -= (UnitPrice * DiscountRate / 100);
                return Math.Round(UnitPrice, 2);
            }
        }*/
    }
}