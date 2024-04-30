using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    
    internal class ProductManager
    {
        public List<Producto> listaProductos;

        // Ruta del archivo que almacena los productos y su información
        private string _path;

        // Constructor vacío
        public ProductManager() { }
        
        // Constructor parametrizado que recibe una lista de productos
        public ProductManager(List<Producto> listaP)
        {
            listaProductos = listaP;
            _path = "productos.csv";
        }

        // Solicita un ID y recorre la lista de productos en busca de un producto cuyo ID coincida con el introducido
        public Producto ElegirProducto()
        {
            // Creo una instancia null de la clase producto que almacenará el producto encontrado
            Producto pTemp = null;

            try 
            {
                Console.Write("Introduce el ID del producto: ");
                int id = int.Parse(Console.ReadLine());

                // Recorro la lista de productos comparando sus IDs con el introducido por el usuario
                foreach (Producto p in listaProductos) 
                {
                    if (p.Id == id) 
                    {
                        pTemp = p;
                    }
                    else 
                    {
                        Console.WriteLine("No se ha encontrado un producto con el ID introducido.");
                        Console.ReadKey();
                    }
                }
            }
            catch (FormatException) 
            {
                Console.WriteLine("Se ha producido un error, se esperaba un número entero para el ID del producto.");
            }

            // Devuelvo el producto almacenado en pTemp, si no ha encontrado el producto devolverá null
            return pTemp;
        }

        // Pagar con tarjeta
        public void PagoTarjeta(double precio) 
        {
            try 
            {
                Console.WriteLine("Introduce los siguientes datos para completar la compra:");
                Console.Write("Número de tarjeta: ");
                int nTarjeta = int.Parse(Console.ReadLine());

                Console.Write("Fecha de caducidad: ");
                int fechaCaducidad = int.Parse(Console.ReadLine());

                Console.Write("Código de seguridad (CVV): ");
                int cvv = int.Parse(Console.ReadLine());

                Console.WriteLine($"Compra realizada con éxito por un importe de {precio} euros");
            }
            catch (FormatException) 
            {
                Console.WriteLine("Se ha producido un error de formato, se esperaba un número entero para el número de tarjeta, fecha de caducidad o CVV.");
            }
        }

        // Pagar con efectivo
        public void PagoEfectivo(double precio)
        {
            double cent1 = 0.01;
            double cent2 = 0.02;
            double cent5 = 0.05;
            double cent10 = 0.1;
            double cent20 = 0.2;
            double cent50 = 0.5;
            double euro1 = 1.00;
            double euro2 = 2.00;
            double billete5 = 5.00;
            double billete10 = 10.00;

            do
            {
                Console.WriteLine("Qué desea emplear para el pago?: ");
                Console.WriteLine("1. Moneda 1 cent.");
                Console.WriteLine("2. Moneda 2 cent.");
                Console.WriteLine("3. Moneda 5 cent.");
                Console.WriteLine("4. Moneda 10 cent.");
                Console.WriteLine("5. Moneda 20 cent.");
                Console.WriteLine("6. Moneda 50 cent.");
                Console.WriteLine("7. Moneda 1 euro");
                Console.WriteLine("8. Moneda 2 euros");
                Console.WriteLine("9. billete 5 euros");
                Console.WriteLine("10. billete 10 euros");
                Console.WriteLine("11. billete 20 euros");
                Console.Write("Qué forma de pago desea emplear: ");

                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int unit1 = int.Parse(Console.ReadLine());

                            precio -= (unit1 * cent1);
                            break;

                        case 2:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int unit2 = int.Parse(Console.ReadLine());

                            precio -= (unit2 * cent2);
                            break;

                        case 3:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int unit5 = int.Parse(Console.ReadLine());

                            precio -= (unit5 * cent5);
                            break;

                        case 4:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int unit10 = int.Parse(Console.ReadLine());

                            precio -= (unit10 * cent10);
                            break;

                        case 5:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int unit20 = int.Parse(Console.ReadLine());

                            precio -= (unit20 * cent20);
                            break;

                        case 6:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int unit50 = int.Parse(Console.ReadLine());

                            precio -= (unit50 * cent50);
                            break;

                        case 7:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int mon7 = int.Parse(Console.ReadLine());

                            precio -= (mon7 * euro7);
                            break;

                        case 8:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int unit = int.Parse(Console.ReadLine());

                            precio -= (unit1 * cent1);
                            break;

                        case 9:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int mon2 = int.Parse(Console.ReadLine());

                            precio -= (mon2 * cent1);
                            break;

                        case 10:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int moneda2 = int.Parse(Console.ReadLine());

                            precio -= (unit1 * cent1);
                            break;

                        case 11:
                            Console.Write("Cuántas unidades desea insertar: ");
                            int moneda1 = int.Parse(Console.ReadLine());

                            precio -= (unit1 * cent1);
                            break;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Se ha procido un conclifto en la entrada ");
                }

                } while (precio > 0) ;


        }

        // Método para añadir un nuevo producto
        public void AddNewProduct() 
        {
            try 
            {
                Console.WriteLine("Qué tipo de producto desea añadir?");
                Console.WriteLine("1. Producto electrónico");
                Console.WriteLine("2. Producto alimenticio");
                Console.WriteLine("3. Material precioso");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion) 
                {
                    case 1:
                        // Creo, solicito la información necesaria y añado a la lista de productos un nuevo producto del tipo producto electrónico 
                        PElectronico pElectronico = new PElectronico(listaProductos.Count);
                        bool detallesE = pElectronico.SolicitarDetalles();

                        if (detallesE) 
                        {
                            listaProductos.Add(pElectronico);
                        }
                        break;

                    case 2:
                        // Creo, solicito la información necesaria y añado a la lista de productos un nuevo producto del tipo producto alimenticio
                        PAlimenticio pAlimenticio = new PAlimenticio(listaProductos.Count);
                        bool detallesA = pAlimenticio.SolicitarDetalles();

                        if (detallesA) 
                        {
                            listaProductos.Add(pAlimenticio);
                        }
                        break;

                    case 3:
                        // Creo, solicito la información necesaria y añado a la lista de productos un nuevo producto del tipo material precioso
                        MaterialPrecioso pMaterialPrecioso = new MaterialPrecioso(listaProductos.Count);
                        bool detallesMP = pMaterialPrecioso.SolicitarDetalles();

                        if (detallesMP) 
                        {
                            listaProductos.Add(pMaterialPrecioso);
                        }
                        break;

                    default:
                        Console.WriteLine("Número introducido no válido");
                        break;
                }
            }
            catch (FormatException) 
            {
                Console.WriteLine("Se ha producido un error de formato.");
            }
        }

        // Método que recibe un producto, solicita un número de unidades a reponer y las añade a las existentes
        public void ReponerProducto(Producto producto)
        {
            // Compruebo que el producto recibido no es null
            if (producto != null)
            {
                try
                {
                    // Solicito el número de unidades a reponer
                    Console.WriteLine($"El producto {producto.Nombre} dispone de {producto.Unidades} unidades disponibles");
                    Console.Write($"Introduce el número de unidades desea reponer: ");
                    int unidadesRepuestas = int.Parse(Console.ReadLine());

                    // Compruebo que las unidades introducidas no son negativas
                    if (unidadesRepuestas > 0)
                    {
                        // Añado las unidades recibidas a las unidades del producto
                        producto.Unidades += unidadesRepuestas;

                        Console.WriteLine($"Se han añadido {unidadesRepuestas} unidades, {producto.Nombre} ahora cuenta con {producto.Unidades} unidades.");
                    }
                    else
                    {
                        Console.WriteLine("No se pueden reponer unidades negativas");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Se ha producido un error de formato, se esperaba un número entero para las unidades a reponer.");
                }

            }
        }


        // Método que guarda la información de los productos disponibles en el momeento, en la máquina, en el archivo productos.csv
        public void GuardarProductosArchivo()
        {
            try
            {
                // Compruebo la existencia del archivo productos.csv
                if (File.Exists(_path))
                {
                    // Si el archivo existe, lo abro en modo escritura, sobreescribiendo su contenido
                    using (StreamWriter sw = new StreamWriter(_path, false))
                    {
                        // Header
                        sw.WriteLine("tipo_producto;id_producto;nombre_producto;unidades_producto;precio_unidad_producto;descripcion_producto;materiales;peso;calorias;grasa;azucar;tiene_bateria;precargado");

                        // Escribo en el archivo la información de los productos
                        foreach (Producto p in listaProductos)
                        {
                            sw.WriteLine(p.SaveInfo());
                        }
                    }
                }
                else
                {
                    // Si el archivo no existe, lo creo
                    File.Create(_path).Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error, No se encuentra el archivo {ex.FileName}: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error de E/S: " + ex.Message);
            }
        }

        // Cargar productos de un archivo recibido, a la máquina, se crean los productos y se añaden a la lista de productos
        public void CargaProductosArchivo(string path)
        {
            try
            {
                // Compruebo la existencia del archivo recibido
                if (File.Exists(path))
                {
                    // Compruebo si hay espacios libres para nuevos productos
                    if (listaProductos.Count < 12)
                    {
                        // Se abre el archivo en modo lectura
                        using (StreamReader sr = new StreamReader(path))
                        {
                            string line = "";

                            string header = sr.ReadLine();

                            // Esta variable se encargará de frenar la lectura de las lineas una vez se ha alcanzado el máximo de capacidad de productos en la máquina
                            bool cargaInterrumpida = false;

                            // Llevo una cuenta de los productos cargados
                            int productosCargados = 0;

                            // Se leen las líneas del archivo, si existen y la carga no ha sido inteerrumpida
                            while ((line = sr.ReadLine()) != null && !cargaInterrumpida)
                            {
                                if (listaProductos.Count < 12)
                                {
                                    // Se divide la linea leida mediante el delimitador ; separando así las propiedades de los productos
                                    string[] datos = line.Split(';');

                                    // Paso los campos del array obtenido como argumentos para los contructores de los productos

                                    string tipoProducto = datos[0];
                                    int id = int.Parse(datos[1]);
                                    string nombre = datos[2];
                                    int unidades = int.Parse(datos[3]);
                                    double precioUnidad = double.Parse(datos[4]);
                                    string descripcion = datos[5];

                                    // Diferencio que tipo de producto crear, usando el primer campo del array, que contiene un número del 1 al 2 que se corresponde con el tipo de producto
                                    switch (tipoProducto)
                                    {
                                        // Material Precioso
                                        case "1":
                                            MaterialPrecioso pMaterialPrecioso = new MaterialPrecioso(id, nombre, unidades, precioUnidad, descripcion, datos[6], double.Parse(datos[7]));
                                            listaProductos.Add(pMaterialPrecioso);
                                            break;

                                        // Producto Alimenticio
                                        case "2":
                                            PAlimenticio pAlimenticio = new PAlimenticio(id, nombre, unidades, precioUnidad, descripcion, int.Parse(datos[8]), int.Parse(datos[9]), int.Parse(datos[10]));
                                            listaProductos.Add(pAlimenticio);
                                            break;

                                        // Producto Electrónico
                                        case "3":
                                            PElectronico pElectronico = new PElectronico(id, nombre, unidades, precioUnidad, descripcion, datos[6], Convert.ToBoolean(datos[11]), Convert.ToBoolean(datos[12]));
                                            listaProductos.Add(pElectronico);
                                            break;
                                    }

                                    productosCargados++;
                                }
                                else
                                // Si los la capacidad de la máquina es igual o mayor de 12 interrumpo la lectura de líneas
                                {
                                    Console.WriteLine($"La máquina ha alcanzado su límite de capacidad, solo se han podido añadir los {productosCargados} primeros productos del archivo");
                                    cargaInterrumpida = true;
                                }
                            }

                            if (!cargaInterrumpida)
                            {
                                Console.WriteLine("Los productos del archivo se han añadido con éxito");
                            }
                        }
                    }
                    else
                    // La máquina máquina no acepta más productos. No se valorar la posibilidad de entrar a leer el archivo
                    {
                        Console.WriteLine("La máquina de vending no tiene espacio. Imposible añadir productos");
                    }
                }
                else
                // El nombre del archivo introducido no coincide con ningún archivo
                {
                    Console.WriteLine("No existe ningún archivo que coincida con el nombre introducido. Asegúrese de que contiene la extensión .csv y se encuentra en la carpeta índicada.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error. No se encuentra el archivo {ex.FileName}: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error de E/S: " + ex.Message);
            }

        }
    }
}
