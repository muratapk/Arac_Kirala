using System.ComponentModel.DataAnnotations;

namespace Arac_Kirala.Models
{
	public class Markalar
	{
		[Key]
        public int MarkaId { get; set; }
		public string MarkaAdi { get; set; } = string.Empty;
		public virtual List<Araclar>? Araclars { get; set; }
	}
}
