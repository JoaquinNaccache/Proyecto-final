using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal.Models;

public class Cursos
{  
    public int idCurso{get;set;}
    public string nombreCurso{get;set;}
    public string descripcion{get;set;}

    public string temario{get;set;}

    public int precio{get;set;}
    public string imagen{get;set;}
    public int idProfesor{get;set;}
    


    public Cursos(int IdCurso, string NombreCurso, string Descripcion, string Temario, int Precio, string Imagen, int IdProfesor)
    {
        idCurso=IdCurso;
        nombreCurso=NombreCurso;
        descripcion=Descripcion;
        temario=Temario;
        precio=Precio;
        idProfesor=IdProfesor;
        
    }
    public Cursos () {}      
}
