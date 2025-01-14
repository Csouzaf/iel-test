using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testeiel.Models;

namespace testeiel.Controllers;

public class RelatorioController : Controller
{
    private readonly ILogger<RelatorioController> _logger;

    public RelatorioController(ILogger<RelatorioController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
