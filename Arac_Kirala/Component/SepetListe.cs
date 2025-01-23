using Arac_Kirala.Context;
using Arac_Kirala.DataO;
using Arac_Kirala.Models;
using Arac_Kirala.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kirala.Component
{
    public class SepetListe:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SepetListe(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart")?? new List<CartItem>();
            CartViewModel cartVm = new CartViewModel()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)

            };
            return View(cartVm);
        }
    }
}
