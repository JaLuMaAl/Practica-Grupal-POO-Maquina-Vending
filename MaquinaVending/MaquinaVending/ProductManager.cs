using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    
    internal class ProductManager
    {
        public List<Producto> listaProductos;

        // Ruta del archivo que almacena los productos y su información
        public string path { get; set; }

        // Constructor vacío
        public ProductManager() { }
        
        // Constructor parametrizado
        public ProductManager(List<Producto> listaP)
        {
            listaProductos = listaP;
            path = "productos.csv";
        }

        // Solicita un ID y recorre la lista de productos en busca de un producto cuyo ID coincida con el introducido
        public Producto ElegirProducto()
        {
            Console.Write("Introduce el ID del producto: ");
            int id = int.Parse(Console.ReadLine());

            // Creo una instancia de la clase producto que almacenará el producto encontrado
            Producto pTemp = null;

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
                }
            }

            // Devuelvo el producto almacenado en pTemp, si no ha encontrado el producto devolverá null
            return pTemp;
        }

        // Método para pagar con tarjeta
        public void PagoTarjeta(double precio)
        {
            Console.WriteLine("Introduce los siguientes datos para completar la compra:");
            Console.Write("Número de tarjeta: ");
            int nTarjeta = int.Parse(Console.ReadLine());

            Console.Write("Fecha de caducidad: ");
            int fechaCaducidad = int.Parse(Console.ReadLine());

            Console.Write("Código de seguridad (CVV): ");
            int cvv = int.Parse(Console.ReadLine());

            Console.WriteLine($"Compra realizada con éxito por un importe de {precio}€");
        }

        // Método para pagar con efectivo
        public void PagoEfectivo(double precio)
        {

        }

        // Método para añadir producto nuevo dentro del método CargaIndividual()
        public void AddNewProduct()
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

        // Método que recibe un producto, solicita un número de unidades a reponer y las añade a las existentes
        public void ReponerProducto(Producto producto)
        {
            // Compruebo que el producto recibido no es null
            if (producto != null)
            {
                // Solicito el número de unidades a reponer
                Console.WriteLine($"El producto {producto.Nombre} dispone de {producto.Unidades} unidades disponibles");
                Console.Write($"Introduce el número de unidades desea reponer: ");
                int unidadesRepuestas = int.Parse(Console.ReadLine());

                // Añado las unidades recibidas a las unidades del producto
                producto.Unidades += unidadesRepuestas;

                Console.WriteLine($"Se han añadido {unidadesRepuestas} unidades, {producto.Nombre} ahora cuenta con {producto.Unidades} unidades.");
            }
        }

        public void GuardarProductosArchivo()
        {
            if (File.Exists(path))
            {
                // Abro el archivo productos.csv en modo escritura sobreescribiendo su contenido
                using (StreamWriter sw = new StreamWriter("productos.csv", false))
                {
                    foreach (Producto p in listaProductos)
                    {
                        sw.WriteLine(p.SaveInfo());
                    }
                }
            }
            else
            {
                File.Create(path).Close();
            }
        }

        public void CargaProductosArchivo()
        {
            if (File.Exists(path))
            {
                string line = "";
                using (StreamReader sr = new StreamReader(path))
                {
                    string header = sr.ReadLine();

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] datos = line.Split(';');
                    }
                }
            }
            
        }
    }
}
