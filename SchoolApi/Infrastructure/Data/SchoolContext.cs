using Microsoft.EntityFrameworkCore;
using SchoolApi.Domain.Entities;
using SchoolApi.Models;

namespace SchoolApi.Infrastructure.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.SetNull); // If teacher is deleted, set TeacherId to null

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentId)
                .IsUnique()
                .HasFilter("[StudentId] IS NOT NULL");

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique()
                .HasFilter("[CourseCode] IS NOT NULL");

            modelBuilder.Entity<Student>()
                .Property(s => s.Status)
                .HasConversion<string>();
        }
    }
}
