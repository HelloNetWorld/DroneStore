using System.Collections.Generic;

namespace DroneStore.Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Traffic = new Dictionary<string, int>();
            Visitors = new Dictionary<string, int>();
        }

        public int TotalRegistrations { get; set; }
        public int RegistrationsWeekly { get; set; }
        public int RegistrationsPercentageWeekly { get; set; }
        public int TotalOrders { get; set; }
        public int OrdersWeekly { get; set; }
        public int OrdersPercentageWeekly { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal IncomeWeekly { get; set; }
        public int IncomePercentageWeekly { get; set; }

        public IDictionary<string, int> Traffic { get; set; }
        public IDictionary<string, int> Visitors { get; set; }
    }
}
