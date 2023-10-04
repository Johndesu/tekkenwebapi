using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface IMemberRepository
    {
        Task<Member> CreateAsync(Member member);

        Task<IEnumerable<Member>> GetAllASync();

        Task<Member?> GetById(int id);

        Task<Member?> UpdateAsync(Member member);

        Task<Member?> DeleteAsync(int id);
    }
}
