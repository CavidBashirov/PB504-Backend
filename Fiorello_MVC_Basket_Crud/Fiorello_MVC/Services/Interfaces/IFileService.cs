namespace Fiorello_MVC.Services.Interfaces
{
    public interface IFileService
    {
        string GenerateUniqueName(string fileName);
        string GeneratePath(string folder, string fileName);
        Task UploadAsync(IFormFile file, string path);
        void Delete(string path);
    }
}
