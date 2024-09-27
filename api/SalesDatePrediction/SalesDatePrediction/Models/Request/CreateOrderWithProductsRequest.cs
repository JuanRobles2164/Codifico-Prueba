using SalesDatePrediction.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.Models.Request
{

    public class CreateOrderWithProductsRequest
    {
        [Required]
        public AddOrder NewOrder { get; set; }
        [Required]
        public IEnumerable<AddOrderDetails> NewOrderDetails {  get; set; }
    }
}
