using SchoolApi.Application.Interfaces;
using SchoolApi.Domain.Entities;
using SchoolApi.Domain.Interfaces;

namespace SchoolApi.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            return await _repository.AddAsync(teacher);
        }

        public async Task UpdateTeacherAsync(int id, Teacher teacher)
        {
            if (id != teacher.Id)
                throw new ArgumentException("ID mismatch");

            await _repository.UpdateAsync(teacher);
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);
            if (teacher == null)
                return false;

            await _repository.DeleteAsync(teacher);
            return true;
        }

        public async Task<IEnumerable<Course>> GetTeacherCoursesAsync(int teacherId)
        {
            return await _repository.GetTeacherCoursesAsync(teacherId);
        }
    }
}




