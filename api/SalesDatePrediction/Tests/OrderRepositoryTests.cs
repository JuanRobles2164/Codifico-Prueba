using Moq;
using SalesDatePrediction.Data;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;
using SalesDatePrediction.Models.Dtos;
using SalesDatePrediction.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class OrderRepositoryTests
    {
        private readonly IOrderRepository _repository;
        private readonly Mock<IDBConnection> _mockConnection;
        public OrderRepositoryTests()
        {
            _mockConnection = new Mock<IDBConnection>();

            var mockRepository = new Mock<IOrderRepository>();

            /*
             * Es necesario reconfigurar el mock para que devuelva un id ficticio. Así no inserta datos a la base de datos
             * pero permite seguir con las pruebas
            */
            mockRepository
                .Setup(repo => repo.AddOrder(It.IsAny<AddOrder>(), It.IsAny<AddOrderDetails[]>()))
                .ReturnsAsync(1); // Devuelve el ID 1 cuando se llama al método AddOrder

            _repository = mockRepository.Object;

            
        }

        [Fact]
        public async Task AddOrder_Test()
        {
            //Arrange
            var order = new AddOrder
            {
                EmpID = 1,
                ShipperID = 1,
                ShipName = "Acme Corporation",
                ShipAddress = "123 Street",
                ShipCity = "Anytown",
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(5),
                ShippedDate = DateTime.Now.AddDays(10),
                Freight = 25.00M,
                ShipCountry = "USA"
            };
            var orderDetail = new AddOrderDetails
            {
                ProductID = 1,
                UnitPrice = 50.00M,
                Qty = 2,
                Discount = 0
            };
            List<AddOrderDetails> orderDetails = new List<AddOrderDetails>();
            orderDetails.Add(orderDetail);

            //Act
            int orderId = await _repository.AddOrder(order, orderDetails.ToArray());

            //Assert
            Assert.True(orderId > 0, $"Order ID Should be greater than zero: {orderId}");
        }

        [Fact]
        public async Task GetClientOrders_Test()
        {
            int client_order_id = 2;
            var response = await _repository.GetClientOrders(client_order_id);
            Assert.IsAssignableFrom<IEnumerable<ClientOrder>>(response);
        }
    }
}
