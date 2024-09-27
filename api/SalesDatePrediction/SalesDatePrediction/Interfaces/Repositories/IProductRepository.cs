using SalesDatePrediction.Models;

namespace SalesDatePrediction.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Products>> GetAll();
    }
}
