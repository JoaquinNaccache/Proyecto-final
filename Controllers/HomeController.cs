using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Dapper;

using System.Data.SqlClient;  // Importante para SqlConnection
using Microsoft.Extensions.Configuration; // Importante para IConfiguration
using Microsoft.Extensions.Configuration;  // Para trabajar con IConfiguration (si aún no lo has hecho)

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
    // Obtener el ID del usuario logueado desde los Claims
    var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    if (string.IsNullOrEmpty(userId))
    {
        // Si el usuario no está logueado, redirigir al Login
        return RedirectToAction("Login", "Cuenta");
    }

    try
    {
        // Convertir el ID a entero
        int idUsuario = int.Parse(userId);

        // Conexión a la base de datos
        using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            con.Open();

            // Consulta para obtener los datos del usuario logueado
            var usuario = con.QueryFirstOrDefault<Usuario>(
                "SELECT idUsuario, nombreUsuario, apellido, contrasena, email FROM Usuarios WHERE idUsuario = @Id",
                new { Id = idUsuario }
            );

            // Pasar los datos del usuario a la vista
            if (usuario != null)
            {
                return View(usuario);
            }
        }
    }
    catch (Exception ex)
    {
        // Manejo de errores (puedes loguearlo si tienes un logger configurado)
        _logger.LogError($"Error al cargar el perfil del usuario: {ex.Message}");
    }

    // Si no se encuentra el usuario, redirigir a Login
    return RedirectToAction("Login", "Cuenta");
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
        string connectionString = _configuration.GetConnectionString("DefaultConnection");//lo cambie por DefaultConnection
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
