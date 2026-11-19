using CristmasTeplate.Data;
using CristmasTeplate.Models;
using CristmasTeplate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Contollers
{
    public class WishListController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWishListService _wishListService;
        public WishListController(AppDbContext context, IWishListService wishListService)
        {
            _context = context;
            _wishListService = wishListService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _wishListService.GetAllUIAsync();
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id)
        {
            var finded = await _context.Products.Include(i => i.ProductImages).FirstOrDefaultAsync(m => m.Id == id);

            WishListItem wishListItem = new();
            wishListItem.ProductId = finded.Id;

            await _context.WishListItems.AddAsync(wishListItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var finded = await _context.WishListItems.FindAsync(id);

            _context.WishListItems.Remove(finded);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(int id)
        {
            var finded = await _context.WishListItems.FindAsync(id);

            Basket basket = new();
            basket.ProductId = finded.ProductId;
            await _context.Baskets.AddAsync(basket);
            _context.WishListItems.Remove(finded);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
        }

        
    }
}
