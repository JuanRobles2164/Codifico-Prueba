namespace SalesDatePrediction.Models.Dtos
{
    public class AddOrder
    {
        public int EmpID { get; set; }
        public int ShipperID { get; set; }
        public string ShipName { get; set; } = string.Empty;
        public string ShipAddress { get; set; } = string.Empty;
        public string ShipCity { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipCountry { get; set; } = string.Empty;
    }
}
