using Fiorello_MVC.ViewModels.Sliders;

namespace Fiorello_MVC.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderUIVM>> GetAllAsync();
        Task<SliderInfoUIVM> GetInfoAsync();
        Task<IEnumerable<SliderVM>> GetAllAdminAsync();
        Task CreateAsync(SliderCreateVM model);
        Task DeleteAsync(int id);
    }
}
