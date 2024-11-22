using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal1.Models;

public class BD
{  
    private static string _connectionString = @"Server=localhost;DataBase=edu+;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

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
      public static List<Cursos> TraerCursoUnico(int idCurso) 
    {
        List<Cursos>  listadocursos = new List<Cursos>();
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Cursos WHERE idCurso = @pidCurso";
            listadocursos = db.Query<Cursos>(sql,new {pidCurso = idCurso}).ToList();
        }
        //falta poner el value idCurso = @idCurso
        return listadocursos;
    }

     public static List<Profesores> TraerProfesores(int idCurso) 
    {
        List<Profesores>  listadoprofesores = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Profesores.* FROM Cursos JOIN Profesores ON Cursos.idProfesor = Profesores.idProfesor WHERE Cursos.idCurso = @pidCurso;";
            listadoprofesores = db.Query<Profesores>(sql,new {pidCurso = idCurso}).ToList();
        }
        return listadoprofesores;
    }
    public static void AgregarUsuarioCurso(int idCurso,int idUsuario,int valoracion){
        
     string SQL = "INSERT INTO Usuario_Cursos(idUsuario,idCurso,valoracion) VALUES (@idusuario, @idcurso, @Valoracion)";
      using (SqlConnection db = new SqlConnection(_connectionString))
         {
             db.Execute(SQL, new { idusuario = idUsuario, idcurso = idCurso, Valoracion = valoracion});
         }
} 

public static void AgregarUsuario(Usuario usuario)
{
    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        string sql = "INSERT INTO Usuario (nombreUsuario, apellido, contrasena, email) VALUES (@NombreUsuario, @Apellido, @Contrasena, @Email)";
        db.Execute(sql, new{NombreUsuario = usuario.nombreUsuario, Apellido = usuario.apellido, Contrasena = usuario.contrasena, Email = usuario.email});
    }
}

public static void CrearCurso(string nombreCurso, string descripcion, string temario, int precio, int idProfesor)
{
    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        string sql = "INSERT INTO Cursos (nombreCurso, descripcion, temario, precio, idProfesor) VALUES (@NombreCurso, @Descripcion, @Temario, @Precio, @idProfesor)";
        db.Execute(sql, new{NombreCurso = nombreCurso, Descripcion = descripcion, Temario = temario, Precio = precio, idProfesor=idProfesor });
    }

}
    
}
