using Microsoft.EntityFrameworkCore;
using DailyManager.Core.Entities;

namespace DailyManager.Infra.Data;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserTask> Tasks { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserTask>()
                .HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }

