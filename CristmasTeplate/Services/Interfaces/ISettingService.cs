using CristmasTeplate.ViewModels.Setting;

namespace CristmasTeplate.Services.Interfaces
{
    public interface ISettingService
    {
        public Task<Dictionary<string,string>> GetAllAsync();
        public Task<IEnumerable<SettingUIVM>> GetAllUIAsync();
    }
}
