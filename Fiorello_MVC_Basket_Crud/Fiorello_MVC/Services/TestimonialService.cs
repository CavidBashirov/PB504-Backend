using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Testimonials;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly AppDbContext _context;
        public TestimonialService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TestimonialUIVM>> GetAllAsync()
        {
            return await _context.Testimonials.Select(m => new TestimonialUIVM
            {
                FullName = m.FullName,
                Position = m.Position,
                Image = m.Image,
                Comment = m.Comment
            }).ToListAsync();
        }
    }
}
