using LoanManagementSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Infrastructure.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
        {
        }

        public DbSet<LoanApplication> LoanApplications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanApplication>()
                .Property(l => l.ApplicantName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<LoanApplication>()
                .Property(l => l.LoanAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<LoanApplication>()
                .Property(l => l.InterestRate)
                .HasPrecision(5, 2);
        }
    }
}
