namespace SalesDatePrediction.Models
{
    public class SalesDatePrediction
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
