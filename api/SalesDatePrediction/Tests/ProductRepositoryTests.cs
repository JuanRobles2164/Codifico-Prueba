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
    public class ProductRepositoryTests
    {
        private readonly IProductRepository _repository;
        private readonly Mock<IDBConnection>_mockConnection;

        public ProductRepositoryTests()
        {
            _mockConnection = new Mock<IDBConnection>();
            _repository = new ProductRepository( _mockConnection.Object );
        }

        [Fact]
        public async Task GetAll_Test()
        {
            var result = await _repository.GetAll();
            Assert.IsAssignableFrom<IEnumerable<Products>>(result);
        }
    }
}
