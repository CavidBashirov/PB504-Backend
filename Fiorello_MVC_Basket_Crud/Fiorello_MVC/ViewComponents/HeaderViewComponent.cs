using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Baskets;
using Fiorello_MVC.ViewModels.Header;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiorello_MVC.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ILayoutService _layoutService;

        public HeaderViewComponent(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketUIVM> basketDatas = [];

            if (Request.Cookies["basket"] != null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketUIVM>>(Request.Cookies["basket"]);
            }

            int basketCount = basketDatas.Sum(m => m.ProductCount);
            decimal totalPrice = basketDatas.Sum(m => m.ProductCount * m.ProductPrice);
            var settings = await _layoutService.GetAllSettingsAsync();

            var model = new HeaderVM
            {
                BasketProductCount = basketCount,
                TotalPrice = totalPrice,
                HeaderLogo = settings["HeaderLogo"],
                Phone = settings["Phone"]
            };

            return View(model);
        }
    }
}
