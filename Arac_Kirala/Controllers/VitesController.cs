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
    public class VitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vites.ToListAsync());
        }

        // GET: Vites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vites = await _context.Vites
                .FirstOrDefaultAsync(m => m.VitesId == id);
            if (vites == null)
            {
                return NotFound();
            }

            return View(vites);
        }

        // GET: Vites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VitesId,VitesAdi")] Vites vites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vites);
        }

        // GET: Vites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vites = await _context.Vites.FindAsync(id);
            if (vites == null)
            {
                return NotFound();
            }
            return View(vites);
        }

        // POST: Vites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VitesId,VitesAdi")] Vites vites)
        {
            if (id != vites.VitesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VitesExists(vites.VitesId))
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
            return View(vites);
        }

        // GET: Vites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vites = await _context.Vites
                .FirstOrDefaultAsync(m => m.VitesId == id);
            if (vites == null)
            {
                return NotFound();
            }

            return View(vites);
        }

        // POST: Vites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vites = await _context.Vites.FindAsync(id);
            if (vites != null)
            {
                _context.Vites.Remove(vites);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VitesExists(int id)
        {
            return _context.Vites.Any(e => e.VitesId == id);
        }
    }
}
