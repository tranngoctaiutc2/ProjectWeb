using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Demo.Models;
using Project_Demo.Repository;
using System.ComponentModel.DataAnnotations;

namespace Project_Demo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly DataContext _dataContext;
		public ProductController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Products.OrderByDescending(p => p.Id).Include(p => p.Category).Include(b => b.Brand).ToListAsync());
		}
        public IActionResult Create()
        {
			ViewBag.Categories = new SelectList(_dataContext.Categories, "Id","Name");
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name");
            return View();
        }
        [HttpPost]
		[ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ProductModel product)
		{
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryID);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandID);
			if(ModelState.IsValid)
			{
                TempData["succes"] = "Model không lỗi";
            }
			else
			{
				TempData["error"] = "Model lỗi";
				List<String> errors	= new List<String>();
				foreach(var value in ModelState.Values)
				{
					foreach(var error in value.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}
                string errorMessage = string.Join("\n", errors);
				return BadRequest(errorMessage);
            }
			return View(product);
        }
    }
}
