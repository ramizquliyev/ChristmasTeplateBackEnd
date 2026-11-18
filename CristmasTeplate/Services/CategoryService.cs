using CristmasTeplate.Data;
using CristmasTeplate.Services.Interfaces;
using CristmasTeplate.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var res = await _context.Categories.ToListAsync();

            return res.Select(m => new CategoryVM
            {
                Id = m.Id,
                Name = m.Name
            });
        }
    }
}
