using Microsoft.EntityFrameworkCore;
using UsersCompanies.Domain.Entities;

namespace UsersCompanies.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<UserJob> UserJobs { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connecting lazy loading
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserJob>()
                    .HasKey(uj => new { uj.UserId, uj.JobId });

            modelBuilder.Entity<UserJob>()
               .HasOne(uj => uj.User)
               .WithMany() 
               .HasForeignKey(uj => uj.UserId)
               .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<UserJob>()
                .HasOne(uj => uj.Job)
                .WithMany() 
                .HasForeignKey(uj => uj.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserJob>()
                .HasIndex(uj => new { uj.UserId, uj.JobId });
        }
    }
}
