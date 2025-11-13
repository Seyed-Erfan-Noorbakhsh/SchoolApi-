using SchoolApi.Application.Interfaces;
using SchoolApi.Domain.Entities;
using SchoolApi.Domain.Interfaces;

namespace SchoolApi.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogService _logService;

        public StudentService(IStudentRepository repository, ILogService logService)
        {
            _repository = repository;
            _logService = logService;
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
            var created = await _repository.AddAsync(student);
            await _logService.AddLogAsync($" Student '{student.FirstName} {student.LastName}' was created.");
            return await _repository.AddAsync(student);
            // return 'Created'
        }

        public async Task UpdateStudentAsync(int id, Student student)
        {
            if (id != student.Id)
                throw new ArgumentException("ID mismatch");

            await _repository.UpdateAsync(student);
            await _logService.AddLogAsync($" Student '{student.FirstName} {student.LastName}' was updated.");
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return false;

            await _repository.DeleteAsync(student);
            await _logService.AddLogAsync($" Student '{student.FirstName} {student.LastName}' was deleted.");
            return true;
           
        }
    }
}

