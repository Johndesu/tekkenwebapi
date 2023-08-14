using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface IArticleRepository
    {
        Task<Article> CreateAsync(Article Article);
        Task<Article> GetAsync(Article Article);
    }
}
