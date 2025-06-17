using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
