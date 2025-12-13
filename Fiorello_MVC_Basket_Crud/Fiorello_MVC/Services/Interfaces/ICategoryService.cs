using Fiorello_MVC.ViewModels.Categories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fiorello_MVC.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryUIVM>> GetAllAsync();
        Task<IEnumerable<CategoryVM>> GetAllAdminAsync();
        Task<CategoryVM> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task CreateAsync(CreateCategoryVM model);
        Task UpdateAsync(UpdateCategoryVM model);
    }
}
