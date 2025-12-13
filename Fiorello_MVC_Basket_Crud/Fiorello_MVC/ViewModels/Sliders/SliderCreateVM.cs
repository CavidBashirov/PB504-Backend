using System.ComponentModel.DataAnnotations;

namespace Fiorello_MVC.ViewModels.Sliders
{
    public class SliderCreateVM
    {
        [Required]
        public List<IFormFile> NewImages { get; set; }
    }
}
