using CristmasTeplate.Data;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.Basket;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Services
{
    public class BasketService : IBasketService
    {
        private readonly AppDbContext _context;
        public BasketService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<BasketUIVM>> GetAllUIAsync()
        {
            var products = await _context.Baskets.Include(p => p.Product).ThenInclude(c => c.Category).Include(i => i.Product.ProductImages).Select(m => new BasketUIVM
            {
                Id = m.Id,
                Name = m.Product.Title,
                Price = m.Product.Price,
                Description = m.Product.Description,
                MainImg = m.Product.ProductImages.FirstOrDefault(m => m.IsMane).Name,
                ProductId = m.Product.Id,
                Category = m.Product.Category.Name
            }).ToListAsync();

            return products;
        }
    }
}
