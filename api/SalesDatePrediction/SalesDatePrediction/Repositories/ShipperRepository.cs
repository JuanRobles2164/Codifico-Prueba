using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;

namespace SalesDatePrediction.Repositories
{
    public class ShipperRepository: BaseRepository, IShipperRepository
    {
        private readonly string GET_ALL_SHIPPERS_QUERY = @"SELECT ShipperID, CompanyName 
                                                            FROM Sales.Shippers";
        public ShipperRepository( IDBConnection conn) : base(conn) 
        {

        }

        public async Task<IEnumerable<Shipper>> GetAll()
        {
            return await _conn.Query<Shipper>(GET_ALL_SHIPPERS_QUERY);
        }
    }
}
