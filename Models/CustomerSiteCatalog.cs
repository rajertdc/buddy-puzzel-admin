namespace AdminPortal.Models;

public class CustomerSiteCatalog : CustomerSite
{
    public string catalogId { get; set; }
    public string customerId { get; set; }
    public string customerSiteId { get; set; }
    public string catalogName { get; set; }
    public string catalogDescription { get; set; }
    public string typeName { get; set; }
    public string createdDateTime { get; set; }
    
}