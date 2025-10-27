using System;

namespace SchoolApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public DateTime StartDate { get; set; }
    }
}
