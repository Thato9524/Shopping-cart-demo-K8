using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using shopping.api.Data;
using shopping.api.Models;
namespace shopping.api.Controller;

[ApiController]
[Route("[controller]")]

public class ProductController
{
    private readonly ProductContext _context;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ProductContext context, ILogger<ProductController> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.Find(p => true).ToListAsync();
    }

}