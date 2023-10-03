using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class MemberRepository : IMemberRepository
    {
        public readonly DataContext _context;

        public MemberRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Member> CreateAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public async Task<IEnumerable<Member>> GetAllASync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member?> GetById(int id)
        {
            return await _context.Members.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Member?> UpdateAsync(Member member)
        {
            var existingMember = await _context.Members.FirstOrDefaultAsync(x => x.Id == member.Id);

            if (existingMember != null)
            {
                _context.Entry(existingMember).CurrentValues.SetValues(member);
                await _context.SaveChangesAsync();
                return member;
            }

            return null;
        }

        public async Task<Member?> DeleteAsync(int id)
        {
            var existingMember = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMember != null)
            {
                _context.Members.Remove(existingMember);
                await _context.SaveChangesAsync();
                return existingMember;
            }

            return null;
        }
    }
}
