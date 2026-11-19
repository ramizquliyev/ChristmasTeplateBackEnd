using CristmasTeplate.Data;
using CristmasTeplate.Models;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.Image;
using CristmasTeplate.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVM>> GetAllAsync()
        {
            var res = await _context.Products.Include(m => m.ProductImages).Include(n => n.Category).Select(m=> new ProductVM
            {
                Name = m.Title,
                Description = m.Description,
                Id = m.Id,
                Price = m.Price,
                Composition = m.Composition,
                CategoryName = m.Category.Name,
                MainImg = m.ProductImages.FirstOrDefault(m=> m.IsMane).Name,
                Style = m.Style

            }).ToListAsync();

            return res;
        }

        public async Task<IEnumerable<ProductMainPageViewModel>> GetAllUIAsync()
        {
            var res = await _context.Products.Include(m=> m.Category).Include(p=> p.ProductImages).ToListAsync();

            return res.Select(m => new ProductMainPageViewModel
            {
                Title = m.Title,
                Price = m.Price,
                MainImg = m.ProductImages.FirstOrDefault(m => m.IsMane).Name,
                CategoryName = m.Category.Name,
                Id = m.Id
            });
        }

        public async Task<ProductDetailViewModel> GetDetailProductAsync(int id)
        {
            var res = await _context.Products.Include(i => i.ProductImages).Include(c => c.Category).FirstOrDefaultAsync(p=> p.Id == id);

            ProductDetailViewModel product = new();
            product.Description = res.Description;
            product.Id = res.Id;
            product.Title = res.Title;
            product.Price = res.Price;
            product.Style = res.Style;
            product.ProductImages = res.ProductImages.Select(m => new ProductImageUIVM
            {
                Name = m.Name,
                IsMane = m.IsMane
            }).ToList();
            product.Composition = res.Composition;
            

            return product;
        }
    }
}
