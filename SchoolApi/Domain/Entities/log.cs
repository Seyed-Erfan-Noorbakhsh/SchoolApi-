using System;

namespace SchoolApi.Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public required string Action { get; set; }   // for example: "Student Created"
        public required string Description { get; set; } 
    }
}
