using System.Collections.Generic;
using DroneStore.Core.Entities.Currency;

namespace DroneStore.Services.Currency
{
    public interface ICurrencyService
    {
        ExchangeRate GetLiveExchangeRate(string source, string quote);
        IEnumerable<ExchangeRate> GetLiveExchangeRates { get; }
        ExchangeRate GetLocalExchangeRate(string source, string quote);
        IEnumerable<ExchangeRate> GetLocalExchangeRates { get; }
        void UpdateLocalExchangeRates();
    }
}
