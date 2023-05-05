using Microsoft.AspNetCore.Mvc;

namespace WetherInDoom.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
