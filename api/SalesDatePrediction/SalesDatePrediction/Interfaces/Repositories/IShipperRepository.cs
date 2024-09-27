using SalesDatePrediction.Models;

namespace SalesDatePrediction.Interfaces.Repositories
{
    public interface IShipperRepository
    {
        public Task<IEnumerable<Shipper>> GetAll();
    }
}
