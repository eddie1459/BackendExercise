namespace BackendExercise.Models;

public class CustomerDetails
{
    public int id { get; set; }

    public string? first_name { get; set; }
    public string? last_name { get; set; }

    public string? email { get; set; }

    public BillingDetails? billing_address { get; set; }
    public Boolean? isActive {get; set;}
    public string? monthly_income {get; set;}
    public string? job_title {get; set;}
    public string? favorite_color {get; set;}
}