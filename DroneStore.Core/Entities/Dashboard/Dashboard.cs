using System;
using System.Collections.Generic;

namespace DroneStore.Core.Entities.Dashboard
{
    public class Dashboard
    {
        public int TotalRegistrations { get; set; }
        public int TotalRegistrationsPercentageDaily { get; set; }
        public int TotalOrders { get; set; }
        public int TotalOrdersPercentageDaily { get; set; }
        public decimal TotalIncome { get; set; }
        public int TotalIncomePercentageDaily { get; set; }
        public IDictionary<int, int> Traffic { get; set; }
        public IDictionary<int, int> Visitors { get; set; }
        public DateTime CreatedInUtc { get; set; }
    }
}
