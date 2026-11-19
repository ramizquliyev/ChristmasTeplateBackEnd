using CristmasTeplate.ViewModels.Basket;

namespace CristmasTeplate.Services.Interfaces
{
    public interface IBasketService
    {
        public Task<IEnumerable<BasketUIVM>> GetAllUIAsync();

    }
}
