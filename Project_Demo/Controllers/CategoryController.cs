using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Demo.Models;
using Project_Demo.Repository;

namespace Project_Demo.Controllers
{
    public class CategoryController : Controller
    {
        public readonly DataContext _dataContext;
        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
            if (category == null) return RedirectToAction("Index");
            var productsByCategory = _dataContext.Products.Where(p => p.CategoryID == category.Id);
            return View(await productsByCategory.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
