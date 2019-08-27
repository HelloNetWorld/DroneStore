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
        public int TotalRegistrationsPercentageWeek { get; set; }
        public int TotalOrders { get; set; }
        public int TotalOrdersPercentageWeek { get; set; }
        public decimal TotalIncome { get; set; }
        public int TotalIncomePercentageWeek { get; set; }
        public IDictionary<string, int> Traffic { get; set; }
        public IDictionary<string, int> Visitors { get; set; }
    }
}
