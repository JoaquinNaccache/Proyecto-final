using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal.Models;

public class Administrador
{  

   public int idAdministrador{get;set;}
    public int idUsuario{get;set;}
    


    public Administrador(int IdAdministrador, int IdUsuario)
    {
        idUsuario = IdUsuario;
        idAdministrador = IdAdministrador;
        
    }
    public Administrador () {}    
    
}

