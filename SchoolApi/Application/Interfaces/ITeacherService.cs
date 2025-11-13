using SchoolApi.Domain.Entities;

namespace SchoolApi.Application.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher?> GetTeacherByIdAsync(int id);
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(int id, Teacher teacher);
        Task<bool> DeleteTeacherAsync(int id);
        Task<IEnumerable<Course>> GetTeacherCoursesAsync(int teacherId);
    }
}




