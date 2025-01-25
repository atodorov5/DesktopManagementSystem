using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets for the entities
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Task)
                .HasForeignKey(c => c.TaskId)
                .IsRequired();

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.Users)
                .WithMany(u => u.Tasks);
        }
    }
}
