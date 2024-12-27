using System.ComponentModel.DataAnnotations;

namespace Arac_Kirala.Models
{
	public class Rezervasyon
	{
		[Key]
        public int RezervasyonId { get; set; }
		public string AlisTarihi { get; set; } = string.Empty;
		public string AlisSaati { get; set; } = string.Empty;
		public string BirakTarih { get; set; } = string.Empty;
		public string BirakSaati { get; set; } = string.Empty;
		public virtual List<Odemeler>? Odemelers { get; set; }
	}
}
