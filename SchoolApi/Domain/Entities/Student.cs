using System;
using SchoolApi.Domain.Enums;

namespace SchoolApi.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? StudentId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public StudentStatus? Status { get; set; }
        public string? Gender { get; set; }
        public string? Major { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
