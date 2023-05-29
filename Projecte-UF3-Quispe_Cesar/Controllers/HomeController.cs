using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_API.Models;
using Newtonsoft.Json;

namespace Proyecto_API.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        const string apiUrl = "https://biriyani.anoram.com/get";
        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        
        Cocina imatgeDeCocina = JsonConvert.DeserializeObject<Cocina>(content);
    

        return View(imatgeDeCocina);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult receta()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}
