using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.Interfaces;
using SchoolApi.Domain.Entities;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            try
            {
                var createdStudent = await _studentService.CreateStudentAsync(student);
                return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            try
            {
                await _studentService.UpdateStudentAsync(id, student);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudentAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
