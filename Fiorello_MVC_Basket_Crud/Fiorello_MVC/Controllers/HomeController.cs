using System.Diagnostics;
using System.Text.Json.Serialization;
using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels;
using Fiorello_MVC.ViewModels.Baskets;
using Fiorello_MVC.ViewModels.Blogs;
using Fiorello_MVC.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Fiorello_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;
        private readonly ISliderService _sliderService;
        private readonly ISurpriseService _surpriseService;
        private readonly IExpertService _expertService;
        private readonly ITestimonialService _testimonialService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public HomeController(AppDbContext context,
                              ISliderService sliderService,
                              IBlogService blogService,
                              ISurpriseService surpriseService,
                              IExpertService expertService,
                              ITestimonialService testimonialService,
                              ICategoryService categoryService,
                              IProductService productService)
        {
            _context = context;
            _blogService = blogService;
            _sliderService = sliderService;
            _surpriseService = surpriseService;
            _expertService = expertService;
            _testimonialService = testimonialService;
            _categoryService = categoryService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Blogs = await _blogService.GetAllAsync(),
                Experts = await _expertService.GetAllAsync(),
                Testimonials = await _testimonialService.GetAllAsync(),
                
                SliderInfos = await _sliderService.GetInfoAsync(),
                Surprises = await _surpriseService.GetAllAsync(),
                Categories = await _categoryService.GetAllAsync(),
                Products = await _productService.GetAllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(int id)
        {
            List<BasketUIVM> basketDatas = [];

            if (Request.Cookies["basket"] != null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketUIVM>>(Request.Cookies["basket"]);
            }

            decimal price = await _productService.GetPriceByIdAsync(id);

            var data = basketDatas.FirstOrDefault(b => b.ProductId == id);

            if (data is not null)
            {
               data.ProductCount++;
            }
            else
            {
                basketDatas.Add(new BasketUIVM { ProductId = id, ProductPrice = price, ProductCount = 1 });
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketDatas));

            int basketCount = basketDatas.Sum(m => m.ProductCount);
            decimal totalPrice = basketDatas.Sum(m => m.ProductCount * m.ProductPrice);

            return Ok(new { count = basketCount, total = totalPrice });
        }
    }
}
