using Globomantics.Domain.Models;
using Globomatics.Infrastructure.Interfaces.Repositories;
using Globomatics.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Globomatics.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly IRepository<Product> repository;
    public HomeController(
        ILogger<HomeController> logger, IRepository<Product> repository)
    {
        this.logger = logger;
        this.repository = repository;
    }
    public IActionResult Index()
    {
        var products = repository.All();
        logger.LogInformation($"Loaded {products.Count()} products.");

        return View(products);
    }

    [Route("/details/{productId:guid}/{slug:validateTransform:validateSlug}")]
    public IActionResult TicketDetails(Guid productId, string slug)
    {
        var product = repository.Get(productId);
        logger.LogInformation($"Loaded {product?.Name} details.");

        return View(product);
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