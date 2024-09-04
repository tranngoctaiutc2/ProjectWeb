using Microsoft.AspNetCore.Mvc;

namespace Project_Demo.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View("~/Views/Checkout/Index");
        }
    }
}
