using DroneStore.Web.Models.Identity;
using FluentValidation;

namespace DroneStore.Web.Validators
{
	public class LoginValidator : AbstractValidator<LoginViewModel>
	{
		public LoginValidator()
		{
			RuleFor(l => l.Email)
				.EmailAddress()
				.NotEmpty();
			RuleFor(l => l.Password)
				.NotEmpty();	
		}
	}
}
