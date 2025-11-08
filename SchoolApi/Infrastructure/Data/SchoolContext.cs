using Microsoft.EntityFrameworkCore;
using SchoolApi.Domain.Entities;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student-Course relationship through Enrollment
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

            // Configure Teacher-Course relationship
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.SetNull); // If teacher is deleted, set TeacherId to null

            // Make StudentId unique if not null
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentId)
                .IsUnique()
                .HasFilter("[StudentId] IS NOT NULL");

            // Make CourseCode unique if not null
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique()
                .HasFilter("[CourseCode] IS NOT NULL");

            // Convert StudentStatus enum to string in database
            modelBuilder.Entity<Student>()
                .Property(s => s.Status)
                .HasConversion<string>();
        }
    }
}
