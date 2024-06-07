using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal1.Models;

public class BD
{  private static string _connectionString = @"Server=localhost; DataBase=edu+;Trusted_Connection=True;";

        public static List<Cursos> TraerCursos(int idCurso) 
    {
        List<Cursos>  listadocursos = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Cursos Where idCurso = @idCurso";
            listadocursos = db.Query<Cursos>(sql).ToList();
        }
        //falta poner el value idCurso = @idCurso
        return listadocursos;
    }

     public static List<Profesores> TraerProfesores() 
    {
        List<Profesores>  listadoprofesores = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Profesores";
            listadoprofesores = db.Query<Profesores>(sql).ToList();
        }
        return listadoprofesores;
    }
    
}
