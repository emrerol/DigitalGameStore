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
    public class UserLibrariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserLibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserLibraries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserLibraries.Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserLibraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLibrary = await _context.UserLibraries
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userLibrary == null)
            {
                return NotFound();
            }

            return View(userLibrary);
        }

        // GET: UserLibraries/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: UserLibraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID")] UserLibrary userLibrary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLibrary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userLibrary.UserID);
            return View(userLibrary);
        }

        // GET: UserLibraries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLibrary = await _context.UserLibraries.FindAsync(id);
            if (userLibrary == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userLibrary.UserID);
            return View(userLibrary);
        }

        // POST: UserLibraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID")] UserLibrary userLibrary)
        {
            if (id != userLibrary.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLibrary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLibraryExists(userLibrary.ID))
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
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userLibrary.UserID);
            return View(userLibrary);
        }

        // GET: UserLibraries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLibrary = await _context.UserLibraries
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userLibrary == null)
            {
                return NotFound();
            }

            return View(userLibrary);
        }

        // POST: UserLibraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLibrary = await _context.UserLibraries.FindAsync(id);
            _context.UserLibraries.Remove(userLibrary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLibraryExists(int id)
        {
            return _context.UserLibraries.Any(e => e.ID == id);
        }
    }
}
