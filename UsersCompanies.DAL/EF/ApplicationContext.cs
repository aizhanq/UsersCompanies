using Microsoft.EntityFrameworkCore;
using UsersCompanies.DAL.Entities;

namespace UsersCompanies.DAL.EF
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
               .WithMany()  // Указываем свойство, через которое происходит связь с User
               .HasForeignKey(uj => uj.UserId)
               .OnDelete(DeleteBehavior.Restrict); // При необходимости можно изменить поведение удаления

            modelBuilder.Entity<UserJob>()
                .HasOne(uj => uj.Job)
                .WithMany()  // Указываем свойство, через которое происходит связь с Job
                .HasForeignKey(uj => uj.JobId)
                .OnDelete(DeleteBehavior.Restrict); // При необходимости можно изменить поведение удаления

            modelBuilder.Entity<UserJob>()
                .HasIndex(uj => new { uj.UserId, uj.JobId });
        }
    }
}
