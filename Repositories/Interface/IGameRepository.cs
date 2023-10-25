using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface IGameRepository
    {
        Task<Game> CreateAsync(Game Game);

        Task<IEnumerable<Game>> GetAllAsync();

        Task<Game?> GetById(int id);

        Task<Game?> UpdateAsync(Game Game);

        Task<Game?> DeleteAsync(int id);
    }
}
