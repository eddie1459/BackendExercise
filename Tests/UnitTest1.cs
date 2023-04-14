using BackendExercise;
using BackendExercise.Models;
using BackendExercise.Services;

namespace Tests;

public class UnitTest1
{
    private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;
    [Fact]
    public void TestFilter()
    {
        var custService = new CustomerService(_hostingEnvironment);
        var customer = new CustomerDetails();
        customer.last_name = "test last";
        customer.first_name = "test first";
        var customers = new List<CustomerDetails>();
        customers.Add(customer);

        var custParams = new CustomerParameters();
        custParams.first_name = "test first";
        var result = custService.FilterCustomers(customers, custParams).ToList();
        Assert.Equal(1, result.Count());
    }

    [Fact]
    public void TestPaging()
    {
        var custService = new CustomerService(_hostingEnvironment);
        var customer = new CustomerDetails();
        customer.last_name = "test last";
        customer.first_name = "test first";
        var customers = new List<CustomerDetails>();
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);
        customers.Add(customer);

        var custParams = new CustomerParameters();
        var result = custService.PageAndOrder(customers, custParams).ToList();
        Assert.Equal(10, result.Count());
    }
}