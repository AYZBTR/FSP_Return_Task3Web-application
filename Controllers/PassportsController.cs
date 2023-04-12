using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSP_Return_Task3.Data;
using FSP_Return_Task3.Models;

namespace FSP_Return_Task3.Controllers
{
    public class PassportsController : Controller
    {
        private readonly FSP_Return_Task3Context _context;

        public PassportsController(FSP_Return_Task3Context context)
        {
            _context = context;
        }

        // GET: Passports
        public async Task<IActionResult> Index()
        {
            var fSP_Return_Task3Context = _context.Passport.Include(p => p.Passenger);
            return View(await fSP_Return_Task3Context.ToListAsync());
        }

        // GET: Passports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passport == null)
            {
                return NotFound();
            }

            var passport = await _context.Passport
                .Include(p => p.Passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // GET: Passports/Create
        public IActionResult Create()
        {
            ViewData["PassengerId"] = new SelectList(_context.Passenger, "Id", "Id");
            return View();
        }

        // POST: Passports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PassengerId,PassportNumber,ValidDate")] Passport passport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PassengerId"] = new SelectList(_context.Passenger, "Id", "Id", passport.PassengerId);
            return View(passport);
        }

        // GET: Passports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passport == null)
            {
                return NotFound();
            }

            var passport = await _context.Passport.FindAsync(id);
            if (passport == null)
            {
                return NotFound();
            }
            ViewData["PassengerId"] = new SelectList(_context.Passenger, "Id", "Id", passport.PassengerId);
            return View(passport);
        }

        // POST: Passports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PassengerId,PassportNumber,ValidDate")] Passport passport)
        {
            if (id != passport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassportExists(passport.Id))
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
            ViewData["PassengerId"] = new SelectList(_context.Passenger, "Id", "Id", passport.PassengerId);
            return View(passport);
        }

        // GET: Passports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passport == null)
            {
                return NotFound();
            }

            var passport = await _context.Passport
                .Include(p => p.Passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // POST: Passports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passport == null)
            {
                return Problem("Entity set 'FSP_Return_Task3Context.Passport'  is null.");
            }
            var passport = await _context.Passport.FindAsync(id);
            if (passport != null)
            {
                _context.Passport.Remove(passport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassportExists(int id)
        {
          return (_context.Passport?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
