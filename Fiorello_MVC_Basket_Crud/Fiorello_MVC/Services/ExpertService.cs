using Fiorello_MVC.Data;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Experts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiorello_MVC.Services
{
    public class ExpertService : IExpertService
    {
        private readonly AppDbContext _context;
        public ExpertService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ExpertUIVM>> GetAllAsync()
        {
            return await _context.Experts.Select(m => new ExpertUIVM
            {
                FullName = m.FullName,
                Position = m.Position,
                Image = m.Image
            }).ToListAsync();
        }
    }
}
