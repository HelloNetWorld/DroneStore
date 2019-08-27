using System.Collections.Generic;

namespace DroneStore.Services.Currency.Provider
{
    public interface ICurrencyProvider
    {
        string Name { get; }
        Dictionary<string,double> GetQuotes();
    }
}
