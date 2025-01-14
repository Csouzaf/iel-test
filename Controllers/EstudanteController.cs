using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testeiel.Models;

namespace testeiel.Controllers;

public class EstudanteController : Controller
{
    private readonly ILogger<EstudanteController> _logger;

    public EstudanteController(ILogger<EstudanteController> logger)
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
