using System.Collections.Generic;

namespace DroneStore.Web.Infrastructure
{
    public interface IErrors
    {
        ICollection<string> Errors { get; set; }
    }
}
