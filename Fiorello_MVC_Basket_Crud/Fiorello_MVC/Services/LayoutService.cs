using Fiorello_MVC.Data;
using Fiorello_MVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
        public class LayoutService : ILayoutService
        {
            private readonly AppDbContext _context;
            public LayoutService(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Dictionary<string, string>> GetAllSettingsAsync()
            {
                return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
            }
        }
}
