using CristmasTeplate.ViewModels.Image;

namespace CristmasTeplate.ViewModels.Product
{
    public class ProductInfoVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Composition { get; set; }
        public string Style { get; set; }
        public List<ProductImageUIVM> ProductImages { get; set; }
    }
}
