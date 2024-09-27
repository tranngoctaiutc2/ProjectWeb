using System.ComponentModel.DataAnnotations;

namespace Project_Demo.Models.ViewModels
{
	public class LoginViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Hãy nhập tên đăng nhập")]
		public string UserName { get; set; }
		[DataType(DataType.Password), Required(ErrorMessage = "Hãy nhập mật khẩu")]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }
	}
}
