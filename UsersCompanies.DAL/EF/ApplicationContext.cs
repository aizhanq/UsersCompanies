using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.Entities;

namespace UsersCompanies.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;

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
               .HasForeignKey(uj => uj.UserId);

            modelBuilder.Entity<UserJob>()
                .HasOne(uj => uj.Job)
                .WithMany()
                .HasForeignKey(uj => uj.JobId);

            modelBuilder.Entity<UserJob>()
                .HasIndex(uj => new { uj.UserId, uj.JobId });
        }
    }
}
