using Fiorello_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ILayoutService _layoutService;

        public FooterViewComponent(ILayoutService layoutService)
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
