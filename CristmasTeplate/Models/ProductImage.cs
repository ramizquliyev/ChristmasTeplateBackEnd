namespace CristmasTeplate.Models
{
    public class ProductImage : BaseEntity
    {
        public string Name { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public bool IsMane { get; set; }
    }
}
