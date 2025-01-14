using Arac_Kirala.Models;
using AracApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Collections;

namespace AracApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class YakitController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public YakitController(ApplicationDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Yakit>>> GetListe()
		{
			try
			{
				var yakits = await _context.Yakit.ToListAsync();
				if (yakits == null || !yakits.Any())
				{
					return NotFound("No Yakit records found.");
				}
				return Ok(yakits);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		[HttpPost]
		public IActionResult AddYakit(Yakit yakit)
		{
			_context.Add(yakit);
			_context.SaveChanges();
			return Ok();
		}
		[HttpGet("id")]
		public async Task<ActionResult<Yakit>> GetYakit(int id)
		{
			return await _context.Yakit.FindAsync(id);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteYakit(int id)
		{
			// Find the Yakit object asynchronously
			var yakit = await _context.Yakit.FirstOrDefaultAsync(x => x.YakitId == id);

			// Check if the Yakit object was found
			if (yakit == null)
			{
				// If not found, return a NotFound response
				return NotFound($"Yakit with ID {id} not found.");
			}

			// Remove the Yakit from the DbContext
			_context.Yakit.Remove(yakit);

			// Save changes to the database
			await _context.SaveChangesAsync();

			// Return a NoContent response (HTTP 204) to indicate successful deletion
			return NoContent();
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<Yakit>> UpdateYakit(int id, Yakit gelen)
		{
			// Find the Yakit entity asynchronously
			var result = await _context.Yakit.FirstOrDefaultAsync(x => x.YakitId == id);

			// If the Yakit is not found, return a 404 Not Found response
			if (result == null)
			{
				return NotFound($"Yakit with ID {id} not found.");
			}

			// Update the properties of the found Yakit entity
			result.YakitAdi = gelen.YakitAdi;
			// Add other properties to be updated as needed
			// result.AnotherProperty = gelen.AnotherProperty;

			// Save the changes to the database
			await _context.SaveChangesAsync();

			// Return a NoContent response (HTTP 204) to indicate the update was successful
			return NoContent();
		}


	}
}
