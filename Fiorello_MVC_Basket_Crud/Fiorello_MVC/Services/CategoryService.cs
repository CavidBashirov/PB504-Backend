using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateCategoryVM model)
        {
            var category = new Category
            {
                Id = model.Id,
                Name = model.Name
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Categories.FindAsync(id);

            if (result is null) return;

            _context.Categories.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAdminAsync()
        {
            return await _context.Categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();   
        }

        public async Task<IEnumerable<CategoryUIVM>> GetAllAsync()
        {
            return await _context.Categories.Include(m => m.Products).Where(m => m.Products.Count != 0).Select(c => new CategoryUIVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
        }

        public async Task<CategoryVM> GetByIdAsync(int id)
        {
            var result = await _context.Categories.Select(m => new CategoryVM
            {
                Id = m.Id,
                Name = m.Name
            }).FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task UpdateAsync(UpdateCategoryVM model)
        {
            var result = await _context.Categories.FindAsync(model.Id);

            if (result is null) return;

            result.Name = model.Name;

            await _context.SaveChangesAsync();
        }
    }
}
