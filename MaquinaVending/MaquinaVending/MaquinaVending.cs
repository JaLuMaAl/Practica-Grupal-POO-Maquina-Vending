using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class MaquinaVending
    {
        public List<Producto> listaProductos;
        public ProductManager productManager;
        public int ClaveSecreta {  get; set; }

        public MaquinaVending()
        {
            listaProductos = new List<Producto>();
            productManager = new ProductManager(listaProductos);

        }

        // Método encargado de proceso de compra de los productos 
        public void ComprarProductos()
        {
            List<Producto> carrito = new List<Producto>();

            int opcion = 0;
            double precioTotal = 0;

            Console.WriteLine(" --- PRODUCTOS DISPONIBLES ---");

            foreach(Producto p in listaProductos)
            {
                Console.WriteLine(p.MostrarInfo());
            }

            do
            {
                Producto productoElegido = productManager.ElegirProducto();
                carrito.Add(productoElegido);
                precioTotal =+ productoElegido.PrecioUnidad;
                productoElegido.Unidades--;
                Console.WriteLine($"El producto {productoElegido.Nombre} ha sido añadido al carrito!");

                Console.Write("Desea comprar otro producto? (1.Sí / 2.No): ");
                opcion = int.Parse(Console.ReadLine());

            } while (opcion == 1);

            Console.WriteLine("Tu carrito incluye:");

            foreach(Producto p in carrito)
            {
                Console.WriteLine($"{p.Nombre}");
            }

            Console.WriteLine($"El precio total a pagar es de {precioTotal}€.");
            Pagar(precioTotal);
        }

        // Método para pagar carrito
        public void Pagar(double precio)
        {
            Console.WriteLine("Métodos de pago disponible");
            Console.Write("\t1. Tarjeta\n\t2. Efectivo");

            int opcion = 0;

            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch(opcion)
            {
                case 1:
                    productManager.PagoTarjeta(precio);
                    break;
                case 2:
                    productManager.PagoEfectivo(precio);
                    break;
                default:
                    Console.WriteLine("Opción no válida."); //Dar opción de salir o introducir opcion de nuevo
            }
        }

        // Método que muestra la información completa de los productos
        public void MostrarInfoProductos()
        {
            foreach(Producto producto in listaProductos)
            {
                Console.WriteLine(producto.MostrarInfoParcial());
            }

            Producto p = productManager.ElegirProducto();
            p.MostrarInfoParcial();
        }

        // Método que permite al Admin reponer productos existentes o añadir nuevos
        public void CargaIndividual()
        {
            Console.WriteLine("Introduce clave secreta: ");
            string clave = Console.ReadLine();

           if(clave == )
            {

            }
        }

        // Método que permite al Admin reponer completamente las unidades de los productos existentes
        public void CargaCompleta()
        {
            Console.WriteLine("Introduce clave secreta: ");
            string clave = Console.ReadLine();

            if(clave == )
            {

            }
        }

        // Método que guarda los datos y cierra el programa
        public void SalirGuardar()
        {

        }
    }
}
