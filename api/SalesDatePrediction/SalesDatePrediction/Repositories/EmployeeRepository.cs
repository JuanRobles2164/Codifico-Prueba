using SalesDatePrediction.Data;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;

namespace SalesDatePrediction.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly string GET_ALL_EMPLOYEES_QUERY = @"SELECT EmpID, CONCAT(FirstName, ' ', LastName) AS FullName 
                                FROM HR.Employees";

        public EmployeeRepository(IDBConnection conn) : base(conn)
        {

        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _conn.Query<Employee>(GET_ALL_EMPLOYEES_QUERY);
        }
    }
}
