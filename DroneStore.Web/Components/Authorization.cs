using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class Authorization : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
