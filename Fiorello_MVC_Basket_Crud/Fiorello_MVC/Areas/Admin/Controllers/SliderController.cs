using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _sliderService.GetAllAdminAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _sliderService.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
            var existSlider = await _sliderService.GetByIdAsync(id.Value);
            return View(new SliderEditVM { ExistImage = existSlider.Image});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM request)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid)
            {
                var existSlider = await _sliderService.GetByIdAsync(id.Value);
                return View(new SliderEditVM { ExistImage = existSlider.Image});
            }

            await _sliderService.EditAsync(id.Value, request);
            return RedirectToAction(nameof(Index));
        }
    }
}
