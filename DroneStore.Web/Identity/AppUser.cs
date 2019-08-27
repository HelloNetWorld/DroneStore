using System;
using Microsoft.AspNetCore.Identity;

namespace DroneStore.Web.Identity
{
	public class AppUser : IdentityUser
	{
        public AppUser() =>
            CreationDateInUtc = DateTime.UtcNow;
        public DateTime CreationDateInUtc { get; set; }
	}
}
