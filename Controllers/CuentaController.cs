using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal1.Models;
namespace ProyectoFinal1.Controllers;

public class CuentaController : Controller
{
    private readonly ILogger<CuentaController> _logger;

    public CuentaController(ILogger<CuentaController> logger)
    {
        _logger = logger;
    }
 public IActionResult Index()
    {
        return View();
    }
}
