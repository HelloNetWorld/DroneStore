using System.Collections.Generic;
using DroneStore.Web.Infrastructure;

namespace DroneStore.Web.Areas.Admin.Models
{
    public class EditUserViewModel : IErrors
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }

        public ICollection<string> Errors { get; set; } = new List<string>();
    }
}
