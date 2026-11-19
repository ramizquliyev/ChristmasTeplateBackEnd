using CristmasTeplate.ViewModels.WishListItem;

namespace CristmasTeplate.Services.Interfaces
{
    public interface IWishListService
    {
        public Task<IEnumerable<WishListItemUIVM>> GetAllUIAsync();
    }
}
