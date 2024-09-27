using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Interfaces.Repositories;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("/sales_prediction")]
        public async Task<Object> GetCustomersWithSalesPrediction()
        {
            var results = await _customerRepository.GetSalesDatePredictions();
            return new { results };
        }
    }
}
