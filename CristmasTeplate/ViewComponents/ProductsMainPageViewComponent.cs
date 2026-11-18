using CristmasTeplate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.ViewComponents
{
    public class ProductsMainPageViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        public ProductsMainPageViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllUIAsync();
            return View(products);
        }
    }
}
