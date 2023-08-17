using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllASync();

        Task<Category?> GetById(int id);

        Task<Category?> UpdateAsync(Category category);

        Task<Category?> DeleteAsync(int id);
    }
}
