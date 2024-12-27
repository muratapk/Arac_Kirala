using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Arac_Kirala.Models
{
	public class Araclar
	{
		[Key]
		public int AracId { get; set; }
		public string AracName { get; set; } = string.Empty;
		public int? VitesId { get;set; }
		public int? YakitId { get; set; }	
		public int? ModellerId { get; set; }
		public int ? MarkaId { get;set; }
        public int? Depozito { get; set; }
		public int? KmLimit { get; set; }
		public int? Koltuk { get;set; }
		public string Konum { get; set; }=string.Empty;
		public string Resim { get; set; } = string.Empty;
		public virtual Vites? Vites { get; set; }
		public virtual Yakit? Yakit { get; set; }
		public virtual Modeller ? Modeller { get; set; }
		public virtual Markalar? Markalar { get; set; }
		public virtual List<Odemeler>? Odemelers { get; set; }

	}
}
