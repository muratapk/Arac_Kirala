using Arac_Kirala.Context;
using Arac_Kirala.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kirala.Controllers
{
    public class YakitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YakitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //database bağlanmak için DbContext nesnesi tanımlıyorum _context;


        //constructor yani otomatik nesne çağır çağırılmaz çalışsın
        public IActionResult Index()
        {
            //index dosyası tamamiyle yakitların listesi olacak
            var liste = _context.Yakit.ToList();
            //tüm listeyi gelir onunda view nesnesine gönder
            //index view nesnesine gidecek
            return View(liste);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Yakit gelen) 
        { 
          if(ModelState.IsValid)
            {
                _context.Yakit.Add(gelen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit (int? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            var bul = _context.Yakit.Find(id);
            if(bul== null)
            {
                return NotFound();
            }
            return View(bul);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var bul = _context.Yakit.Find(id);
            if (bul == null)
            {
                return NotFound();
            }
            return View(bul);
        }
        [HttpPost]
        public IActionResult Edit(Yakit gelen)
        {
            if(gelen.YakitId==null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Yakit.Update(gelen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Yakit gelen)
        {
            if (gelen.YakitId == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Yakit.Remove(gelen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
