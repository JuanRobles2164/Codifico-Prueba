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
    public class CustomerRepositoryTests
    {
        private readonly ICustomerRepository _repository;
        private readonly Mock<IDBConnection> _mockConnection;

        public CustomerRepositoryTests() 
        {
            _mockConnection = new Mock<IDBConnection>();
            _repository = new CustomerRepository(_mockConnection.Object);
        }

        [Fact]
        public async Task GetSalesDatePredictions_Test()
        {
            var results = await _repository.GetSalesDatePredictions();

            Assert.IsAssignableFrom<IEnumerable<SalesDatePrediction.Models.SalesDatePrediction>>(results);
        }
    }
}
