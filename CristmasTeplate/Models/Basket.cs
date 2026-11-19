namespace CristmasTeplate.Models
{
    public class Basket : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
