using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class TagRepository : ITagRepository
    {
        public readonly DataContext _context;

        public TagRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return tag;
        }

        public async Task<IEnumerable<Tag>> GetAllASync()
        {
            return await _context.Tags.ToListAsync();
        }
        
        public async Task<Tag?> GetById(int id)
        {
            return await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);

            if (existingTag != null)
            {
                _context.Entry(existingTag).CurrentValues.SetValues(tag);
                await _context.SaveChangesAsync();
                return tag;
            }

            return null;
        }

        public async Task<Tag?> DeleteAsync(int id)
        {
            var existingTag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTag != null)
            {
                _context.Tags.Remove(existingTag);
                await _context.SaveChangesAsync();
                return existingTag;
            }

            return null;
        }
    }
}
