using Microsoft.EntityFrameworkCore;

namespace api.Models.DatabaseObjects
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
