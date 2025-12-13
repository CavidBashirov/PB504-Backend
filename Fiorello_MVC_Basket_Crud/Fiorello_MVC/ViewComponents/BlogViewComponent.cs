using Fiorello_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_MVC.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly ILayoutService _layoutService;

        public BlogViewComponent(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _layoutService.GetAllSettingsAsync();
            return View(sliders);
        }
    }
}
