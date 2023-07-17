using Microsoft.EntityFrameworkCore;

namespace TekkenPortugal.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Article> Article => Set<Article>();
    }
}
