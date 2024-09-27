using SalesDatePrediction.Models;
using SalesDatePrediction.Models.Dtos;

namespace SalesDatePrediction.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<ClientOrder>> GetClientOrders(int clientId);
        public Task<int> AddOrder(AddOrder Order, IEnumerable<AddOrderDetails> OrderDetails);
    }
}
