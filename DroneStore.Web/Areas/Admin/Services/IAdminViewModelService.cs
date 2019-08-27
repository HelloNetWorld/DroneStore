using System.Collections.Generic;
using DroneStore.Web.Areas.Admin.Models;

namespace DroneStore.Web.Areas.Admin.Services
{
    public interface IAdminViewModelService
    {
        DashboardViewModel PrepareDashboard();
        IEnumerable<UserViewModel> GetUsers();
    }
}
