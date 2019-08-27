using DroneStore.Web.Areas.Admin.Models;
using FluentValidation;

namespace DroneStore.Web.Areas.Admin.Validators
{
    public class CreateItemValidator : AbstractValidator<CreateItemViewModel>
    {
        public CreateItemValidator()
        {
            RuleFor(i => i.Item.Name)
                .NotEmpty()
                .Length(0, 150);

            RuleFor(i => i.Item.Price)
                .NotEmpty()
                .ScalePrecision(2, 18);

            RuleFor(i => i.Item.Brand)
                .NotEmpty()
                .Length(0, 150);

            RuleFor(i => i.Item.Quantity)
                .NotEmpty();
        }
    }
}
