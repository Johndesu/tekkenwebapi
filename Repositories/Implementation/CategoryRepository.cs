using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllASync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
