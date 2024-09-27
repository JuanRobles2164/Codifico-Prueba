using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;

namespace SalesDatePrediction.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly string GET_ALL_PRODUCTS_QUERY = @"SELECT ProductID, ProductName 
                                                        FROM Production.Products";
        public ProductRepository(IDBConnection conn) : base(conn)
        {
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _conn.Query<Products>(GET_ALL_PRODUCTS_QUERY);
        }
    }
}
