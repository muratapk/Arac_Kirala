using Arac_Kirala.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Arac_Kirala.Context
{
	public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,int>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
		{
		}
		public DbSet<Araclar>Araclars { get; set; }
		public DbSet<Vites> Vites { get; set; }	
		public DbSet<Yakit> Yakit { get; set; }	
		public DbSet<Odemeler> Odemeler { get; set;}
		public DbSet<Markalar> Markalar { get; set; }	
		public DbSet<Musteriler> Musteriler { get; set; }	
		public DbSet<Modeller> Modellers { get; set; }	
		public DbSet<Rezervasyon> Rezervasyons { get; set; } 
	}
}
