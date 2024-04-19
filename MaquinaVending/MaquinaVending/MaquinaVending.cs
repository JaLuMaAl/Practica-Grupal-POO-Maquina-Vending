using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            // La clave secreta esta predeterminada por los creadores del programa
            ClaveSecreta = 247209; 
        }

        // Método encargado de proceso de compra de los productos 
        public void ComprarProductos()
        {
            List<Producto> carrito = new List<Producto>();

            int opcion = 0;
            double precioTotal = 0;

            if (listaProductos.Count == 0)
            {
                Console.WriteLine("La máquina no contiene productos.");
            }
            else
            {
                Console.WriteLine(" --- PRODUCTOS DISPONIBLES ---");

                foreach (Producto p in listaProductos)
                {
                    Console.WriteLine(p.MostrarInfo());
                }

                do
                {
                    Producto productoElegido = productManager.ElegirProducto();

                    if (productoElegido != null)
                    {
                        carrito.Add(productoElegido);
                        precioTotal = +productoElegido.PrecioUnidad;
                        productoElegido.UnidadesDisponibles--;
                        Console.WriteLine($"El producto {productoElegido.Nombre} ha sido añadido al carrito!");

                        Console.Write("Desea comprar otro producto? (1.Sí / 2.No): ");
                        opcion = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("El producto con el ID introducido no esta disponible.");
                    }
                } while (opcion == 1);

                Console.WriteLine("Tu carrito incluye:");

                foreach (Producto p in carrito)
                {
                    Console.WriteLine($"{p.Nombre}");
                }

                Console.WriteLine($"El precio total a pagar es de {precioTotal}€.");
                Pagar(precioTotal);
            }
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
                    break;
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
            int numeroSlots = 12;
            bool accesoAdmin = CheckAdmin();

            if (accesoAdmin)
            {
                Console.WriteLine("Desea reponer o añadir productos?");
                Console.WriteLine("1: Reponer\n2: Añadir");
                int opcion = int.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        ReponerProducto();
                        break;
                    case 2:
                        if (listaProductos.Count < numeroSlots)
                        {
                            AddNewProduct();
                        }
                        else
                        {
                            Console.WriteLine("La capacidad de la máquina esta llena. No se pueden añadir productos.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Método que permite al Admin reponer completamente las unidades de los productos existentes
        public void CargaCompleta()
        {
            bool accesoAdmin = CheckAdmin();

            if (accesoAdmin)
            {

            }
        }

        // Método que guarda los datos y cierra el programa
        public void SalirGuardar()
        {

        }

        // Método para comprobar si clave secreta es correcta
        private bool CheckAdmin()
        {
            bool check = false;

            Console.WriteLine("Introduce clave secreta: ");
            int clave = int.Parse(Console.ReadLine());

            if (clave == ClaveSecreta)
            {
                Console.WriteLine("Clave secreta correcta. Bienvenido Admin.");
                check = true;
            }
            else if (clave != ClaveSecreta)
            {
                Console.WriteLine("Clave secreta incorrecta.");
            }
            return check;
        }
    }
}
