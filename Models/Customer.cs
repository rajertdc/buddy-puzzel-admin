namespace AdminPortal.Models;

public class Customer
{
    public Guid? id { get; set; }
    public string? name { get; set; }
    public string? address { get; set; }
    public string? postalCode { get; set; }
    public string? city { get; set; }
    public string? mainPhone { get; set; }
    public string? country { get; set; }
    public string? notes { get; set; }

}