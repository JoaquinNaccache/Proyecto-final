using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal1.Models;

namespace ProyectoFinal1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.todosCursos = BD.TraerCursos();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
      public IActionResult Perfil()
    {
        return View();
    }
     public IActionResult SobreNosotros()
    {
        //ViewBag.todosCursos = BD.TraerCursos();

        return View();
    }
     public IActionResult VerDetalleCursos(int idCurso)
    {

        ViewBag.UnicoCurso = BD.TraerCursoUnico(idCurso);
        ViewBag.TraerProfesores= BD.TraerProfesores(idCurso); 
        return View();
    }
     public IActionResult Reservar(int idCurso, int idUsuario, int valoracion)
    {
        ViewBag.UnicoCurso = BD.TraerCursoUnico(idCurso);
        BD.AgregarUsuarioCurso(idCurso,idUsuario,valoracion); 
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
