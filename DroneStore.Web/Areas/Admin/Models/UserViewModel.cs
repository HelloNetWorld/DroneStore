using DroneStore.Web.Identity;

namespace DroneStore.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        public AppUser AppUser { get; set; }
        public string Roles { get; set; }
    }
}
