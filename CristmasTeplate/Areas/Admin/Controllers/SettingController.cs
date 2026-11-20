using CristmasTeplate.Data;
using CristmasTeplate.Models;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISettingService _settingService;
        public SettingController(AppDbContext context, ISettingService settingService)
        {
            _context = context;
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var settings = await _settingService.GetAllAsync();
            return View(settings);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SettingCreateVM createVM)
        {
            Setting setting = new();
            setting.Key = createVM.Key;
            setting.Value = createVM.Value;

            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string keyName)
        {
            var finded = await _context.Settings.FirstOrDefaultAsync(m=> m.Key == keyName);

            _context.Settings.Remove(finded);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string keyName)
        {
            var finded = await _context.Settings.FirstOrDefaultAsync(m => m.Key == keyName);

            SettingEditVM editVM = new();
            editVM.Key = finded.Key;
            editVM.Value = finded.Value;

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string keyName,SettingEditVM editVM)
        {
            var finded = await _context.Settings.FirstOrDefaultAsync(m => m.Key == keyName);


            finded.Key = editVM.Key;
            finded.Value = editVM.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
