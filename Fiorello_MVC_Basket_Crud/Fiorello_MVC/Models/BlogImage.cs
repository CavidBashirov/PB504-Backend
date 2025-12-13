namespace Fiorello_MVC.Models
{
    public class BlogImage : BaseEntity
    {
        public string Image { get; set; }
        public bool IsMain { get; set; } = false;
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
