using System.Threading.Tasks;
using MyShuttle.Model;

namespace MyShuttle.Data
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(int employeeId);
    }
}