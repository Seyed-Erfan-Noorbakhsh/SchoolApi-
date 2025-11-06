using SchoolApi.Application.Interfaces;
using SchoolApi.Domain.Entities;
using SchoolApi.Domain.Interfaces;

namespace SchoolApi.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            return await _repository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(int id, Student student)
        {
            if (id != student.Id)
                throw new ArgumentException("ID mismatch");

            await _repository.UpdateAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return false;

            await _repository.DeleteAsync(student);
            return true;
        }
    }
}

