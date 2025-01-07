using Arac_Kirala.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace Arac_Kirala.Component
{
    public class FeaturedList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public FeaturedList(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var liste =await _context.Araclars.OrderByDescending(x=>x.AracId).ToListAsync();
            return View(liste);
        }
    }
}
