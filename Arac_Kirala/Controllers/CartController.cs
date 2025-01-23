using Arac_Kirala.Context;
using Arac_Kirala.DataO;
using Arac_Kirala.Models;
using Arac_Kirala.Oturum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Arac_Kirala.Oturum.SessionOturum;
namespace Arac_Kirala.Controllers
{
	public class CartController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CartController(ApplicationDbContext context)
		{
			_context = context;
		}


		//veritabanı bağlantısı buraya oluştur.
		public IActionResult Index()
		{
			//List<CartItem> Items =HttpContext.Session.GetJson<List<CartItem>>("Cart")?? new List<CartItem>();
			// Session'dan CartItem verisini alma
			List<CartItem> Items = HttpContext.Session.GetJson<List<CartItem>>("CartItem") ?? new List<CartItem>();

			//session içindeki verileri items nesnesine ata 
			//session içinde herhangi bir veri varmı var ise listeyi al
			//
			CartViewModel cartVm = new()
			{
				CartItems = Items,
				GrandTotal = Items.Sum(x => x.Quantity * x.Price)
			};


			return View(cartVm);
		}
		//ekrana toplam satış miktarı ve adedi getirmesi için 
		public async Task<IActionResult>Add(int id)
		{
			Araclar arac = _context.Araclars.Find(id);
			List<CartItem> items=HttpContext.Session.GetJson<List<CartItem>>("Cart")?? new List<CartItem>();
			CartItem cartitem = items.FirstOrDefault(x => x.AracId == id);
			if (cartitem != null)
			{
				items.Add(new CartItem(arac));
			}
			else
			{
				cartitem.Quantity += 1;
			}
			HttpContext.Session.SetJson("Cart", items);
			return RedirectToAction(Request.Headers["Referer"].ToString());

		}

		public async Task<IActionResult>Decrease(int id)
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
			CartItem cartItem=cart.Where(x=>x.AracId==id).FirstOrDefault();	
			if(cartItem.Quantity>1)
			{
				cartItem.Quantity -= 1;
			}
			if(cartItem.Quantity > 0) {
				HttpContext.Session.SetJson("Cart", cart);
			  }
			TempData["Mesa"] = "Ürün Sepeten Silindi";
			return RedirectToAction("Index");
		}
		public async Task<IActionResult>Remove(int id)
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
			cart.RemoveAll(c => c.AracId == id);
			if(cart.Count > 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);

			}
			TempData["Mesaj"] = "Sepet Boşaldı";
			return RedirectToAction("Index");

		}
		public async Task<IActionResult>Clear()
		{
			HttpContext.Session.Remove("Cart");
			return RedirectToAction("Index");
		}

	}
}
