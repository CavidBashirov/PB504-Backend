using Fiorello_MVC.Models;
using Fiorello_MVC.ViewModels.Testimonials;

namespace Fiorello_MVC.Services.Interfaces
{
    public interface ITestimonialService
    {
        Task<IEnumerable<TestimonialUIVM>> GetAllAsync();
    }
}
