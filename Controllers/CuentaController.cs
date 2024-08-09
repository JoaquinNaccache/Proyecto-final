using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal1.Models;
using ProyectoFinal1.Data;
using System.Security.Claims;
using System.Data.SqlClient;

namespace ProyectoFinal1.Controllers;

public class CuentaController : Controller
{
   private readonly Contexto _contexto;

   public CuentaController(Contexto contexto){
    _contexto=contexto;
   }
   public IActionResult Login()
    {
        ClaimsPrincipal c = HttpContext.User;
        if(c.Identity != null)
        {
            if(c.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
 public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login (Usuario u){
        try{
            using(SqlConnection con = new(_contexto.Conexion)){
                using(SqlCommand cmd= new("sp_validar_usuario", con)){
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.Varchar).Value=u.nombreUsuario;
                    cmd.Parameters.Add("@contrasena", System.Data.SqlDbType.Varchar).Value=u.contrasena;
                    con.Open();
                    var dr = cmd.ExecuteReader();
                    while(dr.Read()){
                        if(dr["nombreUsuario"] != null && u.nombreUsuario != null){
                            List<Claim> c = new list<Claim>()
                            {
                                new Claim(ClaimTypes.NameIdentifier, u.nombreUsuario)
                            };
                            ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                            AuthenticationProperties p = new();
                            p.AllowRefresh=true;
                            p.IsPersistent=u.MantenerActivo;
                            if(u.MantenerActivo)
                            
                                p.ExpiresUtc= DateTimeOffset.UtcNow.AddMinutes(1);
                            else
                                p.ExpiresUtc= DateTimeOffset.UtcNow.AddDays(1);
                            
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                            return RedirectToAction("Index", "Home")
                        }else{
                            ViewBag.Error="Credenciales incorrectas o cuenta no registrada";
                        }

                    }
                }
            }
        }
        catch(System.Exception)
        {
            throw;
        }
    }
     public IActionResult Error()
    {
        return View("Error!");
    }
}
