using DroneStore.Web.Models.Identity;
using FluentValidation;
using System;

namespace DroneStore.Web.Validators
{
	public class RegisterValidator : AbstractValidator<RegisterViewModel>
	{
		public RegisterValidator()
		{
			RuleFor(r => r.Email)
				.EmailAddress()
				.NotEmpty();
			RuleFor(r => r.Name)
				.NotEmpty();
			RuleFor(r => r.Password)
				.NotEmpty();
			RuleFor(r => r.RepeatPassword)
				.NotEmpty()
				.Equal(r => r.Password, StringComparer.Ordinal)
				.WithMessage("Passwords doesn't match!");
		}
	}
}
