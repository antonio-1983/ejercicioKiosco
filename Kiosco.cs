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
            try
            {
                if (!EnStock(producto.Stock))
                {
                    throw new CompraRechazadaException("No hay en stock del producto "+producto.Nombre+" para vender al cliente "+usuario.Nombre1);
                }
                if ((producto.ParaMayorEdad) && !MayorEdad(usuario.Edad1))
                {
                    throw new CompraRechazadaException("No se realiza la compra a "+usuario.Nombre1+" por ser menor de edad");
                }
                if ((producto.Alcohol) && EnVeda())
                {
                    throw new CompraRechazadaException("No se realiza la compra a "+usuario.Nombre1 +" por estar en veda electoral");
                }
            }
            catch (CompraRechazadaException e)
            {
                lock (bloqueador)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(" ");
                    return;
                }
                
            }

            lock (bloqueador)
                {
                producto = BDProductos.ObtenerProducto(producto.Id);
                BDProductos.ActualizarProducto(producto.Id, producto.Stock - 1);
                producto = BDProductos.ObtenerProducto(producto.Id);
                Console.WriteLine("Compra realizada por " + usuario.Nombre1 + ", stock del producto " + producto.Nombre + ": " + producto.Stock);
                Console.WriteLine(" ");
                }
            
        }

        public async Task ComprarAsync(Producto producto, Usuario usuario, object bloqueador)
        {
           
            try
            {
                await Task.Run(() => Comprar(producto, usuario, bloqueador));
            }
            catch (CompraRechazadaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }


        public bool EnVeda()
        {
          // return true;
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