using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface IPlatformRepository
    {
        Task<Platform> CreateAsync(Platform platform);

        Task<IEnumerable<Platform>> GetAllASync();

        Task<Platform?> GetById(int id);

        Task<Platform?> UpdateAsync(Platform platform);

        Task<Platform?> DeleteAsync(int id);
    }
}
