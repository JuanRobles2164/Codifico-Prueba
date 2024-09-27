using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;

namespace SalesDatePrediction.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly string SALES_DATE_PREDICTIONS_QUERY = @"
            WITH OrderIntervals AS (
  SELECT 
    o1.custid,
    DATEDIFF(DAY, LAG(o1.OrderDate) OVER (PARTITION BY o1.custid ORDER BY o1.OrderDate), o1.OrderDate) AS DaysBetweenOrders
  FROM 
    Sales.Orders o1
),
CustomerOrderData AS (
  SELECT 
	c.custid as CustomerId,
    c.companyname,
    MAX(o.OrderDate) AS LastOrderDate,
    AVG(oi.DaysBetweenOrders) AS AvgDaysBetweenOrders
  FROM 
    Sales.Orders o
  JOIN 
		Sales.Customers c ON o.custid = c.custid
	LEFT JOIN 
		OrderIntervals oi ON oi.custid = o.custid
	WHERE 
		oi.DaysBetweenOrders IS NOT NULL
  GROUP BY 
    c.companyname,
	c.custid
)

SELECT
  cod.CustomerId,
  cod.companyname,
  cod.LastOrderDate,
  DATEADD(DAY, cod.AvgDaysBetweenOrders, cod.LastOrderDate) AS NextPredictedOrder
FROM 
  CustomerOrderData cod;";
        public CustomerRepository(IDBConnection conn) : base(conn)
        {
        }

        public async Task<IEnumerable<Models.SalesDatePrediction>> GetSalesDatePredictions()
        {
            return await _conn.Query<Models.SalesDatePrediction>(SALES_DATE_PREDICTIONS_QUERY);
        }
    }
}
