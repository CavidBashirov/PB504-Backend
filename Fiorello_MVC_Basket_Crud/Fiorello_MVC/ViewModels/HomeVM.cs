using Fiorello_MVC.Models;
using Fiorello_MVC.ViewModels.Blogs;
using Fiorello_MVC.ViewModels.Categories;
using Fiorello_MVC.ViewModels.Experts;
using Fiorello_MVC.ViewModels.Products;
using Fiorello_MVC.ViewModels.Sliders;
using Fiorello_MVC.ViewModels.Surprises;
using Fiorello_MVC.ViewModels.Testimonials;

namespace Fiorello_MVC.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<BlogUIVM> Blogs { get; set; }
        public IEnumerable<ExpertUIVM> Experts { get; set; }
        public IEnumerable<TestimonialUIVM> Testimonials { get; set; }
        public IEnumerable<SliderUIVM> Sliders { get; set; }
        public IEnumerable<CategoryUIVM> Categories { get; set; }
        public IEnumerable<ProductUIVM> Products { get; set; }
        public SurpriseUIVM Surprises { get; set; }
        public SliderInfoUIVM SliderInfos { get; set; }
    }
}
