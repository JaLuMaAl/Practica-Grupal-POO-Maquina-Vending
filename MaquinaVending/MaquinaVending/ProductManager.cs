﻿using System;
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
            // Creo una instancia de la clase producto que almacenará el producto encontrado
            Producto pTemp = null;
            try 
            {
                Console.Write("Introduce el ID del producto: ");
                int id = int.Parse(Console.ReadLine());

                // Recorro la lista de productos comparando sus IDs con el introducido por el usuario
                foreach (Producto p in listaProductos) {
                    if (p.Id == id) {
                        pTemp = p;
                    }
                    else {
                        Console.WriteLine("No se ha encontrado un producto con el ID introducido.");
                        Console.ReadKey();
                    }
                }
            }
            catch (FormatException) {
                Console.WriteLine("Se ha producido un error, se esperaba un número entero para el ID del producto.");
            }
            // Devuelvo el producto almacenado en pTemp, si no ha encontrado el producto devolverá null
            return pTemp;
        }

        // Método para pagar con tarjeta
        public void PagoTarjeta(double precio) {
            try 
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
            catch (FormatException) 
            {
                Console.WriteLine("Se ha producido un error, se esperaba un número entero para el número de tarjeta, fecha de caducidad o CVV.");
            }
        }

        // Método para pagar con efectivo
        public void PagoEfectivo(double precio)
        {

        }

        // Método para añadir producto nuevo dentro del método CargaIndividual()
        public void AddNewProduct() {
            try 
            {
                Console.WriteLine("Qué tipo de producto desea añadir?");
                Console.WriteLine("1. Producto electrónico");
                Console.WriteLine("2. Producto alimenticio");
                Console.WriteLine("3. Material precioso");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion) {
                    case 1:
                        // Creo, solicito la información necesaria y añado a la lista de productos un nuevo producto del tipo producto electrónico 
                        PElectronico pElectronico = new PElectronico(listaProductos.Count);
                        bool detallesE = pElectronico.SolicitarDetalles();

                        if (detallesE) {
                            listaProductos.Add(pElectronico);
                        }
                        break;

                    case 2:
                        // Creo, solicito la información necesaria y añado a la lista de productos un nuevo producto del tipo producto alimenticio
                        PAlimenticio pAlimenticio = new PAlimenticio(listaProductos.Count);
                        bool detallesA = pAlimenticio.SolicitarDetalles();

                        if (detallesA) {
                            listaProductos.Add(pAlimenticio);
                        }
                        break;

                    case 3:
                        // Creo, solicito la información necesaria y añado a la lista de productos un nuevo producto del tipo material precioso
                        MaterialPrecioso pMaterialPrecioso = new MaterialPrecioso(listaProductos.Count);
                        bool detallesMP = pMaterialPrecioso.SolicitarDetalles();

                        if (detallesMP) {
                            listaProductos.Add(pMaterialPrecioso);
                        }
                        break;

                    default:
                        Console.WriteLine("Número introducido no válido");
                        break;
                }
            }
            catch (FormatException) {
                Console.WriteLine("Se ha producido un error, se esperaba un número entero para seleccionar el tipo de producto.");
            }
        }

        // Método que recibe un producto, solicita un número de unidades a reponer y las añade a las existentes
        public void ReponerProducto(Producto producto)
        {
            try 
            {
                // Compruebo que el producto recibido no es null
                if (producto != null) {
                    // Solicito el número de unidades a reponer
                    Console.WriteLine($"El producto {producto.Nombre} dispone de {producto.Unidades} unidades disponibles");
                    Console.Write($"Introduce el número de unidades desea reponer: ");
                    int unidadesRepuestas = int.Parse(Console.ReadLine());

                    // Añado las unidades recibidas a las unidades del producto
                    producto.Unidades += unidadesRepuestas;

                    Console.WriteLine($"Se han añadido {unidadesRepuestas} unidades, {producto.Nombre} ahora cuenta con {producto.Unidades} unidades.");
                }
            }
            catch (FormatException) {
                Console.WriteLine("Se ha producido un error, se esperaba un número entero para las unidades a reponer.");
            }
        }


        // Método que guarda la información de los productos de la máquina en el archivo productos.csv
        public void GuardarProductosArchivo()
        {
            try 
            {
                // Compruebo la existencia del archivo productos.csv
                if (File.Exists(path)) {
                    // Si el archivo existe, lo abro en modo escritura, sobreescribiendo su contenido
                    using (StreamWriter sw = new StreamWriter(path, false)) {
                        // Header
                        sw.WriteLine("tipo_producto;id_producto;nombre_producto;unidades_producto;precio_unidad_producto;descripcion_producto;materiales;peso;calorias;grasa;azucar;tiene_bateria;precargado");

                        // Escribo en el archivo la información de los productos
                        foreach (Producto p in listaProductos) {
                            sw.WriteLine(p.SaveInfo());
                        }
                    }
                }
                else {
                    // Si el archivo no existe, lo creo
                    File.Create(path).Close();
                }
            }
            catch (IOException) {
                Console.WriteLine("Error al acceder al archivo.");
            }
        }

        // Método empleado para cargar la información de los productos de la máquina, leo el archivo "productos.csv" y creo los productos añadiendolos a la lista de productos
        public void CargaProductosArchivo()
        {
            try {
                // Compruebo la existencia del archivo
                if (File.Exists(path)) {
                    string line = "";

                    // Se abre el archivo en modo lectura
                    using (StreamReader sr = new StreamReader(path)) {
                        string header = sr.ReadLine();

                        while ((line = sr.ReadLine()) != null) {
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
                            switch (tipoProducto) {
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
                        }
                    }

                }
                else {
                    File.Create(path).Close();
                }
            }
            catch (FormatException) {
                Console.WriteLine("Se ha producido un error al leer los datos del archivo. Formato incorrecto.");
            }
            catch (IOException) {
                Console.WriteLine("Se ha producido un error de E/S al leer el archivo.");
            }
        }
    }
}
