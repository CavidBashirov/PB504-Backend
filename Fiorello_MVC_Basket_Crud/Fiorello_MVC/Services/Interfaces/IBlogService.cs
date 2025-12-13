using Fiorello_MVC.ViewModels.Blogs;

namespace Fiorello_MVC.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogUIVM>> GetAllAsync();
    }
}
