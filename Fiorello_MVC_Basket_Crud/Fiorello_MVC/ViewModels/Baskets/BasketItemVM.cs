namespace Fiorello_MVC.ViewModels.Baskets
{
    public class BasketItemVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
