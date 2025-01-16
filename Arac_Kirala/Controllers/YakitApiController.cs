using Arac_Kirala.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Text;

namespace Arac_Kirala.Controllers
{
	public class YakitApiController : Controller
	{
		Uri _baseAddress = new Uri("https://localhost:7190/api");
     
		//url adres oluşturuldu
		private readonly HttpClient _httpClient;

		public YakitApiController()
		{
			_httpClient= new HttpClient();
			_httpClient.BaseAddress = _baseAddress;
			
		}

		//bir istemci oluştur
		[HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Yakit> yakits = new List<Yakit>();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Yakit");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                yakits = JsonConvert.DeserializeObject<List<Yakit>>(data);
            }

            return View(yakits);
        }

    }
}
