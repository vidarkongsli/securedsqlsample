using Microsoft.EntityFrameworkCore;

namespace SecuredSqlSample.Web
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\tmp\profiles.db");
        }
    }
}