using Microsoft.EntityFrameworkCore;
using UP_API.Models;

namespace UP_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplication>()
                .HasOne(a => a.Applicant)
                .WithMany()
                .HasForeignKey(a => a.ApplicantId);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "employer",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("employer123"),
                    Role = "Employer"
                }
            );
        }
    }
}
