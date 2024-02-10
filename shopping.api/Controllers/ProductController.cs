using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopping.api.Data;
using shopping.api.Models;
namespace shopping.api.Controller;

[ApiController]
[Route("[controller]")]

public class ProductController
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return ProductContext.Products;
    }

}