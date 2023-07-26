using Microsoft.EntityFrameworkCore;

namespace TekkenPortugal.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<Article> Articles => Set<Article>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Tag> Tags => Set<Tag>();
    }
}
