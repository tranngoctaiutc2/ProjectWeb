using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Demo.Models;
using Project_Demo.Repository;

namespace Project_Demo.Controllers
{
	public class BrandController : Controller
	{
		public readonly DataContext _dataContext;
		public BrandController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<IActionResult> Index(string Slug = "")
		{
			BrandModel brand = _dataContext.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
			if (brand == null) return RedirectToAction("Index");
			var productsByBrand = _dataContext.Products.Where(p => p.BrandID == brand.Id);
			return View(await productsByBrand.OrderByDescending(p => p.Id).ToListAsync());
		}
	}
}
