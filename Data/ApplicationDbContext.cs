using DigitalGameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalGameStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<DiscountedProducts> DiscountedProducts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<UserLibrary> UserLibraries { get; set; }
    }
}
