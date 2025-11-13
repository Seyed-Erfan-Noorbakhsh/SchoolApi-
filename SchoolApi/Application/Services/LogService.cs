using System;
using System.Threading.Tasks;
using SchoolApi.Application.Interfaces;
using SchoolApi.Domain.Entities;
using SchoolApi.Infrastructure.Data;

namespace SchoolApi.Application.Services
{
    public class LogService : ILogService
    {
        private readonly SchoolContext _context;

        public LogService(SchoolContext context)
        {
            _context = context;
        }

        public async Task AddLogAsync(string message)
        {
            var log = new Log
            {
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}

