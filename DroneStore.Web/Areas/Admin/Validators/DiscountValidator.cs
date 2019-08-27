using DroneStore.Web.Areas.Admin.Models;
using FluentValidation;

namespace DroneStore.Web.Areas.Admin.Validators
{
    public class DiscountValidator : AbstractValidator<DiscountViewModel>
    {
        public DiscountValidator()
        {
            RuleFor(d => d.ExpireDate)
                .NotEmpty()
                .Must(d => !d.Equals(default))
                .WithMessage("Wrong date format!");

            RuleFor(d => d.NewPrice)
                .NotEmpty()
                .ScalePrecision(2, 18);

            RuleFor(d => d.OldPrice)
                .NotEmpty()
                .ScalePrecision(2, 18);
        }
    }
}
