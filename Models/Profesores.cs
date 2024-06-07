using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal.Models;

public class Profesores
{  
    public int idProfesor{get;set;}
    public string nombreProfesor{get;set;}
    public string contenido{get;set;}
    public string informacion{get;set;}

    
   


    public Profesores(int IdProfesor, string NombreProfesor, string Contenido, string Informacion)
    {
        idProfesor=IdProfesor;
        nombreProfesor=NombreProfesor;
        contenido=Contenido;
        informacion=Informacion;
        
        
        
    }
    public Profesores () {} 
}
