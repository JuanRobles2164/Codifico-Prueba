using SalesDatePrediction.Interfaces;

namespace SalesDatePrediction.Repositories
{
    public class BaseRepository
    {
        protected readonly IDBConnection _conn;
        public BaseRepository(IDBConnection conn)
        {
            _conn = conn;
        }
    }
}
