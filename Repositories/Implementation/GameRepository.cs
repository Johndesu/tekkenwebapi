using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class GameRepository : IGameRepository
    {
        public readonly DataContext _context;

        public GameRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetById(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Game?> UpdateAsync(Game game)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(x => x.Id == game.Id);

            if (existingGame != null)
            {
                _context.Entry(existingGame).CurrentValues.SetValues(game);
                await _context.SaveChangesAsync();
                return game;
            }

            return null;
        }

        public async Task<Game?> DeleteAsync(int id)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGame != null)
            {
                _context.Games.Remove(existingGame);
                await _context.SaveChangesAsync();
                return existingGame;
            }

            return null;
        }
    }
}
