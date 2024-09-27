namespace SalesDatePrediction.Interfaces
{
    public interface IDBConnection
    {
        public Task<IEnumerable<T>> Query<T>(string sql, object? parameters = null);
        public Task<int> Execute(string sql, object? parameters = null);
        public Task<int> QuerySingleAsync(string sql, object? parameters = null);
    }
}
