using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface IRoleRepository
    {
        Task<Role> CreateAsync(Role role);

        Task<IEnumerable<Role>> GetAllASync();

        Task<Role?> GetById(int id);

        Task<Role?> UpdateAsync(Role role);

        Task<Role?> DeleteAsync(int id);
    }
}
