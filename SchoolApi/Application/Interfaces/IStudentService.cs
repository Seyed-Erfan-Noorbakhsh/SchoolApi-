using SchoolApi.Domain.Entities;

namespace SchoolApi.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}

