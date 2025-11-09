using System;

namespace SchoolApi.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string? Specialization { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // Navigation property - A teacher can teach many courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}

