using System.ComponentModel.DataAnnotations;

namespace Fiorello_MVC.ViewModels.Sliders
{
    public class SliderEditVM
    {
        public string? ExistImage { get; set; }
        [Required]
        public IFormFile NewImage { get; set; }
    }
}
