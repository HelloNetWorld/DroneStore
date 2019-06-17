using System.ComponentModel.DataAnnotations;

namespace DroneStore.Web.Models.Identity
{
	public class RegisterViewModel
	{
		public string Name { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		public string RepeatPassword { get; set; }
	}
}
