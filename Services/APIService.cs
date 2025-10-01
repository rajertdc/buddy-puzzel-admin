using System.Net.Http.Headers;
using AdminPortal.Models;
using System.Text.Json;

namespace AdminPortal.Services;

public class APIService
{
    public IConfiguration Configuration = new ConfigurationManager();
    public static string token = EnvService.API.GetToken();
    public static string baseUrl = EnvService.API.GetBaseUrl();

    //All customers 
    public static string customersUrl = "customers/";

    //Specific customer
    public static string customerByIdUrl(string id) => "customers/" + id;

    //All customerSites
    public static string customerSitesUrl = "customerSites/";

    //Specfic customerSite
    public static string customerSiteByIdUrl(string id) => "customerSites/" + id;
    public static string customerSitesByCustomerIdUrl(string id) => "customerSites/?customerId=" + id;

    //Specific catalogs for customer
    public static string customerSiteCatalogByCustomerSiteIdUrl(string id) => "customers/catalogs/customersite/" + id;

    private static HttpClient client = new()
    {
        BaseAddress = new Uri(baseUrl),
    };

    internal static class Customers
    {
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response2 = client.GetAsync("customers/").Result;
            Console.WriteLine($"This is status code for response 2 with base address {response2.StatusCode}");
            var json2 = response2.Content.ReadAsStringAsync().Result;
            Console.WriteLine($"Json with BaseAddress {json2}");
            var response = client.GetAsync(customersUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                customers = JsonSerializer.Deserialize<List<Customer>>(json);
                return customers;
            }

            return null;
        }

        public static Customer GetCustomerById(string id)
        {
            Customer customer = new Customer();

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = client.GetAsync(customerByIdUrl(id)).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                customer = JsonSerializer.Deserialize<Customer>(json);
                return customer;
            }


            return null;
        }
    }

    internal static class CustomerSites
    {
        public static List<CustomerSite> GetAllCustomerSites()
        {
            List<CustomerSite> customerSites = new List<CustomerSite>();

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(customerSitesUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                customerSites = JsonSerializer.Deserialize<List<CustomerSite>>(json);
                return customerSites;
            }


            return null;
        }

        public static List<CustomerSite> GetAllCustomerSitesByCustomerId(string customerId)
        {
            List<CustomerSite> customerSites = new List<CustomerSite>();

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(customerSitesByCustomerIdUrl(customerId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                customerSites = JsonSerializer.Deserialize<List<CustomerSite>>(json);
                return customerSites;
            }


            return null;
        }

        public static CustomerSite GetCustomerSiteById(string customerId)
        {
            var customerSite = new CustomerSite();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(customerSiteByIdUrl(customerId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                customerSite = JsonSerializer.Deserialize<CustomerSite>(json);
                return customerSite;
            }


            return null;
        }
    }

    internal static class CustomerSiteCatalogs
    {
        public static List<CustomerSiteCatalog> GetCustomerSiteCatalogs(string customerSiteId)
        {
            var customerSiteCatalogs = new List<CustomerSiteCatalog>();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(customerSiteCatalogByCustomerSiteIdUrl(customerSiteId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                customerSiteCatalogs = JsonSerializer.Deserialize<List<CustomerSiteCatalog>>(json);
                return customerSiteCatalogs;
            }


            return null;
        }
    }
}