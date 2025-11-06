using System;

namespace SchoolApi.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }                 // PK
        public string Name { get; set; }            // String
        public int Age { get; set; }                // Int
        public DateTime? EnrollmentDate { get; set; } // Nullable DateTime
        public string? Email { get; set; }          // Nullable String
    }
}
