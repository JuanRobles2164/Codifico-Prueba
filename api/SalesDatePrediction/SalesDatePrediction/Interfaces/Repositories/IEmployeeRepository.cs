using SalesDatePrediction.Models;

namespace SalesDatePrediction.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAll();
    }
}
