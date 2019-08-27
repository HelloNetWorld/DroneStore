using System;

namespace DroneStore.Core.Entities.Currency
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Quote { get; set; }
        public decimal Rate { get; set; }
        public DateTime LastUpdateInUtc { get; set; }
    }
}
