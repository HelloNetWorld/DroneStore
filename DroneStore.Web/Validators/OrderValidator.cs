using DroneStore.Web.Models.Order;
using FluentValidation;

namespace DroneStore.Web.Validators
{
    public class OrderValidator : AbstractValidator<OrderViewModel>
    {
        public OrderValidator()
        {
			RuleFor(o => o.Address1)
				.NotEmpty()
				.Length(20, 250);

			RuleFor(o => o.CustomerEmail)
				.NotEmpty()
				.EmailAddress();

			RuleFor(o => o.FirstName)
				.NotEmpty();

			RuleFor(o => o.LastName)
				.NotEmpty();

			RuleFor(o => o.PhoneNumber)
				.NotEmpty()
				.Length(10, 20);

			RuleFor(o => o.ZipCode)
				.NotEmpty();
		}
    }
}
