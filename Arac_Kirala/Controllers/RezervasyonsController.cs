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
    public class RezervasyonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervasyonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezervasyons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rezervasyons.ToListAsync());
        }

        // GET: Rezervasyons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyons
                .FirstOrDefaultAsync(m => m.RezervasyonId == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // GET: Rezervasyons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezervasyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervasyonId,AlisTarihi,AlisSaati,BirakTarih,BirakSaati")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervasyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyon);
        }

        // GET: Rezervasyons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyons.FindAsync(id);
            if (rezervasyon == null)
            {
                return NotFound();
            }
            return View(rezervasyon);
        }

        // POST: Rezervasyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervasyonId,AlisTarihi,AlisSaati,BirakTarih,BirakSaati")] Rezervasyon rezervasyon)
        {
            if (id != rezervasyon.RezervasyonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervasyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervasyonExists(rezervasyon.RezervasyonId))
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
            return View(rezervasyon);
        }

        // GET: Rezervasyons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyons
                .FirstOrDefaultAsync(m => m.RezervasyonId == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // POST: Rezervasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervasyon = await _context.Rezervasyons.FindAsync(id);
            if (rezervasyon != null)
            {
                _context.Rezervasyons.Remove(rezervasyon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervasyonExists(int id)
        {
            return _context.Rezervasyons.Any(e => e.RezervasyonId == id);
        }
    }
}
