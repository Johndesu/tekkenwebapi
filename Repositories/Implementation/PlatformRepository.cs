using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class PlatformRepository : IPlatformRepository
    {

        public readonly DataContext _context;

        public PlatformRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Platform> CreateAsync(Platform platform)
        {
            await _context.Platforms.AddAsync(platform);
            await _context.SaveChangesAsync();

            return platform;
        }

        public async Task<IEnumerable<Platform>> GetAllASync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<Platform?> GetById(int id)
        {
            return await _context.Platforms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Platform?> UpdateAsync(Platform platform)
        {
            var existingPlatform = await _context.Platforms.FirstOrDefaultAsync(x => x.Id == platform.Id);

            if (existingPlatform != null)
            {
                _context.Entry(existingPlatform).CurrentValues.SetValues(platform);
                await _context.SaveChangesAsync();
                return platform;
            }

            return null;
        }

        public async Task<Platform?> DeleteAsync(int id)
        {
            var existingPlatform = await _context.Platforms.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPlatform != null)
            {
                _context.Platforms.Remove(existingPlatform);
                await _context.SaveChangesAsync();
                return existingPlatform;
            }

            return null;
        }
    }
}
