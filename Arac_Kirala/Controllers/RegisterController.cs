using Arac_Kirala.DataO;
using Arac_Kirala.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kirala.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;

		public RegisterController(UserManager<AppUser> usermanager)
		{
			_usermanager = usermanager;
		}

		public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(DtoUserView dtoUserView)
        {
            Random random = new Random();
            int code = 0;
            code = random.Next(10000, 100000);
            AppUser appuser = new AppUser()
            {
                FirstName = dtoUserView.FirstName,
                LastName = dtoUserView.LastName,
                UserName = dtoUserView.UserName,
                Email = dtoUserView.Email,
                City=dtoUserView.City,
                EmailConfirmed=true,
                ConfirmCode= code,
            };
            var result =await _usermanager.CreateAsync(appuser, dtoUserView.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
             
            return View();
        }
    }
}
