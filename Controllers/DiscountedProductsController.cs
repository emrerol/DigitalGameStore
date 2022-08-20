using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalGameStore.Data;
using DigitalGameStore.Models;

namespace DigitalGameStore.Controllers
{
    public class DiscountedProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscountedProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiscountedProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DiscountedProducts.Include(d => d.Porduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiscountedProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountedProducts = await _context.DiscountedProducts
                .Include(d => d.Porduct)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (discountedProducts == null)
            {
                return NotFound();
            }

            return View(discountedProducts);
        }

        // GET: DiscountedProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID");
            return View();
        }

        // POST: DiscountedProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductID,DiscountRate,StartDate,EndDate,OtherCampaign")] DiscountedProducts discountedProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discountedProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID", discountedProducts.ProductID);
            return View(discountedProducts);
        }

        // GET: DiscountedProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountedProducts = await _context.DiscountedProducts.FindAsync(id);
            if (discountedProducts == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID", discountedProducts.ProductID);
            return View(discountedProducts);
        }

        // POST: DiscountedProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductID,DiscountRate,StartDate,EndDate,OtherCampaign")] DiscountedProducts discountedProducts)
        {
            if (id != discountedProducts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discountedProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountedProductsExists(discountedProducts.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID", discountedProducts.ProductID);
            return View(discountedProducts);
        }

        // GET: DiscountedProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountedProducts = await _context.DiscountedProducts
                .Include(d => d.Porduct)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (discountedProducts == null)
            {
                return NotFound();
            }

            return View(discountedProducts);
        }

        // POST: DiscountedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discountedProducts = await _context.DiscountedProducts.FindAsync(id);
            _context.DiscountedProducts.Remove(discountedProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountedProductsExists(int id)
        {
            return _context.DiscountedProducts.Any(e => e.ID == id);
        }
    }
}
