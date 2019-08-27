using DroneStore.Web.Areas.Admin.Models;
using FluentValidation;

namespace DroneStore.Web.Areas.Admin.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserViewModel>
    {
        public EditUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(u => u.Roles)
                .NotEmpty()
                .Matches(@"\w+(, \w+)*")
                .WithMessage("Invalid roles format!");

            RuleFor(u => u.UserName)
                .NotEmpty();
        }
    }
}
