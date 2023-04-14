using System.Text.Json;
using BackendExercise.Models;
using Microsoft.AspNetCore.Hosting;

namespace BackendExercise.Services;

public class CustomerService
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    public CustomerService(IWebHostEnvironment hostingEnvironment){
        _hostingEnvironment = hostingEnvironment;
    }
    public IEnumerable<CustomerDetails> GetCustomers(int? amtToGet) {
        var rootPath = _hostingEnvironment.ContentRootPath; //get the root path

        var fullPath = Path.Combine(rootPath, "MOCK_DATA.json");
        var jsonData = System.IO.File.ReadAllText(fullPath);
        if (amtToGet.HasValue) {
            return JsonSerializer.Deserialize<List<CustomerDetails>>(jsonData).Take(amtToGet.Value);
        }
        return JsonSerializer.Deserialize<List<CustomerDetails>>(jsonData);
    }

    public IEnumerable<CustomerDetails> FilterCustomers(List<CustomerDetails> customers, CustomerParameters customerParameters) {
        //search filtering
        return  customers
            .Where(s => customerParameters.first_name == null || s.first_name.ToLower().Contains(customerParameters.first_name?.ToLower()))
            .Where(s => customerParameters.last_name == null || s.last_name.ToLower().Contains(customerParameters.last_name?.ToLower()) )
            .Where(s => customerParameters.email == null || s.email.ToLower().Contains(customerParameters.email?.ToLower()) )
            .Where(s => customerParameters.isActive == null || s.isActive == customerParameters.isActive)
            .ToList();
    }

    public IEnumerable<CustomerDetails> PageAndOrder(List<CustomerDetails> customers, CustomerParameters customerParameters) {
        //paging and ordering
        return  customers
            .OrderBy(s => Helpers.GetReflectedPropertyValue(s, customerParameters.sortBy))
            .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
            .Take(customerParameters.PageSize)
            .ToList();
    }
}