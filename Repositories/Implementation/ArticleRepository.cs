using Microsoft.EntityFrameworkCore;
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

        public async Task<Article> GetAsync(Article article)
        {
            await _context.Articles.ToListAsync();

            return article;
        }
    }
}
