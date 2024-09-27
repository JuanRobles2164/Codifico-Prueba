namespace SalesDatePrediction.Models.Dtos
{
    public class AddOrderDetails
    {
        public int? OrderId { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
