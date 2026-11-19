using CristmasTeplate.Data;
using CristmasTeplate.Models;
using CristmasTeplate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Contollers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService, AppDbContext context)
        {
            _basketService = basketService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var basketProducts = await _basketService.GetAllUIAsync();
            return View(basketProducts);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(int id)
        {
            var finded = await _context.Products.FindAsync(id);
            var vishListOrders = await _context.WishListItems.Include(m=> m.Product).ToListAsync(); 
            if (finded == null)
            {
                return NotFound();
            }
            if (vishListOrders.Any(m=> m.ProductId == finded.Id))
            {
                Basket basket = new();
                basket.ProductId = finded.Id;
                await _context.Baskets.AddAsync(basket);

                var products = vishListOrders.Where(m => m.ProductId == finded.Id).ToList();
                _context.WishListItems.RemoveRange(products);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            else
            {
                Basket basket = new();
                basket.ProductId = finded.Id;

                await _context.Baskets.AddAsync(basket);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var finded = await _context.Baskets.FindAsync(id);

            _context.Baskets.Remove(finded);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
