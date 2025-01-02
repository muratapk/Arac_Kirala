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
    public class MusterilersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusterilersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Musterilers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Musteriler.ToListAsync());
        }

        // GET: Musterilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriler = await _context.Musteriler
                .FirstOrDefaultAsync(m => m.MusteriId == id);
            if (musteriler == null)
            {
                return NotFound();
            }

            return View(musteriler);
        }

        // GET: Musterilers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musterilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusteriId,MusterAd,CepTel,Email,Adres,MusteriKul,MusteriSifre")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteriler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musteriler);
        }

        // GET: Musterilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriler = await _context.Musteriler.FindAsync(id);
            if (musteriler == null)
            {
                return NotFound();
            }
            return View(musteriler);
        }

        // POST: Musterilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusteriId,MusterAd,CepTel,Email,Adres,MusteriKul,MusteriSifre")] Musteriler musteriler)
        {
            if (id != musteriler.MusteriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteriler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusterilerExists(musteriler.MusteriId))
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
            return View(musteriler);
        }

        // GET: Musterilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriler = await _context.Musteriler
                .FirstOrDefaultAsync(m => m.MusteriId == id);
            if (musteriler == null)
            {
                return NotFound();
            }

            return View(musteriler);
        }

        // POST: Musterilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musteriler = await _context.Musteriler.FindAsync(id);
            if (musteriler != null)
            {
                _context.Musteriler.Remove(musteriler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusterilerExists(int id)
        {
            return _context.Musteriler.Any(e => e.MusteriId == id);
        }
    }
}
