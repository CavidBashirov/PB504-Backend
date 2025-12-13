using Fiorello_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_MVC.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ILayoutService _layoutService;

        public TestimonialViewComponent(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _layoutService.GetAllSettingsAsync();
            return View(settings);
        }
    }
}
