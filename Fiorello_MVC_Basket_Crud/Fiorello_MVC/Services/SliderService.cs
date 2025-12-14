using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Fiorello_MVC.Services.Interfaces;
using Fiorello_MVC.ViewModels.Sliders;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_MVC.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;
        public SliderService(AppDbContext context, IFileService fileService)
        { 
            _context = context;
            _fileService = fileService;
        }

        public async Task CreateAsync(SliderCreateVM model)
        {
            foreach (var image in model.NewImages)
            {
                string fileName = _fileService.GenerateUniqueName(image.FileName);

                string path = _fileService.GeneratePath("assets/img", fileName);

                await _fileService.UploadAsync(image, path);

                await _context.AddAsync(new Slider { Image = fileName });
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dbSlider = await _context.sliders.FindAsync(id);
            string existPath = _fileService.GeneratePath("assets/img", dbSlider.Image);
            _fileService.Delete(existPath);
            _context.sliders.Remove(dbSlider);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, SliderEditVM model)
        {
            var dbSlider = await _context.sliders.FindAsync(id);
            string oldPath = _fileService.GeneratePath("assets/img", dbSlider.Image);
            _fileService.Delete(oldPath);

            string fileName = _fileService.GenerateUniqueName(model.NewImage.FileName);
            string newPath = _fileService.GeneratePath("assets/img", fileName);
            await _fileService.UploadAsync(model.NewImage, newPath);

            dbSlider.Image = fileName;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderVM>> GetAllAdminAsync()
        {
            return await _context.sliders.Select(m => new SliderVM { Id = m.Id, Image = m.Image }).ToListAsync();
        }

        public async Task<IEnumerable<SliderUIVM>> GetAllAsync()
        {
            return await _context.sliders.Select(m => new SliderUIVM { Image = m.Image }).ToListAsync();
        }

        public async Task<SliderVM> GetByIdAsync(int id)
        {
            var dbSldier = await _context.sliders.FindAsync(id);
            return new SliderVM { Id = dbSldier.Id, Image = dbSldier.Image };
        }

        public async Task<SliderInfoUIVM> GetInfoAsync()
        {
           SliderInfoUIVM? sliderInfo = await _context.sliderInfos
            .Select(m => new SliderInfoUIVM
            {
                Title = m.Title,
                Description = m.Description,
                Image = m.Image
            }).FirstOrDefaultAsync();

            return sliderInfo;
        }
    }
}
