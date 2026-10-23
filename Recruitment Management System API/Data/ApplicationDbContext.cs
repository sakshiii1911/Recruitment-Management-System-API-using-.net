using Microsoft.EntityFrameworkCore;
using Recruitment_Management_System_API.Entities;

namespace Recruitment_Management_System_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobApplication> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Salary needs a precision, otherwise EF warns you
            modelBuilder.Entity<Job>()
                .Property(j => j.Salary)
                .HasPrecision(18, 2);

            // Store the status as text ("Applied") instead of a number (0)
            modelBuilder.Entity<JobApplication>()
                .Property(a => a.Status)
                .HasConversion<string>();

            // Unique emails
            modelBuilder.Entity<Recruiter>()
                .HasIndex(r => r.Email).IsUnique();
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email).IsUnique();
        }
    }
}
