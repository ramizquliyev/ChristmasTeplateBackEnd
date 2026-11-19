namespace CristmasTeplate.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public string Composition { get; set; }
        public string Style { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
