using System.ComponentModel.DataAnnotations;

namespace Arac_Kirala.Models
{
	public class Vites
	{
		[Key]
        public int VitesId { get; set; }
		public string VitesAdi { get; set; } = string.Empty;
		public virtual List<Araclar> ? Araclars { get; set; }
    }
}
