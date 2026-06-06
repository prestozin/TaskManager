using Microsoft.EntityFrameworkCore;
using DailyManager.Core.Entities;

namespace DailyManager.Infra.Data;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<DailyTask> Tasks { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }

