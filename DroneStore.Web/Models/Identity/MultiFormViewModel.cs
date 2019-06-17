using System.Collections.Generic;

namespace DroneStore.Web.Models.Identity
{
	public class MultiFormViewModel
	{
		public MultiFormViewModel()
		{
			Login = new LoginViewModel();
			Register = new RegisterViewModel();
			ValidationErrors = new List<string>();
		}

		public LoginViewModel Login { get; set; }

		public RegisterViewModel Register { get; set; }

		public ICollection<string> ValidationErrors { get; set; }
	}
}
