using System.ComponentModel.DataAnnotations;

namespace DroneStore.Web.Models.Identity
{
	public class LoginViewModel
	{
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name ="Remember me")]
		public bool RememberMe { get; set; }
	}
}
