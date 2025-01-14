using System.ComponentModel.DataAnnotations;

namespace Arac_Kirala.Models
{
	public class Yakit
	{
		[Key]
        public  int YakitId { get; set; }
		public string YakitAdi { get; set; } = string.Empty;
		
	}
}
