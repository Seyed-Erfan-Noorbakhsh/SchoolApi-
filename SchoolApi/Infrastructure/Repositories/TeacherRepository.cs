using Microsoft.EntityFrameworkCore;
using SchoolApi.Domain.Entities;
using SchoolApi.Domain.Interfaces;
using SchoolApi.Infrastructure.Data;

namespace SchoolApi.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext _context;

        public TeacherRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers
                .Include(t => t.Courses)
                .ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetTeacherCoursesAsync(int teacherId)
        {
            return await _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .Include(c => c.Enrollments)
                .ToListAsync();
        }
    }
}




