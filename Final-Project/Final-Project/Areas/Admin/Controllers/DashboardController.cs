using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
