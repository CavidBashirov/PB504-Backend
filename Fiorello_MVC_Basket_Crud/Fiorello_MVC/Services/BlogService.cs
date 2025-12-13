using Fiorello_MVC.Data;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Blogs;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BlogUIVM>> GetAllAsync()
        {
            return await _context.Blogs
                .Include(m => m.Images).Take(3)
                .Select(m => new BlogUIVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Date = m.Date,
                    Description = m.Description,
                    Image = m.Images.FirstOrDefault(m => m.IsMain).Image
                }).ToListAsync();

        }
    }
}
