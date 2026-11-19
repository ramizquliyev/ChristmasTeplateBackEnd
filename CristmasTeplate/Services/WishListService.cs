using CristmasTeplate.Data;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.WishListItem;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Services
{
    public class WishListService : IWishListService
    {
        private readonly AppDbContext _context;
        public WishListService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WishListItemUIVM>> GetAllUIAsync()
        {
            return await _context.WishListItems.Include(m => m.Product).ThenInclude(i => i.ProductImages).Select(m => new WishListItemUIVM
            {
                Id = m.Id,
                Name = m.Product.Title,
                Price = m.Product.Price,
                MainImage = m.Product.ProductImages.FirstOrDefault(m => m.IsMane).Name,
                ProductId = m.Product.Id
            }).ToListAsync();

        }
    }
}
