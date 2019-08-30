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
        #region Fields

        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        #endregion

        #region Constructor

        public AdminViewModelService(IOrderItemService orderItemService,
            IOrderService orderService,
            UserManager<AppUser> userManager)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
            _userManager = userManager;
        }

        #endregion

        #region Public Methods

        public DashboardViewModel PrepareDashboard()
        {
            var dashboard = new DashboardViewModel
            {
                TotalIncome = GetTotalIncome(),
                IncomeWeekly = GetIncomeWeekly(),
                IncomePercentageWeekly = GetIncomePercentageWeekly(),
                TotalOrders = GetTotalOrders(),
                OrdersWeekly = GetOrdersWeekly(),
                OrdersPercentageWeekly = GetOrdersPercentageWeekly(),
                TotalRegistrations = GetTotalRegistrations(),
                RegistrationsWeekly = GetRegistrationsWeekly(),
                RegistrationsPercentageWeekly = GetRegistrationsPercentageWeekly(),
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

        #endregion Public Methods

        #region Private Methods

        private decimal GetTotalIncome() =>
            _orderItemService.GetAll().Sum(oi => oi.Quantity * oi.UnitPrice);

        private int GetIncomePercentageWeekly()
        {
            var income = GetTotalIncome();
            if (income == 0) return 0;

            return (int)Math.Round(100 * GetIncomeWeekly() / income);
        }

        private int GetTotalOrders() => _orderService.GetAll().Count();

        private int GetOrdersPercentageWeekly()
        {
            var total = GetTotalOrders();
            if (total == 0) return 0;

            return (int)Math.Round(100.0 * GetOrdersWeekly() / total);
        }

        private int GetTotalRegistrations() =>
            _userManager.Users.Count();

        private int GetRegistrationsPercentageWeekly() =>
            _userManager.Users
            .Where(u => IsWeekly(u.CreationDateInUtc))
            .Count();

        private decimal GetIncomeWeekly() =>
            _orderItemService.GetAll()
            .Where(oi => IsWeekly(oi.CreationDate))
            .Sum(oi => oi.Quantity * oi.UnitPrice);

        private int GetOrdersWeekly() =>
            _orderService.GetAll().Where(o => IsWeekly(o.CreationDate)).Count();

        private int GetRegistrationsWeekly() =>
            _userManager.Users
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

        #endregion

        #region Utilities

        private static bool IsWeekly(DateTime date) =>
            (DateTime.UtcNow - date) < TimeSpan.FromDays(7);

        #endregion 
    }
}
