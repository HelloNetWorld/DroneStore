using System;
using System.Collections.Generic;
using System.Linq;
using DroneStore.Services.Services.Orders;
using DroneStore.Web.Areas.Admin.Models;
using DroneStore.Web.Identity;
using Microsoft.AspNetCore.Identity;

namespace DroneStore.Web.Areas.Admin.Services
{
    public class AdminViewModelService : IAdminViewModelService
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public AdminViewModelService(IOrderItemService orderItemService,
            IOrderService orderService,
            UserManager<AppUser> userManager)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
            _userManager = userManager;
        }

        public DashboardViewModel PrepareDashboard()
        {
            var dashboard = new DashboardViewModel
            {
                TotalIncome = GetTotalIncome(),
                TotalIncomePercentageWeek = CalculateTotalIncomeWeekly(),
                TotalOrders = GetTotalOrders(),
                TotalOrdersPercentageWeek = CalculateTotalOrdersWeekly(),
                TotalRegistrations = GetTotalRegistrations(),
                TotalRegistrationsPercentageWeek = CalculateRegistrationsWeekly(),
                Traffic = GetTraffic(),
                Visitors = GetVisitors()
            };

            return dashboard;
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            foreach(var user in _userManager.Users)
            {
                string roles = string.Join(", ", _userManager.GetRolesAsync(user).Result);
                var userVM = new UserViewModel
                {
                    AppUser = user,
                    Roles = roles
                };

                yield return userVM;
            }
        }

        private decimal GetTotalIncome() =>
            _orderItemService.GetAll().Sum(oi => oi.Quantity * oi.UnitPrice);

        private int CalculateTotalIncomeWeekly()
        {
            var income = _orderItemService.GetAll().Sum(x => x.Quantity * x.UnitPrice);
            if (income == 0) return 0;

            var incomeWeekly = _orderItemService.GetAll()
                .Where(oi => IsWeekly(oi.CreationDate))
                .Sum(oi => oi.Quantity * oi.UnitPrice);

            return (int)Math.Round(100 * incomeWeekly / income);
        }

        private int GetTotalOrders() => _orderService.GetAll().Count();

        private int CalculateTotalOrdersWeekly() =>
            _orderService.GetAll().Where(o => IsWeekly(o.CreationDate))
            .Count();

        private int GetTotalRegistrations() =>
            _userManager.Users.Count();

        private int CalculateRegistrationsWeekly() =>
            _userManager.Users.AsEnumerable()
            .Where(u => IsWeekly(u.CreationDateInUtc))
            .Count();

        private IDictionary<string, int> GetTraffic()
        {
            return null;
        }

        private IDictionary<string, int> GetVisitors()
        {
            return null;
        }

        private static bool IsWeekly(DateTime date) =>
            (DateTime.UtcNow - date) < TimeSpan.FromDays(7);
    }
}
