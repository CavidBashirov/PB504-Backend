using System.ComponentModel.DataAnnotations;

namespace Fiorello_MVC.ViewModels.Categories
{
    public class CreateCategoryVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
