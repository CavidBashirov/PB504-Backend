namespace Fiorello_MVC.Models
{
    public class Testimonial : BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }

    }
}
