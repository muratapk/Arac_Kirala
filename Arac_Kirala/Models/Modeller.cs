using System.ComponentModel.DataAnnotations;

namespace Arac_Kirala.Models
{
	public class Modeller
	{
		[Key]
        public int ModellerId { get; set; }
		public string ModellerAdi { get; set; } = string.Empty;
		public virtual List<Araclar>? Araclars { get; set; }
	}
}
