using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using MySqlX.XDevAPI.Common;



namespace DAOProducto 
{
    public class DAOProductos : IDAOProductos
    {
        string connection = @"Server=localhost; Database=ejercicioKiosco; Uid=root;";
        string sqlProducto = "select Id,Nombre,Precio,Alcohol,ParaMayorEdad,Stock from Productos;";
        string sqlId = "select Id,Nombre,Precio,Alcohol,ParaMayorEdad,Stock from Productos where Id = @Id;";
        string sqlUpdate = "update Productos set Stock = @Stock where Id = @Id;";
        public DAOProductos() { }

        public List<Producto> ObtenerProductos()
        {
            using (var db = new MySqlConnection(connection))
            {
                List<Producto> result = new List<Producto>();
                result = (List<Producto>)db.Query<Producto>(sqlProducto);
                return result;
            }

        }

        public Producto ObtenerProducto(int id)
        {
            using (var db = new MySqlConnection(connection))
            {
                Producto result = new Producto();
                result = db.QueryFirstOrDefault<Producto>(sqlId, new { Id = id });
                return result;
            }
        }

        public void ActualizarProducto(int id,int stock)
        {
            using (var db = new MySqlConnection(connection))
            {

                var result = db.Execute(sqlUpdate, new { stock,id });

            }

        }
    }
}
