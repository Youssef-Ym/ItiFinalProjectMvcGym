using ItiFinalProjectMvcGym.Models;
using Microsoft.EntityFrameworkCore;

namespace ItiFinalProjectMvcGym.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<GymClass> GymClasses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure 1:M (Trainer -> GymClass)
            modelBuilder.Entity<GymClass>()
                .HasOne(c => c.Trainer)
                .WithMany(t => t.GymClasses)
                .HasForeignKey(c => c.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure M:M via Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Member)
                .WithMany(m => m.Enrollments)
                .HasForeignKey(e => e.MemberId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.GymClass)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.GymClassId);
        }
    }
}