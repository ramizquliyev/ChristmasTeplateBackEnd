using CristmasTeplate.Data;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.Setting;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        public SettingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            var settings = await _context.Settings.ToDictionaryAsync(m=> m.Key,o=> o.Value);
            return settings;
        }

        public async Task<IEnumerable<SettingUIVM>> GetAllUIAsync()
        {
            return await _context.Settings.Select(m => new SettingUIVM
            {
                Id = m.Id,
                Key = m.Key,
                Value = m.Value
            }).ToListAsync();
        }
    }
}
