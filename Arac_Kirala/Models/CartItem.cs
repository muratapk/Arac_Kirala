namespace Arac_Kirala.Models
{
	public class CartItem
	{
		public CartItem()
		{
		}
		public CartItem(Araclar arac)
		{
			AracId = arac.AracId;
			AracName = arac.AracName;
			Quantity = 1;
			Price =Convert.ToDecimal(arac.Depozito);
			Image = arac.Resim;
		}
		public long AracId { get; set; }
		public string AracName { get; set; }
		public int Quantity { get; set; }
		public Decimal Price { get; set; }	
		public string Image { get; set; }	

		public decimal Total
		{
			get{ return Quantity * Price; } }
		}
	   
	}

