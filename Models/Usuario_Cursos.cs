using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal1.Models;

public class Usuario_Cursos
{  
    
    public int idUsuario{get;set;}
    public int idCurso{get;set;}
    public int valoracion{get;set;}
    

    
   


    public Usuario_Cursos(int IdUsuario, int IdCurso, int Valoracion)
    {
        idUsuario=IdUsuario;
        idCurso=IdCurso;
        valoracion=Valoracion;
        
        
        
    }
    public Usuario_Cursos () {} 
}
