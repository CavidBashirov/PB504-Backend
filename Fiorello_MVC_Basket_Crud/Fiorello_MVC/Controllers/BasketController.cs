using Fiorello_MVC.Data;
using Fiorello_MVC.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fiorello_MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BasketUIVM> basketDatas = [];

            if (Request.Cookies["basket"] != null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketUIVM>>(Request.Cookies["basket"]);
            }

            List<BasketItemVM> items = [];

            foreach (var item in basketDatas)
            {
                var dbProduct = await _context.Products.Include(m => m.ProductImages)
                                                        .Include(m => m.Category)
                                                        .FirstOrDefaultAsync(m => m.Id == item.ProductId);

                items.Add(new BasketItemVM
                {
                    Id = item.ProductId,
                    Image = dbProduct.ProductImages.FirstOrDefault(m => m.IsMain).Image,
                    Name = dbProduct.Name,
                    Category = dbProduct.Category.Name,
                    Price = dbProduct.Price,
                    Count = item.ProductCount 
                });
            }

            BasketDetailVM model = new()
            {
                Items = items,
                TotalPrice = basketDatas.Sum(m => m.ProductCount * m.ProductPrice)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id)
        {
            List<BasketUIVM> basketDatas = [];

            if (Request.Cookies["basket"] != null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketUIVM>>(Request.Cookies["basket"]);
            }

            var existItem = basketDatas.FirstOrDefault(m => m.ProductId == id);

            if (existItem != null)
            {
                basketDatas.Remove(existItem);
                Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketDatas));
            }

            var totalPrice = basketDatas.Sum(m => m.ProductCount * m.ProductPrice);

            return Ok(new { TotalPrice = totalPrice});
        }
    }
}
