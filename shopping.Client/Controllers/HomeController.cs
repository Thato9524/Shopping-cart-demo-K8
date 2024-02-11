using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using shopping.Client.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Net.Http;


namespace shopping.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;
    public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
    {
        _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IActionResult> Index()
    {
        var httpResponseMessage = await _httpClient.GetAsync(
            "/product");
        var content = await httpResponseMessage.Content.ReadAsStringAsync();
        var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);



        return View(productList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
