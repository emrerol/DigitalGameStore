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
            var ProductsList = (from u in _context.Products
                                join k in _context.Genres on u.GenreID equals k.ID
                                join f in _context.Photos on u.ID equals f.ProductID
                                select new ProductsDTO
                                {
                                    ID = u.ID,
                                    Name = u.Name,
                                    UnitPrice = u.UnitPrice,
                                    PhotoName = f.Name,
                                    UnitsInStock = u.UnitsInStock,
                                    Genre = k.Name
                                }).ToList();
            return View(ProductsList);
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