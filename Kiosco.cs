using DAOProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioKiosco
{
    public class Kiosco
    {
        public static Kiosco instance => new Kiosco();
        public List<Producto> productos { get; set; }
        private Kiosco() 
        {
            this.productos = productos;
        }

        public string Comprar(Producto producto,Usuario usuario) 
        {
            DAOProductos BDProductos = new DAOProductos();

            if(!EnStock(producto.Stock))
            {
                return "No hay en stock";
            }
                if (producto.ParaMayorEdad=="True")
                {
                    if (!MayorEdad(usuario.Edad1))
                    {
                        return "No se realiza la compra por ser menor de edad";
                    }
                    if(producto.Alcohol=="True") 
                    {
                            if (EnVeda())
                            {
                            return "compra no realizada por veda electoral";
                            }
                            else
                            {
                            BDProductos.ActualizarProducto(producto.Id, producto.Stock - 1);
                            producto = BDProductos.ObtenerProducto(producto.Id);
                            return "Compra realizada , stock del producto " + producto.Nombre + ": " + producto.Stock;
                            }
                    }
                    else 
                    {
                            
                            BDProductos.ActualizarProducto(producto.Id, producto.Stock - 1);
                            producto = BDProductos.ObtenerProducto(producto.Id);
                            return "Compra realizada , stock del producto " + producto.Nombre + ": " + producto.Stock;
                    }
                }
                else
                {
                        BDProductos.ActualizarProducto(producto.Id, producto.Stock - 1);
                        producto = BDProductos.ObtenerProducto(producto.Id);
                        return "Compra realizada , stock del producto " + producto.Nombre + ": " + producto.Stock;
                }

        } 

        public bool EnVeda()
        {
            return true;
        }

        public bool MayorEdad(int edad)
        {
            if (edad >= 18) 
            {  
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool EnStock(int stock) 
        {
            if (stock > 0) { return true; }
            else { return false; }
        }


    }
}
