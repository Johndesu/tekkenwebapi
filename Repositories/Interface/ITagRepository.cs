using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface ITagRepository
    {
        Task<Tag> CreateAsync(Tag tag);

        Task<IEnumerable<Tag>> GetAllASync();

        Task<Tag?> GetById(int id);

        Task<Tag?> UpdateAsync(Tag tag);

        Task<Tag?> DeleteAsync(int id);
    }
}
