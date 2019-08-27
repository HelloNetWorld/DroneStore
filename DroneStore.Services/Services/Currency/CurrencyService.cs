using System;
using System.Collections.Generic;
using System.Linq;
using DroneStore.Core.Entities.Currency;
using DroneStore.Data;
using DroneStore.Services.Currency.Provider;

namespace DroneStore.Services.Currency
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyProvider _currencyProvider;
        private readonly IRepository<ExchangeRate> _exchangeRateRep;

        public CurrencyService(ICurrencyProvider currencyProvider,
            IRepository<ExchangeRate> exchangeRateRep)
        {
            _currencyProvider = currencyProvider;
            _exchangeRateRep = exchangeRateRep;
        }

        public ExchangeRate GetLiveExchangeRate(string source, string quote)
        {
            var quotes = _currencyProvider.GetQuotes();

            if (quotes.ContainsKey($"{source}{quote}"))
            {
                var exchangeRate = new ExchangeRate
                {
                    LastUpdateInUtc = DateTime.Now.ToUniversalTime(),
                    Quote = quote,
                    Source = source,
                    Rate = (decimal)quotes[$"{source}{quote}"]
                };

                return exchangeRate;
            }

            return null;
        }

        public IEnumerable<ExchangeRate> GetLiveExchangeRates
        {
            get
            {
                var quotes = _currencyProvider.GetQuotes();
                var exchangeRates = new List<ExchangeRate>();

                foreach(var quote in quotes)
                {
                    var exchangeRate = new ExchangeRate
                    {
                        LastUpdateInUtc = DateTime.Now.ToUniversalTime(),
                        Quote = quote.Key.Substring(0, 3),
                        Source = quote.Key.Substring(3, 3),
                        Rate = (decimal)quote.Value
                    };

                    exchangeRates.Add(exchangeRate);
                }

                return exchangeRates;
            }
        }
       
        public ExchangeRate GetLocalExchangeRate(string source, string quote) =>
            _exchangeRateRep.EntitiesReadOnly.FirstOrDefault(r => r.Source == source && r.Quote == quote);

        public IEnumerable<ExchangeRate> GetLocalExchangeRates => _exchangeRateRep.EntitiesReadOnly;

        public void UpdateLocalExchangeRates()
        {
            foreach (var exchangeRate in GetLiveExchangeRates)
            {
                if (_exchangeRateRep.EntitiesReadOnly
                    .Any(er => er.Source == exchangeRate.Source && er.Quote == exchangeRate.Quote))
                    _exchangeRateRep.Update(exchangeRate);
                _exchangeRateRep.Insert(exchangeRate);
            }
        }
    }
}
