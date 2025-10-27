namespace SchoolApi.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }    // FK
        public int CourseId { get; set; }     // FK
        public string? Grade { get; set; }    // Nullable
    }
}
