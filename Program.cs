using DAOProducto;
using EjercicioKiosco;
using EjercicioKiosco.Exceptions;

object bloqueador = new object();
DAOProductos BDProductos = new DAOProductos();
List<Producto> productos = new List<Producto>();
productos = BDProductos.ObtenerProductos();
List<Producto> productos1 = new List<Producto>();

Producto producto1 = new Producto();
Producto producto2 = new Producto();
Producto producto3 = new Producto();
Producto producto4 = new Producto();
Producto producto5 = new Producto();

Usuario usuario1 = new Usuario("Homero", 18);
Usuario usuario2 = new Usuario("Cosme", 25);
Usuario usuario3 = new Usuario("Fulanito", 15);
Usuario usuario4 = new Usuario("Kang", 55);
Usuario usuario5 = new Usuario("Kodos", 45);

producto1 = BDProductos.ObtenerProducto(6);
producto2 = BDProductos.ObtenerProducto(6);
producto3 = BDProductos.ObtenerProducto(1);
producto4 = BDProductos.ObtenerProducto(1);
producto5 = BDProductos.ObtenerProducto(1);

var kiosco = Kiosco.instance;
kiosco.productos = productos;


foreach (var prod in productos)
{

    Console.WriteLine(prod.Id + " -> " + prod.Nombre + ": $" + prod.Precio + ", stock: " + prod.Stock);
}
Console.WriteLine(" ");


    await Run();

productos1 = BDProductos.ObtenerProductos();

Console.WriteLine(" ");
foreach (var prod in productos1)
{
    Console.WriteLine(prod.Id + " -> " + prod.Nombre + ": $" + prod.Precio + ", stock: " + prod.Stock);
}
Console.WriteLine(" ");


async Task Run()
{
    object bloqueador = new object();
   
        var task1 = kiosco.ComprarAsync(producto1, usuario1, bloqueador);
        var task2 = kiosco.ComprarAsync(producto2, usuario2, bloqueador);
        var task3 = kiosco.ComprarAsync(producto3, usuario3, bloqueador);
        var task4 = kiosco.ComprarAsync(producto4, usuario4, bloqueador);
        var task5 = kiosco.ComprarAsync(producto5, usuario5, bloqueador);
        await Task.WhenAll(task1, task2, task3, task4, task5);
}

