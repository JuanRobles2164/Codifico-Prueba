using Moq;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;
using SalesDatePrediction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ShipperRepositoryTests
    {
        private readonly IShipperRepository _repository;
        private readonly Mock<IDBConnection> _mockConnection;

        public ShipperRepositoryTests()
        {
            _mockConnection = new Mock<IDBConnection>();
            _repository = new ShipperRepository(_mockConnection.Object);
        }

        [Fact]
        public async Task GetAll_Test()
        {
            var result = await _repository.GetAll();
            Assert.IsAssignableFrom<IEnumerable<Shipper>>(result);
        }
    }
}
