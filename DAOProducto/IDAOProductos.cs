using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProducto
{
    public  interface IDAOProductos
    {
        public List<Producto> ObtenerProductos();

        public void ActualizarProducto(int id, int stock);
        public Producto ObtenerProducto(int id);
    }
}
