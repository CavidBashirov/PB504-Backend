using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_MVC.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _sliderService.GetAllAsync();
            var sliderInfo = await _sliderService.GetInfoAsync();
            SliderVMVC model = new()
            {
                Slider = sliders,
                SliderInfo = sliderInfo
            };
            return View(model);
        }
    }

    public class SliderVMVC
    {
        public IEnumerable<SliderUIVM> Slider { get; set; }
        public SliderInfoUIVM SliderInfo { get; set; }
    }
}
