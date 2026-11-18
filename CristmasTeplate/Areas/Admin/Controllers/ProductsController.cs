using CristmasTeplate.Data;
using CristmasTeplate.Models;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        
        private readonly IProductService _productService;
        private readonly AppDbContext _context;
        public ProductsController(IProductService productService, AppDbContext context)
        {
            _productService = productService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var prodcuts = await _productService.GetAllAsync();
            return View(prodcuts);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductCreateVM model = new();
            model.Categories = await _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM reguest)
        {
            Product res = new();
            res.Title = reguest.Name;
            res.Description = reguest.Description;
            res.Price = reguest.Price;
            res.CategoryId = reguest.CategoryId;
            res.Composition = reguest.Composition;
            res.Style = reguest.Style;

            await _context.Products.AddAsync(res);
            await _context.SaveChangesAsync();

            ProductImage image = new();
            image.Name = reguest.Image;
            image.ProductId = res.Id;
            image.IsMane = true;

            await _context.ProductImages.AddAsync(image);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _context.Products.FindAsync(id);

            _context.Products.Remove(res);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var findedItem = await _context.Products.FindAsync(id);

            ProductEditVM res = new();
            res.Categories = await _context.Categories.Select(m=> new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            }).ToListAsync();
            res.Composition = findedItem.Composition;
            res.Name = findedItem.Title;
            res.Description = findedItem.Description;
            res.Price = findedItem.Price;
            res.Style = findedItem.Style;
            

            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditVM editVM)
        {
            var find = await _context.Products.Include(m=> m.ProductImages).FirstOrDefaultAsync(m=> m.Id == id);

            find.Title = editVM.Name;
            find.Description = editVM.Description;
            find.Price = editVM.Price;
            find.Composition = editVM.Composition;
            find.Style = editVM.Style;
            find.CategoryId = editVM.CategoryId;
            find.ProductImages.FirstOrDefault(m => m.IsMane).Name = editVM.Image;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
          var res = await _productService.GetDetailProductAsync(id);

            ProductInfoVM model = new();

            model.Title = res.Title;
            model.Description = res.Description;
            model.Price = res.Price;
            model.Style = res.Style;
            model.ProductImages = res.ProductImages;
            model.Composition = res.Composition;


          return View(model);
        }


        
    }
}
