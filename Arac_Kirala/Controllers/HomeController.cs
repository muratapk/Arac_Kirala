using Arac_Kirala.Context;
using Arac_Kirala.DataO;
using Arac_Kirala.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Arac_Kirala.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult RealetedCar()
		{
			
			return PartialView("RealtedList");
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Details(int ? id)
		{
			var liste = _context.Araclars.Include(x => x.Yakit).Include(x => x.Markalar).Include(x => x.Vites).Where(x => x.AracId == id)
	.FirstOrDefault();
			//tek bir araba bilgisine ulaþmak
			var arac = _context.Araclars.ToList();
			var aracViewModels =arac.Select(arac => new MarkViewModel
			{
				AracId = arac.AracId,
				MarkaId = arac.MarkaId,
				YakitId = arac.YakitId,
				AracName = arac.AracName
			}).ToList();

			ViewBag.Markalar=_context.Araclars.Where(x=>x.MarkaId==liste.MarkaId).ToList();
			//3 nolu ürün seç diyoruz alt kýsýmýnda bu 3 no baðlantýlý markasý 3 nolu ürün 
			//markasýna benzeyen araçlarý seç

			return View(liste);
		}
		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
