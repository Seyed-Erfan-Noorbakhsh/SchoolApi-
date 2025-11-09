using System;

namespace SchoolApi.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; } // FK
        public int CourseId { get; set; } // FK
        public DateTime EnrollmentDate { get; set; }
        public string? Status { get; set; } // Active, Dropped, Completed, Withdrawn

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
