using Fiorello_MVC.Data;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Sliders;
using Fiorello_MVC.ViewModels.Surprises;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
    public class SurpriseService : ISurpriseService
    {
        private readonly AppDbContext _context;
        public SurpriseService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SurpriseUIVM> GetAllAsync()
        {
            SurpriseUIVM? sliders = await _context.Surprises
                .Select(s => new SurpriseUIVM
                {
                    Title = s.Title,
                    Description = s.Description,
                    Image = s.Image
                }).FirstOrDefaultAsync();

            return sliders;
        }
    }
}
