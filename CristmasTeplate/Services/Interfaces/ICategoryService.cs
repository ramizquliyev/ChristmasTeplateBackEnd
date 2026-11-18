using CristmasTeplate.ViewModels.Category;

namespace CristmasTeplate.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryVM>> GetAllAsync();
    }
}
