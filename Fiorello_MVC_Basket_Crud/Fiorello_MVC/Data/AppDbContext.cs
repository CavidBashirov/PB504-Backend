using Fiorello_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<SliderInfo> sliderInfos { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Surprise> Surprises { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
