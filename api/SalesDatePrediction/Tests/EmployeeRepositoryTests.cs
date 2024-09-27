using Moq;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;
using SalesDatePrediction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class EmployeeRepositoryTests
    {
        private readonly IEmployeeRepository _repository;
        private readonly Mock<IDBConnection> _mockConnection;

        public EmployeeRepositoryTests()
        {
            _mockConnection = new Mock<IDBConnection>();
            _repository = new EmployeeRepository(_mockConnection.Object);
        }

        [Fact]
        public async Task GetAllEmployees_Test()
        {
            var response = await _repository.GetAll();
            Assert.IsAssignableFrom<IEnumerable<Employee>>(response);
        }

    }
}
