using Microsoft.EntityFrameworkCore;
using System.Data;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext _context;

        public ArticleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Article> CreateAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return article;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.Include(x => x.Categories).ToListAsync();
        }

        public async Task<Article?> GetById(int id)
        {
            return await _context.Articles.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Article?> UpdateAsync(Article article)
        {
            var existingArticle = await _context.Articles.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == article.Id);

            if (existingArticle != null)
            {
                // Update Article
                _context.Entry(existingArticle).CurrentValues.SetValues(article);

                // Update Category
                existingArticle.Categories = article.Categories;

                await _context.SaveChangesAsync();
                return article;
            }

            return null;
        }

        public async Task<Article?> DeleteAsync(int id)
        {
            var existingArticle = await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (existingArticle != null)
            {
                _context.Articles.Remove(existingArticle);
                await _context.SaveChangesAsync();
                return existingArticle;
            }

            return null;
        }
    }
}
