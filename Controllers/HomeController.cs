using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Data.SqlClient;  // Importante para SqlConnection
using Microsoft.Extensions.Configuration; // Importante para IConfiguration

namespace ProyectoFinal1.Controllers
{
    [Authorize]  // Protege todas las acciones en este controlador
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

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
            return View();
        }

        public IActionResult VerDetalleCursos(int idCurso)
        {
            ViewBag.UnicoCurso = BD.TraerCursoUnico(idCurso);
            ViewBag.TraerProfesores = BD.TraerProfesores(idCurso);
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            return View();
        }

        public IActionResult Reservar(int idCurso, int idUsuario, int valoracion)
        {
            ViewBag.UnicoCurso = BD.TraerCursoUnico(idCurso);
            BD.AgregarUsuarioCurso(idCurso, idUsuario, valoracion);
            return View();
        }

        public IActionResult CrearCurso()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCurso(string nombreCurso, string descripcion, string temario, int precio, int idProfesor)
        {
            if (ModelState.IsValid)
            {
                CrearCursoEnBD(nombreCurso, descripcion, temario, precio, idProfesor);
                return RedirectToAction("Index");
            }
            return View();
        }

        private void CrearCursoEnBD(string nombreCurso, string descripcion, string temario, int precio, int idProfesor)
    {
        // Lee la cadena de conexión desde appsettings.json
        string connectionString = _configuration.GetConnectionString("DefaultConnection");
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            db.Open();
            string sql = "INSERT INTO Cursos (nombreCurso, descripcion, temario, precio, idProfesor) VALUES (@NombreCurso, @Descripcion, @Temario, @Precio, @idProfesor)";
            using (SqlCommand cmd = new SqlCommand(sql, db))
            {
                cmd.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Temario", temario);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@idProfesor", idProfesor);
                cmd.ExecuteNonQuery();
            }
        }
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
