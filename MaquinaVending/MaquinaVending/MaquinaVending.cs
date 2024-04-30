using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaquinaVending
{
    internal class MaquinaVending
    {
        // Establecemos una lista de productos y un objeto de la clase ProductManager
        public List<Producto> listaProductos;
        private ProductManager productManager;

        // Clave secreta del usuario administrador de la máquina para poder acceder sus funcionalidades exclusivas
        private int _claveSecreta;
        
        public MaquinaVending()
        {
            // Instanciamos una nueva lista de productos
            listaProductos = new List<Producto>();

            // Instanciamos un objeto de la clase ProductManager, que se encargará de las relaciones con los productos
            productManager = new ProductManager(listaProductos);

            // Establecemos la clave secreta del admin internamente en el programa, se supone que como es el admin debe conocerla
            _claveSecreta = 247209;
        }

        // Método encargado de proceso de compra de los productos 
        public void ComprarProductos()
        {
            try {
                // Creamos una lista de tipo Producto llamada 'carrito'
                List<Producto> carrito = new List<Producto>();

                int opcion = 0;
                // Variable que almacena la suma de los precios de los productos comprados y se pasa por parametro a métodos de pago
                double precioTotal = 0;

                // Comprobamos si la máquina expendedora contiene productos
                if (listaProductos.Count == 0) {
                    // Si la máquina esta vacia, no se pueden comprar productos
                    Console.WriteLine("La máquina no contiene productos.");
                }
                else {
                    Console.WriteLine(" --- PRODUCTOS DISPONIBLES ---");

                    foreach (Producto p in listaProductos) {
                        // Muestra la información parcial de cada producto disponible al usuario para que este elija
                        Console.WriteLine(p.MostrarInfoParcial());
                    }

                    // Bucle do-while por si el usuario desea comprar mas de un producto; se repite el proceso
                    do {
                        // Creamos un objeto de tipo Producto y le asignamos el valor del producto elegido por el usuario
                        Producto productoElegido = productManager.ElegirProducto();

                        // Se comprueba si el producto elegido existe
                        if (productoElegido != null) {
                            // Si hay unidades disponibles del producto elegido
                            if (productoElegido.Unidades > 0) {
                                // Se añade el producto elegido a la lista de tipo Producto 'carrito'
                                carrito.Add(productoElegido);

                                // Añadimos el precio unitario del producto al precio total a pagar y se resta una unidad disponible al producto elegido
                                precioTotal += productoElegido.PrecioUnidad;
                                productoElegido.Unidades--;
                                Console.WriteLine($"El producto {productoElegido.Nombre} ha sido añadido al carrito!");

                                // Preguntamos al usuario si desea continuar con su compra o comprar otro producto
                                Console.Write("Desea comprar otro producto? (1.Sí / 2.No): ");
                                opcion = int.Parse(Console.ReadLine());
                            }
                            else {
                                // Si no hay unidades disponibles del producto elegido
                                Console.WriteLine("No hay unidades disponibles de este producto.");
                            }
                        }
                        // Si el producto elegido no existe
                        else {
                            Console.WriteLine("El producto con el ID introducido no esta disponible.");
                        }
                    } while (opcion == 1);

                    // Si la lista de productos del usuario para comprar no esta vacia
                    if (carrito.Count > 0) {
                        Console.WriteLine("Tu carrito incluye:");

                        // Se muestra por pantalla los productos en el carrito de compra del usuario
                        foreach (Producto p in carrito) {
                            Console.WriteLine($"{p.Nombre}");
                        }

                        // Se muestra por pantalla el precio a pagar y se pasa este valor por parametro al método Pagar
                        Console.WriteLine($"El precio total a pagar es de {precioTotal}€.");
                        Pagar(precioTotal);
                    }
                }
            }
            catch (FormatException) {
                Console.WriteLine("Se ha producido un error al leer la opción ingresada. Debe ingresar un número.");
            }
            catch (IOException) {
                Console.WriteLine("Se ha producido un error de E/S al leer los datos de entrada.");
            }
        }

        // Realizar el pago en base a un valor numérico recibido
        private void Pagar(double precio)
        {
            try 
            {
                Console.WriteLine("Métodos de pago disponible");
                Console.WriteLine("\t1. Tarjeta\n\t2. Efectivo\n\t3. Cancelar operación");

                int opcion = 0;

                do {
                    Console.Write("Opción: ");
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion) {
                        case 1:
                            productManager.PagoTarjeta(precio);
                            break;
                        case 2:
                            productManager.PagoEfectivo(precio);
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Vuelve a introducir la opción.");
                            break;
                    }
                    // Si la opción introducida por el usuario no es válida, se pregunta por una opción por pantalla otra vez
                } while (opcion < 1 || opcion > 3);
            }
            catch (FormatException) 
            {
                Console.WriteLine("Se ha producido un error al leer la opción ingresada. Debe ingresar un número.");
            }
        }

        // Método que muestra la información de los productos
        public void MostrarInfoProductos()
        {
            // Compruebo que la máquina contiene productos, y por tanto no está vacía
            if (listaProductos.Count > 0)
            {
                Console.WriteLine("PRODUCTOS DISPONIBLES");

                // Muestro para cada producto su información más relevante
                foreach (Producto producto in listaProductos)
                {
                    // El método MostrarInfoParcial excluye información específica de cada producto
                    Console.WriteLine(producto.MostrarInfoParcial());
                }

                // Pedimos al usuario que eliga un producto
                Producto p = productManager.ElegirProducto();

                // Si el producto seleccionado existe, muestro toda su información
                if (p != null)
                {
                    Console.WriteLine(p.MostrarInfoTotal());
                }
            }
            else
            {
                Console.WriteLine("La máquina no contiene productos");
            }
        }

        // Método que permite al admin reponer productos existentes o añadir nuevos
        public void CargaIndividual()
        {
            try {
                // La capacidad máxima de productos que soporta la máquina de vending son 12
                int numeroSlots = 12;
                // Variable que almacena True si el admin ha introducido bien la clave y False si la clave es incorrecta
                bool accesoAdmin = CheckAdmin();

                // Si el usuario se ha autenticado, le aparecen las posibles acciones disponibles
                if (accesoAdmin) {
                    Console.WriteLine("Desea reponer o añadir productos?");
                    Console.WriteLine("1: Reponer\n2: Añadir");
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion) {
                        // Reponer producto
                        case 1:
                            // Creamos un objeto de tipo Producto que recibe el producto elegido por el admin para reponer
                            Producto pReponer = productManager.ElegirProducto();

                            // Compruebo si el producto recibido existe
                            if (pReponer != null) {
                                // Si existe, lo repongo
                                productManager.ReponerProducto(pReponer);
                            }
                            else {
                                Console.WriteLine("ID de producto no encontrado");
                            }
                            break;

                        // Añadir nuevo producto
                        case 2:
                            // Se comprueba que la cantidad de productos es menor que el número de slots
                            if (listaProductos.Count < numeroSlots) {
                                productManager.AddNewProduct();
                            }
                            // Si no hay espacio disponible en la máquina vending, no se pueden añadir productos
                            else {
                                Console.WriteLine("La capacidad de la máquina esta llena. No se pueden añadir productos.");
                            }
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }
            catch (FormatException) {
                Console.WriteLine("Se ha producido un error al ingresar la opción. Debe ser un número.");
            }

        }

        // Método que permite al Admin cargar productos directamente de un archivo introduciendo su nombre
        public void CargaCompleta()
        {
            try {
                // Variable que almacena True si el admin ha introducido bien la clave y False si la clave es incorrecta
                bool accesoAdmin = CheckAdmin();

            if (accesoAdmin)
            {
                Console.WriteLine("A continuación se solicitará el nombre del archivo que desea emplear para la carga de productos.\n " +
                    "Recuerde que para que se realice correctamente el archivo .csv debe encontrarse en la carpeta /bin/debug dentro de la carpeta de la solución del programa.");
                Console.WriteLine("Introduce el nombre del archivo .csv: ");
                
                string archivoCarga = Console.ReadLine();

                productManager.CargaProductosArchivo(archivoCarga);
            }
            
        }

        // Método booleano que compureba si clave secreta introducida por el usuario es correcta para permitir el acceso a las funciones de admin
        private bool CheckAdmin()
        {
            bool check = false;
            try {
                // Solicito la clave secreta al usuario por pantalla
                Console.WriteLine("Introduce clave secreta: ");
                int clave = int.Parse(Console.ReadLine());

                // Comparo la clave del usuario con la clave secreta establecida en el constructor
                if (clave == ClaveSecreta) {
                    Console.WriteLine("Clave secreta correcta. Bienvenido Administrador.");
                    check = true;
                }
                else if (clave != ClaveSecreta) {
                    Console.WriteLine("Clave secreta incorrecta. Acceso denegado");
                }
            }
            catch (FormatException) {
                Console.WriteLine("Se ha producido un error al ingresar la clave. Debe ser un número entero.");
            }
            return check;
        }

        // Método que guarda los datos y cierra el programa
        public void SalirGuardar()
        {
            productManager.GuardarProductosArchivo();
            Console.WriteLine("Datos guardados");
        }
    }
}
