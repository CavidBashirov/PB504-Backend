using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Products;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;
        public ProductService(AppDbContext context,
                              IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task CreateAsync(ProductCreateVM model)
        {
            List<ProductImage> images = [];

            foreach (var item in model.Images)
            {
                string fileName = _fileService.GenerateUniqueName(item.FileName);
                string path = _fileService.GeneratePath("assets/img", fileName);
                await _fileService.UploadAsync(item, path);

                images.Add(new ProductImage { Image = fileName });
            }

            images.FirstOrDefault().IsMain = true;

            Product product = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                ProductImages = images
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductVM>> GetAllAdminAsync()
        {
            return await _context.Products.Include(m => m.Category)
                                          .Include(m => m.ProductImages)
                                          .Select(m => new ProductVM
                                          {
                                              Id = m.Id,
                                              Name = m.Name,
                                              Category = m.Category.Name,
                                              Image = m.ProductImages.FirstOrDefault(m=> m.IsMain).Image,
                                          }).ToListAsync();
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
