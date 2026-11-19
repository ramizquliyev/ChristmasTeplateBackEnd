namespace CristmasTeplate.Models
{
    public class WishListItem : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
