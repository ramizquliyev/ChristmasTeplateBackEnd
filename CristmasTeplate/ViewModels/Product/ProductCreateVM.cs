using Microsoft.AspNetCore.Mvc.Rendering;

namespace CristmasTeplate.ViewModels.Product
{
    public class ProductCreateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Composition { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string Style { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
