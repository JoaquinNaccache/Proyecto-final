using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal.Models;

public class BD
{  private static string _connectionString = @"Server=localhost; DataBase=Airdeck;Trusted_Connection=True;";

        public static List<Cursos> TraerCursos() 
    {
        List<Cursos>  listadocursos = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Cursos";
            listadocursos = db.Query<Cursos>(sql).ToList();
        }
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
