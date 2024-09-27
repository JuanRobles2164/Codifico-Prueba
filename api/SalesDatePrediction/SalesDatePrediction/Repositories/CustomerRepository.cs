using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;

namespace SalesDatePrediction.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly string SALES_DATE_PREDICTIONS_QUERY = @"
            WITH Diferencias AS (
                SELECT 
                    custid,
                    orderdate,
                    LEAD(orderdate) OVER (PARTITION BY custid ORDER BY orderdate) AS FechaSiguiente,
                    DATEDIFF(DAY, orderdate, LEAD(orderdate) OVER (PARTITION BY custid ORDER BY orderdate)) AS DiferenciaDias
                FROM Sales.Orders
            )
            SELECT 
                c.companyname AS CompanyName,
	            d.custid as CustomerId,
                MAX(d.orderdate) AS LastOrderDate,
                DATEADD(DAY, SUM(d.DiferenciaDias)/COUNT(orderdate), MAX(d.orderdate)) AS NextPredictedOrder
            FROM Diferencias d
            JOIN Sales.Customers c ON d.custid = c.custid
            GROUP BY d.custid, c.companyname
            ORDER BY c.companyname;";
        public CustomerRepository(IDBConnection conn) : base(conn)
        {
        }

        public async Task<IEnumerable<Models.SalesDatePrediction>> GetSalesDatePredictions()
        {
            return await _conn.Query<Models.SalesDatePrediction>(SALES_DATE_PREDICTIONS_QUERY);
        }
    }
}
