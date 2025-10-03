using Microsoft.AspNetCore.Identity;

namespace AdminPortal.Models;

public class ApplicationUser : IdentityUser
{
    public string customerSiteId { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string location { get; set; }
}