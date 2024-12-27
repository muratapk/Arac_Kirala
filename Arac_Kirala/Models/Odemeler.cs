using System.ComponentModel.DataAnnotations;

namespace Arac_Kirala.Models
{
	public class Odemeler
	{
		[Key]
        public int OdemeId { get; set; }
		public int RezervasyonId {  get; set; }	
		public int MusteriId { get;set; }
		public int AracId {  get; set; }
		public virtual Rezervasyon? Rezervasyon { get; set; }
		public virtual Araclar ? Araclar { get; set; }
		public virtual Musteriler? Musteriler { get; set; }	


    }
}
