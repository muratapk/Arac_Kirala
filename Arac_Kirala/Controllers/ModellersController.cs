using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arac_Kirala.Context;
using Arac_Kirala.Models;

namespace Arac_Kirala.Controllers
{
    public class ModellersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModellersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modellers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modellers.ToListAsync());
        }

        // GET: Modellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeller = await _context.Modellers
                .FirstOrDefaultAsync(m => m.ModellerId == id);
            if (modeller == null)
            {
                return NotFound();
            }

            return View(modeller);
        }

        // GET: Modellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModellerId,ModellerAdi")] Modeller modeller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeller);
        }

        // GET: Modellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeller = await _context.Modellers.FindAsync(id);
            if (modeller == null)
            {
                return NotFound();
            }
            return View(modeller);
        }

        // POST: Modellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModellerId,ModellerAdi")] Modeller modeller)
        {
            if (id != modeller.ModellerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModellerExists(modeller.ModellerId))
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
            return View(modeller);
        }

        // GET: Modellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeller = await _context.Modellers
                .FirstOrDefaultAsync(m => m.ModellerId == id);
            if (modeller == null)
            {
                return NotFound();
            }

            return View(modeller);
        }

        // POST: Modellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeller = await _context.Modellers.FindAsync(id);
            if (modeller != null)
            {
                _context.Modellers.Remove(modeller);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModellerExists(int id)
        {
            return _context.Modellers.Any(e => e.ModellerId == id);
        }
    }
}
