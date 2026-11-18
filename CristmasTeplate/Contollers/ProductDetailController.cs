using CristmasTeplate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.Contollers
{
    public class ProductDetailController : Controller
    {
        private readonly IProductService _productService;
        public ProductDetailController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var res = await _productService.GetDetailProductAsync(id);

            return View(res);
        }
    }
}
