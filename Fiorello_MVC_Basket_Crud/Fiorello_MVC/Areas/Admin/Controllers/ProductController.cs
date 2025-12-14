using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiorello_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,
                                 ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAdminAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAdminAsync();
            ViewBag.categories = categories.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Name });
            return View(); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAdminAsync();
                ViewBag.categories = categories.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Name });
                return View(request);
            }

            await _productService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }
    }
}
