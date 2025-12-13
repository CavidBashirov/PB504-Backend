namespace Fiorello_MVC.ViewModels
{
    public class CategoryDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
