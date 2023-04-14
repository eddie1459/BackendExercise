using BackendExercise.Models;
using BackendExercise.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackendExercise.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerDetailsController : ControllerBase {
    private readonly ILogger<CustomerDetailsController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;
    public CustomerDetailsController(ILogger<CustomerDetailsController> logger, IWebHostEnvironment hostingEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet(Name = "CustomerDetails")]
    public IEnumerable<CustomerDetails> Get([FromQuery]CustomerParameters customerParameters)
    {
        var customerService = new CustomerService(_hostingEnvironment);
        var customers = customerService.GetCustomers(customerParameters.num_records);
        var results = customerService.FilterCustomers(customers.ToList(), customerParameters);
        results = customerService.PageAndOrder(customers.ToList(), customerParameters);
        return results;
    }
}
