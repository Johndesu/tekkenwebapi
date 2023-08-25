using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {

        public readonly DataContext _context;

        public RoleRepository(DataContext dbContext) {
            _context = dbContext;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<IEnumerable<Role>> GetAllASync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role?> UpdateAsync(Role role)
        {
            var existingRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == role.Id);

            if (existingRole != null)
            {
                _context.Entry(existingRole).CurrentValues.SetValues(role);
                await _context.SaveChangesAsync();
                return role;
            }

            return null;
        }

        public async Task<Role?> DeleteAsync(int id)
        {
            var existingRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRole != null)
            {
                _context.Roles.Remove(existingRole);
                await _context.SaveChangesAsync();
                return existingRole;
            }

            return null;
        }
    }
}
