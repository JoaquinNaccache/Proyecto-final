using System.Data.SqlClient;
using Dapper;

namespace ProyectoFinal1.Models;

public class Cliente
{  
    public int idCliente{get;set;}
    public int idUsuario{get;set;}
    


    public Cliente(int IdCliente, int IdUsuario)
    {
        idUsuario = IdUsuario;
        idCliente = IdCliente;
        
    }
    public Cliente () {}      
}
