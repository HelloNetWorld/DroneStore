using System.Threading.Tasks;
using DroneStore.Web.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static ViewResult Validate<T>(this Controller controller,
            T model, IValidator<T> validator) where T : IErrors
        {
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid) return null;

            foreach (var error in validationResult.Errors)
            {
                model.Errors.Add(error.ToString());
            }

            return controller.View(model);
        }

        public static async Task<IActionResult> ValidateAsync<T>(this Controller controller,
            T model, IValidator<T> validator) where T : IErrors
        {
            var validationResult = await validator.ValidateAsync(model);

            if (validationResult.IsValid) return null;

            foreach (var error in validationResult.Errors)
            {
                model.Errors.Add(error.ToString());
            }

            return controller.View(model);
        }
    }
}
