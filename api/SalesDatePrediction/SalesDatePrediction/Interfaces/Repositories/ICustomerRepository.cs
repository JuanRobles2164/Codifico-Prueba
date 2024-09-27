namespace SalesDatePrediction.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Models.SalesDatePrediction>> GetSalesDatePredictions();
    }
}
