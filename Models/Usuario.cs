using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace ProyectoFinal1.Models;

public class Usuario
{  
    public int idUsuario{get;set;}
    public int idCurso{get;set;}
    public string nombreUsuario{get;set;}
    public string apellido{get;set;}
    public string contrasena{get;set;}
    public string email{get;set;}

    [NotMapped]

    public bool MantenerActivo{get;set;}
    
   


    public Usuario(int IdUsuario, int IdCurso, string NombreUsuario, string Apellido, string Contrasena, string Email)
    {
        idUsuario=IdUsuario;
        idCurso=IdCurso;
        nombreUsuario=NombreUsuario;
        apellido=Apellido;
        contrasena=Contrasena;
        email=Email;
        
        
        
    }
    public Usuario () {} 
}
