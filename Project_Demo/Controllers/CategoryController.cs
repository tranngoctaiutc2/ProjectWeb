using Microsoft.AspNetCore.Mvc;

namespace Project_Demo.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
