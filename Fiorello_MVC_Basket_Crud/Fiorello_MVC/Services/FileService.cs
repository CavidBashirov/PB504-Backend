using Fiorello_MVC.Services.Interfaces;

namespace Fiorello_MVC.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public string GeneratePath(string folder, string fileName)
        {
            return Path.Combine(_env.WebRootPath, folder, fileName);
        }

        public string GenerateUniqueName(string fileName)
        {
            return Guid.NewGuid().ToString() + "-" + fileName;
        }

        public async Task UploadAsync(IFormFile file, string path)
        {
            using FileStream stream = new(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}
