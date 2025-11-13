using System;

namespace SchoolApi.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? CourseCode { get; set; }
        public int? MaxEnrollment { get; set; } // Maximum number of students
        public int? TeacherId { get; set; } // FK to Teacher
        public string? RoomNumber { get; set; }
        public string? Schedule { get; set; } // like wed/10-12


        public Teacher? Teacher { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
