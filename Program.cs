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

producto1 = BDProductos.ObtenerProducto(1);
producto2 = BDProductos.ObtenerProducto(2);
producto3 = BDProductos.ObtenerProducto(3);
producto4 = BDProductos.ObtenerProducto(4);
producto5 = BDProductos.ObtenerProducto(5);

var kiosco = Kiosco.instance;
kiosco.productos = productos;


foreach (var prod in productos)
{

    Console.WriteLine(prod.Id + " -> " + prod.Nombre + ": $" + prod.Precio + ", stock: " + prod.Stock);
}

/*

async Task ComprarAsync(Producto producto, Usuario usuario, object bloqueador)
{
    await Task.Run(() => kiosco.Comprar(producto, usuario, bloqueador));
}

async Task Run()
{
    object bloqueador = new object();
    var task1 = ComprarAsync(producto1, usuario1, bloqueador);
    var task2 = ComprarAsync(producto2, usuario2, bloqueador);
    var task3 = ComprarAsync(producto3, usuario3, bloqueador);
    var task4 = ComprarAsync(producto4, usuario4, bloqueador);
    var task5 = ComprarAsync(producto5, usuario5, bloqueador);

    await Task.WhenAll(task1, task2, task3, task4, task5);
}

Run();

*/
try
{
    Console.WriteLine("Cliente " + usuario1.Nombre1 + " de " + usuario1.Edad1 + " años");
    Console.WriteLine("se compra el producto " + producto1.Nombre + " restringido para menores: " + producto1.ParaMayorEdad);
    //Console.WriteLine(kiosco.Comprar(producto1, usuario1,bloqueador));
    kiosco.Comprar(producto1, usuario1, bloqueador);
    Console.WriteLine();
}
catch (CompraRechazadaException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}
try
{
    Console.WriteLine("Cliente " + usuario2.Nombre1 + " de " + usuario2.Edad1 + " años");
    Console.WriteLine("se compra el producto " + producto2.Nombre + " restringido para menores: " + producto2.ParaMayorEdad);
    //Console.WriteLine(kiosco.Comprar(producto2, usuario2, bloqueador));
    kiosco.Comprar(producto2, usuario2, bloqueador);
    Console.WriteLine();
}
catch (CompraRechazadaException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

try
{
    Console.WriteLine("Cliente " + usuario3.Nombre1 + " de " + usuario3.Edad1 + " años");
    Console.WriteLine("se compra el producto " + producto3.Nombre + " restringido para menores: " + producto3.ParaMayorEdad);
    //Console.WriteLine(kiosco.Comprar(producto3, usuario3, bloqueador));
    kiosco.Comprar(producto3, usuario3, bloqueador);
    Console.WriteLine();
}
catch (CompraRechazadaException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

try
{
    Console.WriteLine("Cliente " + usuario4.Nombre1 + " de " + usuario4.Edad1 + " años");
    Console.WriteLine("se compra el producto " + producto4.Nombre + " restringido para menores: " + producto4.ParaMayorEdad);
    //Console.WriteLine(kiosco.Comprar(producto4, usuario4, bloqueador));
    kiosco.Comprar(producto4, usuario4, bloqueador);
    Console.WriteLine();
}
catch (CompraRechazadaException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}
try
{
    Console.WriteLine("Cliente " + usuario5.Nombre1 + " de " + usuario5.Edad1 + " años");
    Console.WriteLine("se compra el producto " + producto5.Nombre + " restringido para menores: " + producto5.ParaMayorEdad);
    //Console.WriteLine(kiosco.Comprar(producto5, usuario5, bloqueador));
    kiosco.Comprar(producto5, usuario5, bloqueador);
    Console.WriteLine();
}
catch (CompraRechazadaException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}


productos1 = BDProductos.ObtenerProductos();

Console.WriteLine(" ");
foreach (var prod in productos1)
{
    Console.WriteLine(prod.Id + " -> " + prod.Nombre + ": $" + prod.Precio + ", stock: " + prod.Stock);
}


