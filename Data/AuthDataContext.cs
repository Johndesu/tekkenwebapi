using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TekkenPortugal.WebApi.Data
{
    public class AuthDataContext: IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public AuthDataContext(DbContextOptions<AuthDataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = _configuration["Roles:ReaderId"];
            var writerRoleId = _configuration["Roles:WriterId"];

            // Create Reader and Writer Role
            var roles = new List<IdentityRole> {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                }
            };

            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Create an Admin User
            var adminUserId = _configuration["Admin:AdminId"];
            var adminPassword = _configuration["Admin:Password"];
            var adminUser = _configuration["Admin:Username"];
            var adminEmail = _configuration["Admin:Email"];
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = adminUser,
                Email = adminEmail,
                NormalizedEmail = adminUserId.ToUpper(),
                NormalizedUserName = adminUserId.ToUpper(),
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, adminPassword);

            builder.Entity<IdentityUser>().HasData(admin);

            // Give Roles To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }

    }
}
