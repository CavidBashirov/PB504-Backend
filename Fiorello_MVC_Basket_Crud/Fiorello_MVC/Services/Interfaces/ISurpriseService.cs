using Fiorello_MVC.ViewModels.Sliders;
using Fiorello_MVC.ViewModels.Surprises;

namespace Fiorello_MVC.Services.Interfaces
{
    public interface ISurpriseService
    {
        Task<SurpriseUIVM> GetAllAsync();
    }
}
