using Microsoft.EntityFrameworkCore;
using DailyManager.Core.Entities;

namespace DailyManager.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserTask> Tasks { get; set; }
    public DbSet<User> Users { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasIndex(u => u.Email)
                .IsUnique();

            entity.Property(u => u.HashPassword)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(t => t.Description)
                .HasMaxLength(500);

            entity.HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.UserId);
        });

        base.OnModelCreating(modelBuilder);
    }
}

