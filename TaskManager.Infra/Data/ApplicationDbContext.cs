using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;

namespace TaskManager.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<StatusTask> Status { get; set; }


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

        modelBuilder.Entity<TaskItem>(entity =>
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

            entity.HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId);
        });

        modelBuilder.Entity<StatusTask>(entity =>
        {
            entity.HasKey(ts => ts.Id);

            entity.Property(ts => ts.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        base.OnModelCreating(modelBuilder);
    }
}

