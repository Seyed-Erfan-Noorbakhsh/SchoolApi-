using System.Threading.Tasks;
using SchoolApi.Domain.Entities;

namespace SchoolApi.Application.Interfaces
{
    public interface ILogService
    {
        Task AddLogAsync(string message);
    }
}
