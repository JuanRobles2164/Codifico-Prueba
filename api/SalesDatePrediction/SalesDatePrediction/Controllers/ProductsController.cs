using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("/products")]
        public async Task<Object> GetAll()
        {
            var results = await productRepository.GetAll();
            return new { results };
        }
    }
}
