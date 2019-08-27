using System.Linq;
using DroneStore.Services.Currency;
using DroneStore.Web.Extensions;
using DroneStore.Web.Models.Currency;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class Currency : ViewComponent
    {
        private readonly ICurrencyService _currencyService;

        public Currency(ICurrencyService currencyService) =>
            _currencyService = currencyService;

        public IViewComponentResult Invoke()
        {
            var eurRub = GetRate("EUR", "RUB");
            var usdRub = GetRate("USD", "RUB");
            var model = new ExchangeRateViewModel
            {
                EurRubRate = eurRub,
                UsdRubRate = usdRub
            };

            return View(model);
        }

        private string GetRate(string source, string quote)
        {
            var exchangeRate = _currencyService.GetLocalExchangeRates
                .FirstOrDefault(er => er.Quote == quote && er.Source == source);

            if (exchangeRate == null || exchangeRate.IsOutOfDate())
            {
                _currencyService.UpdateLocalExchangeRates();
                exchangeRate = _currencyService.GetLocalExchangeRates
                    .FirstOrDefault(er => er.Quote == quote && er.Source == source);
                if (exchangeRate == null) return "0.00";
            }

            return exchangeRate.Rate.ToString("c");
        }
    }
}
