using Microsoft.EntityFrameworkCore;

namespace SecuredSqlSample.Web
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
            : base(options) {}

        public DbSet<Profile> Profiles { get; set; }
    }
}