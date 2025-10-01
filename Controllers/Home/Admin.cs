using AdminPortal.Models;
using AdminPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AdminPortal.Controllers.Customers; // added for filtering

namespace AdminPortal.Controllers;

public class Admin : Controller
{
    [Authorize(Roles = "Administrator")]
    public IActionResult Overview()
    {
        var customers = APIService.Customers.GetAllCustomers();
        return View(customers);
    }
    
    [HttpGet]
    public IActionResult Search(string term)
    {
        var customers = APIService.Customers.GetAllCustomers() ?? new List<Customer>();
        if (!string.IsNullOrWhiteSpace(term))
        {
            var filtered = customers
                .Where(c => !string.IsNullOrWhiteSpace(c.name) && c.name.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Json(filtered);
        }
        return Json(customers);
    }
    
    [Route("customers/{id}/customerSites")]
    public IActionResult CustomerSites(string id)
    {
        var customerSites = APIService.CustomerSites.GetAllCustomerSitesByCustomerId(id);
        ViewBag.Customer = APIService.Customers.GetCustomerById(id);
        return View("Customer/CustomerSiteDir/CustomerSites", customerSites);
    }

    [Route("customers/{siteId}/{customerSiteId}/")]
    public IActionResult CustomerSite(string siteId)
    {
        var customerSite = APIService.CustomerSites.GetCustomerSiteById(siteId);
        return View("Customer/CustomerSiteDir/CustomerSite",customerSite);
    }
    
    [Route("customers/{customerId}/")]
    public IActionResult Customer(string customerId)
    {
        var customer = APIService.Customers.GetCustomerById(customerId);
        return View("Customer/Customer", customer);
    }

    public IActionResult CustomerSiteCatalogs(string customerSiteId)
    {
        var customerSiteCatalogs = APIService.CustomerSiteCatalogs.GetCustomerSiteCatalogs(customerSiteId);
        
        var customerSite =  APIService.CustomerSites.GetCustomerSiteById(customerSiteId);
        ViewBag.CustomerSite = customerSite;

        var customer = APIService.Customers.GetCustomerById(customerSite.customerId);
        ViewBag.Customer = customer;
        return View("Customer/CustomerSiteDir/CustomerSiteCatalogs", customerSiteCatalogs);
    }

    public IActionResult CreateCustomerSite()
    {
        return View("Customer/CustomerSiteDir/CreateCustomerSite");
    }

    
}