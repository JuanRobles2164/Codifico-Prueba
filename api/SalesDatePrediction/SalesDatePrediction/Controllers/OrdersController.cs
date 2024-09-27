using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;
using SalesDatePrediction.Models.Request;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("/client_orders")]
        public async Task<Object> GetOrdersByClient(int ClientId)
        {
            return new { results = await _orderRepository.GetClientOrders(ClientId) };
        }

        [HttpPost]
        [Route("/order")]
        public async Task<Object> CreateOrderWithProducts(CreateOrderWithProductsRequest parameters)
        {
            return new { results = await _orderRepository.AddOrder(parameters.NewOrder, parameters.NewOrderDetails) };
        }
        
    }
}
