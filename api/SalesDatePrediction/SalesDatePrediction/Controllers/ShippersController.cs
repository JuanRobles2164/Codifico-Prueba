using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/shippers")]
    public class ShippersController : Controller
    {
        private readonly IShipperRepository _shipperRepository;
        public ShippersController(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        [HttpGet]
        [Route("/shippers")]
        public async Task<Object> GetAll()
        {
            var results = await _shipperRepository.GetAll();
            return new { results };
        }
    }
}
