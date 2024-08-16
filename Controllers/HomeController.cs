using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace ProyectoFinal1.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    //  public async task<IActionResult> Salir() error en el task aca
    // {
    //     await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);    
    //     return RedirectToAction("Login","Cuenta");
    // }


    public IActionResult Index()
    {
        ViewBag.todosCursos = BD.TraerCursos();
        return View();
    }

    public async Task<IActionResult> Salir()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Cuenta");
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
