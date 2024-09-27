using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;
using SalesDatePrediction.Models.Dtos;

namespace SalesDatePrediction.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private readonly string SALES_ORDERS_QUERY = @"
                            SELECT OrderID, RequiredDate, ShippedDate, ShipName, ShipAddress, ShipCity 
                                FROM Sales.Orders
                                WHERE custid = @clientId;";
        private readonly string INSERT_ORDER_QUERY = @"INSERT INTO Sales.Orders (EmpID, ShipperID, ShipName, ShipAddress, ShipCity, OrderDate, RequiredDate, ShippedDate, Freight, ShipCountry)
                        VALUES (@EmpID, @ShipperID, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
        private readonly string INSERT_ORDER_DETAILS_QUERY = @"
                            INSERT INTO Sales.OrderDetails (OrderID, ProductID, UnitPrice, Qty, Discount)
                        VALUES (@OrderID, @ProductID, @UnitPrice, @Qty, @Discount);
        ";

        public OrderRepository(IDBConnection conn) : base(conn)
        {
        }

        public async Task<IEnumerable<ClientOrder>> GetClientOrders(int clientId)
        {
            return await this._conn.Query<ClientOrder>(SALES_ORDERS_QUERY, new { clientId });
        }

        public async Task<int> AddOrder(AddOrder Order, IEnumerable<AddOrderDetails> OrderDetails)
        {
            int orderId = await _conn.QuerySingleAsync(INSERT_ORDER_QUERY, Order);
            foreach (var item in OrderDetails) 
            {
                item.OrderId = orderId;
                await _conn.Execute(INSERT_ORDER_DETAILS_QUERY, OrderDetails);
            }
            return orderId;
        }

    }
}