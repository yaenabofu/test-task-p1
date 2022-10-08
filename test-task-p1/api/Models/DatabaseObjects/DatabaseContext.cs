using Microsoft.EntityFrameworkCore;
using System;

namespace api.Models.DatabaseObjects
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasMany(x => x.Workers).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            InitialData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected void InitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new Company[]
            {
            new Company
            {
                Id = 1,
                Name = "Company1",
                Description = "First company"
            }
            });

            modelBuilder.Entity<Worker>().HasData(
            new Worker
            {
                Id = 1,
                Name = "Worker1",
                Surname = "firstWorker",
                ThirdName = "firstWorker",
                Birthday = DateTime.Now,
                Snils = "snils",
                CompanyId = 1
            });

            modelBuilder.Entity<Company>().HasData(new Company[]
            {
            new Company
            {
                Id = 2,
                Name = "Company2",
                Description = "Second company"
            }
            });

            modelBuilder.Entity<Worker>().HasData(
            new Worker
            {
                Id = 2,
                Name = "Worker2",
                Surname = "secondWorker",
                ThirdName = "secondWorker",
                Birthday = DateTime.Now,
                Snils = "snils",
                CompanyId = 2
            });
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
