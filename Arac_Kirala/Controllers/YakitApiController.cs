using Arac_Kirala.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Text;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Yakit yakit)
        {
            string data=JsonConvert.SerializeObject(yakit);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Yakit", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                // If no ID is provided, return to a different view or show an error message
                return RedirectToAction("Index");
            }

            try
            {
                // Make the DELETE request to remove the Yakit by ID
                HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Yakit/" + id.Value);

                if (response.IsSuccessStatusCode)
                {
                    // If deletion is successful, redirect to Index (or another view)
                    return RedirectToAction("Index");
                }
                else
                {
                    // If the response is not successful, handle the failure (e.g., log the error)
                    ModelState.AddModelError("", "An error occurred while deleting the Yakit.");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logging framework) and return to the index with an error message
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
                return RedirectToAction("Index");
            }
        }


    }
}
