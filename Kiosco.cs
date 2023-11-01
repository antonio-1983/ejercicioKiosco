using DAOProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioKiosco.Exceptions;


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

        public void Comprar(Producto producto, Usuario usuario, object bloqueador)//cambie string por void
        {
            DAOProductos BDProductos = new DAOProductos();

            if (!EnStock(producto.Stock))
            {
                throw new CompraRechazadaException("No hay en stock");
            }
            if (producto.ParaMayorEdad == "True")
            {
                if (!MayorEdad(usuario.Edad1))
                {
                    throw new CompraRechazadaException("No se realiza la compra por ser menor de edad");
                }
                if (producto.Alcohol == "True")
                {
                    if (EnVeda())
                    {
                        throw new CompraRechazadaException("compra no realizada por veda electoral");
                    }
                    else
                    {
                        lock (bloqueador)
                        {
                            BDProductos.ActualizarProducto(producto.Id, producto.Stock - 1);
                            producto = BDProductos.ObtenerProducto(producto.Id);
                            Console.WriteLine("Compra realizada , stock del producto " + producto.Nombre + ": " + producto.Stock);
                        }
                    }
                }
                else
                {
                    lock (bloqueador)
                    {
                        BDProductos.ActualizarProducto(producto.Id, producto.Stock - 1);
                        producto = BDProductos.ObtenerProducto(producto.Id);
                        Console.WriteLine("Compra realizada , stock del producto " + producto.Nombre + ": " + producto.Stock);
                    }
                }
            }
            else
            {
                lock (bloqueador)
                {
                    BDProductos.ActualizarProducto(producto.Id, producto.Stock - 1);
                    producto = BDProductos.ObtenerProducto(producto.Id);
                    Console.WriteLine("Compra realizada , stock del producto " + producto.Nombre + ": " + producto.Stock);
                }
            }
        }

        public bool EnVeda()
        {
          //  return true;
            return false;
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