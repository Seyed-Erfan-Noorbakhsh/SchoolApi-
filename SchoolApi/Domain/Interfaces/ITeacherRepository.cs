using SchoolApi.Domain.Entities;

namespace SchoolApi.Domain.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(Teacher teacher);
        Task<IEnumerable<Course>> GetTeacherCoursesAsync(int teacherId);
    }
}




