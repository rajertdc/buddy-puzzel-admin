using AdminPortal.Models;
using AdminPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdminPortal.Controllers;

[Authorize(Roles = "Administrator")]
public class Admin : Controller
{
    public IActionResult Overview()
    {
        var customers = APIService.Customers.GetAllCustomers();

        return View(customers);
    }

    public IActionResult Administrators()
    {
        return View("Administration/Administrators");
    }

    public IActionResult Account()
    {
        return View("Administration/Account");
    }

    public IActionResult OrgSettings()
    {
        return View("Administration/OrgSettings");
    }

    public IActionResult Resources()
    {
        return View("Administration/ResourcesAndHelp");
    }

    [HttpGet]
    public IActionResult SearchCustomers(string term)
    {
        var customers = APIService.Customers.GetAllCustomers() ?? new List<Customer>();
        if (!string.IsNullOrWhiteSpace(term))
        {
            var filtered = customers
                .Where(c => !string.IsNullOrWhiteSpace(c.name) &&
                            c.name.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Json(filtered);
        }

        return Json(customers);
    }
    [HttpGet]
    public IActionResult SearchAdmins(string term)
    {
        var customers = APIService.Customers.GetAllCustomers() ?? new List<Customer>();
        if (!string.IsNullOrWhiteSpace(term))
        {
            var filtered = customers
                .Where(c => !string.IsNullOrWhiteSpace(c.name) &&
                            c.name.Contains(term, StringComparison.OrdinalIgnoreCase))
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
        return View("Administration/CustomerSiteDir/CustomerSites", customerSites);
    }

    [Route("customers/{siteId}/{customerSiteId}/")]
    public IActionResult CustomerSite(string siteId)
    {
        var customerSite = APIService.CustomerSites.GetCustomerSiteById(siteId);
        return View("Administration/CustomerSiteDir/CustomerSite", customerSite);
    }

    [Route("customers/{customerId}/")]
    public IActionResult Customer(string customerId)
    {
        var customer = APIService.Customers.GetCustomerById(customerId);
        return View("Administration/Customer", customer);
    }

    public IActionResult CustomerSiteCatalogs(string customerSiteId)
    {
        var customerSiteCatalogs = APIService.CustomerSiteCatalogs.GetCustomerSiteCatalogs(customerSiteId);

        var customerSite = APIService.CustomerSites.GetCustomerSiteById(customerSiteId);
        ViewBag.CustomerSite = customerSite;

        var customer = APIService.Customers.GetCustomerById(customerSite.customerId);
        ViewBag.Customer = customer;
        return View("Administration/CustomerSiteDir/CustomerSiteCatalogs", customerSiteCatalogs);
    }
    //CREATION VIEWS SECTION
    public IActionResult CreateCustomer()
    {
        return View("Create/CreateCustomer");
    }
    public IActionResult CreateCustomerSite()
    {
        return View("Create/CreateCustomerSite");
    }

    public IActionResult CreateCustomerSiteCatalog()
    {
        return View("Create/CreateCustomerSiteCatalog");
    }

    public IActionResult CreateCustomerSiteAdmin()
    {
        return View("Create/CreateCustomerSiteAdmin");
    }
    
}