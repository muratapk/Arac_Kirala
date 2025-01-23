using Arac_Kirala.Models;

namespace Arac_Kirala.DataO
{
	public class CartViewModel
	{
		public List<CartItem>CartItems { get; set; }
		public decimal GrandTotal { get; set; }
	}
}
