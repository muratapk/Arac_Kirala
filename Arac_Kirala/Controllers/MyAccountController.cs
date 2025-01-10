using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kirala.Controllers
{
	public class MyAccountController : Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}
}
