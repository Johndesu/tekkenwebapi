using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ImageMedia> ImagesMedia { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Game> Games { get; set; }
    }
}
