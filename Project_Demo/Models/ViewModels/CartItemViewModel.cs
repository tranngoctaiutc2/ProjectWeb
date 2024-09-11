namespace Project_Demo.Models.ViewModels
{
	public class CartItemViewModel
	{
		public List<CartItemViewModel> Items { get; set; }
		public decimal GrandTotal { get; set; }
	}
}
