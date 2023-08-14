using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllASync();
    }
}
