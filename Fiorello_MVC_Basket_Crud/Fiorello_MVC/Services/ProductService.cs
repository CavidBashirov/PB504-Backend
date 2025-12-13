using Fiorello_MVC.Data;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Products;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductUIVM>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).Select(m => new ProductUIVM {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                CategoryId = m.CategoryId,
                Image = m.ProductImages.FirstOrDefault(m => m.IsMain).Image
            }).ToListAsync();
        }

        public async Task<decimal> GetPriceByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product.Price;
        }
    }
}
