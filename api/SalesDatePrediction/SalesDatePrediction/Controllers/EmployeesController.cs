using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces.Repositories;
using SalesDatePrediction.Models;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("/employees")]
        public async Task<Object> GetAll()
        {
            return new { results = await _employeeRepository.GetAll() };
        }
    }
}
