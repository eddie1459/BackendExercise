using Microsoft.AspNetCore.Mvc;

namespace BackendExercise;

public class CustomerParameters
{
    const int maxPageSize = 50;
    [FromQuery]
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    [FromQuery]
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
    [FromQuery]
    public string? first_name {get; set;}
    [FromQuery]
    public string? last_name {get; set;}
    [FromQuery]
    public int? num_records {get; set;}
    [FromQuery]
    public string? email {get; set;}
    [FromQuery]
    public Boolean? isActive {get; set;}
    [FromQuery]
    public string sortBy { get; set;} = "first_name";
}
