using Microsoft.AspNetCore.Mvc;

namespace WetherInDoom.Controllers
{
    public class PurchaseContent : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
