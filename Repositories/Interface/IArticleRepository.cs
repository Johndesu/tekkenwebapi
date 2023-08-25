using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface IArticleRepository
    {
        Task<Article> CreateAsync(Article Article);

        Task<IEnumerable<Article>> GetAllAsync();

        Task<Article?> GetById(int id);

        Task<Article?> UpdateAsync(Article Article);

        Task<Article?> DeleteAsync(int id);
    }
}
