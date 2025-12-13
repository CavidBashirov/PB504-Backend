using Fiorello_MVC.ViewModels.Experts;

namespace Fiorello_MVC.Services.Interfaces
{
    public interface IExpertService
    {
        Task<IEnumerable<ExpertUIVM>> GetAllAsync();
    }
}
