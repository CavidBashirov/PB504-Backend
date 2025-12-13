using Fiorello_MVC.ViewModels.Products;

namespace Fiorello_MVC.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductUIVM>> GetAllAsync();
        Task<decimal> GetPriceByIdAsync(int id);
    }
}
