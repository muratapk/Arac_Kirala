using Arac_Kirala.DataO;
using Arac_Kirala.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kirala.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult PageNotFound()
        {
            return View();

        }

        [HttpPost]  
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result =await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, true);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "MyAccount");
            }
            return View();

		}
    }
}
