namespace Fiorello_MVC.Services.Interfaces
{
    public interface ILayoutService
    {
        Task<Dictionary<string, string>> GetAllSettingsAsync();
    }
}
