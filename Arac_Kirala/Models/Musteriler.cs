using System.ComponentModel.DataAnnotations;

namespace Arac_Kirala.Models
{
	public class Musteriler
	{
		[Key]
        public int MusteriId { get; set; }
		public string MusterAd { get; set; } = string.Empty;
		public string CepTel { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Adres { get; set; } = string.Empty;
		public string MusteriKul { get; set; } = string.Empty;
		public string MusteriSifre { get;set; }=string.Empty;
		public virtual List<Odemeler>? Odemelers { get; set;}
    }
}
