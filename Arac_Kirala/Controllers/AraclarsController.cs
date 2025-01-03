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
    public class AraclarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AraclarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Araclars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Araclars.Include(a => a.Modeller).Include(a => a.Vites).Include(a => a.Yakit).Include(a => a.Markalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Araclars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclars
                .Include(a => a.Modeller)
                .Include(a => a.Vites)
                .Include(a => a.Yakit)
                .FirstOrDefaultAsync(m => m.AracId == id);
            if (araclar == null)
            {
                return NotFound();
            }

            return View(araclar);
        }

        // GET: Araclars/Create
        public IActionResult Create()
        {
            ViewData["ModellerId"] = new SelectList(_context.Modellers, "ModellerId", "ModellerAdi");
            //dropdownlist olarak dolan alanlar
            ViewData["VitesId"] = new SelectList(_context.Vites, "VitesId", "VitesAdi");
            //bizim modeller 
            ViewData["YakitId"] = new SelectList(_context.Yakit, "YakitId", "YakitAdi");
            ViewData["MarkaId"] = new SelectList(_context.Markalar, "MarkaId", "MarkaAdi");
            return View();
        }

        // POST: Araclars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AracId,AracName,VitesId,YakitId,ModellerId,MarkaId,Depozito,KmLimit,Koltuk,Konum,Resim")] Araclar araclar,IFormFile Picture)
        {

            if(Picture == null)
            { 
                return NotFound();
            }
            else
            {

                string uzanti = Path.GetExtension(Picture.FileName);//dosyasını al
                string yeniisim=Guid.NewGuid().ToString()+uzanti;
                //dosyaya yeni bir isim türetiyorum
                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Arac_Resim/" + yeniisim);
                //dosyanın nereye kayıt olacağını yazıyoruz
                using(var stream=new FileStream(yol,FileMode.Create))
                {
                    Picture.CopyTo(stream);
                }
                araclar.Resim = yeniisim;
                //veritabanında var olan isme ata diyoruz
            }


            if (ModelState.IsValid)
            {
                _context.Add(araclar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModellerId"] = new SelectList(_context.Modellers, "ModellerId", "ModellerAdi");
            //dropdownlist olarak dolan alanlar
            ViewData["VitesId"] = new SelectList(_context.Vites, "VitesId", "VitesAdi");
            //bizim modeller 
            ViewData["YakitId"] = new SelectList(_context.Yakit, "YakitId", "YakitAdi");
            ViewData["MarkaId"] = new SelectList(_context.Markalar, "MarkaId", "MarkaAdi");
            return View(araclar);
        }

        // GET: Araclars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclars.FindAsync(id);
            if (araclar == null)
            {
                return NotFound();
            }
            ViewData["ModellerId"] = new SelectList(_context.Modellers, "ModellerId", "ModellerAdi");
            //dropdownlist olarak dolan alanlar
            ViewData["VitesId"] = new SelectList(_context.Vites, "VitesId", "VitesAdi");
            //bizim modeller 
            ViewData["YakitId"] = new SelectList(_context.Yakit, "YakitId", "YakitAdi");
            ViewData["MarkaId"] = new SelectList(_context.Markalar, "MarkaId", "MarkaAdi");
            return View(araclar);
        }

        // POST: Araclars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AracId,AracName,VitesId,YakitId,ModellerId,MarkaId,Depozito,KmLimit,Koltuk,Konum,Resim")] Araclar araclar,IFormFile Picture)
        {


            if (Picture == null)
            {
                return NotFound();
            }
            else
            {

                string uzanti = Path.GetExtension(Picture.FileName);//dosyasını al
                string yeniisim = Guid.NewGuid().ToString() + uzanti;
                //dosyaya yeni bir isim türetiyorum
                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Arac_Resim/" + yeniisim);
                //dosyanın nereye kayıt olacağını yazıyoruz
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Picture.CopyTo(stream);
                }
                araclar.Resim = yeniisim;
                //veritabanında var olan isme ata diyoruz
            }




            if (id != araclar.AracId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(araclar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AraclarExists(araclar.AracId))
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
            ViewData["ModellerId"] = new SelectList(_context.Modellers, "ModellerId", "ModellerAdi");
            //dropdownlist olarak dolan alanlar
            ViewData["VitesId"] = new SelectList(_context.Vites, "VitesId", "VitesAdi");
            //bizim modeller 
            ViewData["YakitId"] = new SelectList(_context.Yakit, "YakitId", "YakitAdi");
            ViewData["MarkaId"] = new SelectList(_context.Markalar, "MarkaId", "MarkaAdi");
            return View(araclar);
        }

        // GET: Araclars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclars
                .Include(a => a.Modeller)
                .Include(a => a.Vites)
                .Include(a => a.Yakit)
                .FirstOrDefaultAsync(m => m.AracId == id);
            if (araclar == null)
            {
                return NotFound();
            }

            return View(araclar);
        }

        // POST: Araclars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var araclar = await _context.Araclars.FindAsync(id);
            if (araclar != null)
            {
                _context.Araclars.Remove(araclar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AraclarExists(int id)
        {
            return _context.Araclars.Any(e => e.AracId == id);
        }
    }
}
