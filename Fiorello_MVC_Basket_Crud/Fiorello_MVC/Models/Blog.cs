namespace Fiorello_MVC.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ICollection<BlogImage> Images { get; set; }
    }
}
