using CristmasTeplate.ViewModels.Product;

namespace CristmasTeplate.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductMainPageViewModel>> GetAllUIAsync();
        public Task<ProductDetailViewModel> GetDetailProductAsync(int id);
        public Task<IEnumerable<ProductVM>> GetAllAsync();
    }
}
