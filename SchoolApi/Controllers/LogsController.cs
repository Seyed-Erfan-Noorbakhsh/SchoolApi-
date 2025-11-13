using Microsoft.AspNetCore.Mvc;
using SchoolApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public LogsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/logs
        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _context.Logs
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();

            return Ok(logs);
        }

        // GET: api/logs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
                return NotFound();

            return Ok(log);
        }

        // DELETE: api/logs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
                return NotFound();

            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
