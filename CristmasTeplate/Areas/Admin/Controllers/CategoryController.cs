using CristmasTeplate.Data;
using CristmasTeplate.Models;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(AppDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            Category res = new();
            res.Name = category.Name;

            await _context.Categories.AddAsync(res);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var finded = await _context.Categories.FindAsync(id);

            CategoryEditVM model = new();
            model.Name = finded.Name;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryEditVM editVM)
        {
            var finded = await _context.Categories.FindAsync(id);

            finded.Name = editVM.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
