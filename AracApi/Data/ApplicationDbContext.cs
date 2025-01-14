using Arac_Kirala.Models;
using Microsoft.EntityFrameworkCore;

namespace AracApi.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
		{
		}
		public DbSet<Yakit> Yakit { get; set; }


	}
}
