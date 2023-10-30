using DAOProducto;
using EjercicioKiosco;


DAOProductos BDProductos = new DAOProductos();
List<Producto> productos = new List<Producto>();
Producto producto = new Producto();
productos=BDProductos.ObtenerProductos();
Usuario usuario = new Usuario("Carlos",18);
var kiosco = Kiosco.instance;
kiosco.productos= productos;


foreach (var prod in productos)
{
    
   Console.WriteLine(prod.Id + " -> " + prod.Nombre + ": $" + prod.Precio + ", stock: "+prod.Stock);
}
producto = BDProductos.ObtenerProducto(6);
Console.WriteLine("Cliente " + usuario.Nombre1 + " de "+usuario.Edad1+" años");
Console.WriteLine("se compra el producto " + producto.Nombre+" restringido para menores: "+ producto.ParaMayorEdad);

Console.WriteLine(kiosco.Comprar(producto, usuario));

