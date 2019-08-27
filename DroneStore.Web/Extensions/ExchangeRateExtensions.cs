using System;
using DroneStore.Core.Entities.Currency;

namespace DroneStore.Web.Extensions
{
    public static class ExchangeRateExtensions
    {
        public static bool IsOutOfDate(this ExchangeRate source) =>
            (DateTime.UtcNow - source.LastUpdateInUtc) > TimeSpan.FromHours(8);
    }
}
