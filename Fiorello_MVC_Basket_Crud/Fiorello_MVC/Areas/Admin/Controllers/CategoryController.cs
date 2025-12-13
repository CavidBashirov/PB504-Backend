using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllAdminAsync());
        }

        public async Task<IActionResult> DetailAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _categoryService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category is null) return NotFound();
            var updatedCategory = new UpdateCategoryVM
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(updatedCategory);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _categoryService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();

        }
    }
}
