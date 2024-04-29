using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class PElectronico : Producto 
    {
        // Propiedades exclusivas de productos electrónicos
        public string Materiales { get; set; }
        public bool IncluyePilas { get; set; }
        public bool Precargado { get; set; }

        // Constructor vacío
        public PElectronico() { }

        // Constructor parametrizado
        public PElectronico(int id, string nombre, int unidadesDisponibles, double precioUnidad, string descripcion,string materiales, bool incluyePilas, bool precargado)
            :base(id,nombre, unidadesDisponibles, precioUnidad, descripcion)
        {
            Materiales = materiales;
            IncluyePilas = incluyePilas;
            Precargado = precargado;
            
        }

        public PElectronico(int id):base(id) { }

        // Método para mostrar información de productos electrónicos
        public override string MostrarInfoTotal() 
        {
            return $"{base.MostrarInfoTotal()}" +
                   $"Materiales empleados: {Materiales}"+
                   $"¿Incluye pilas?: {(IncluyePilas ? "Sí" : "No")}\n" +
                   $"¿Está precargado?: {(Precargado ? "Sí" : "No")}\n";
        }

        // Método para solicitar detalles de productos electrónicos
        public override bool SolicitarDetalles() 
        {
            bool ejecucionCompletada = base.SolicitarDetalles(); // Solicitar detalles comunes

            if (ejecucionCompletada) 
            {
                try 
                {
                    Console.Write("Introduzca los materiales utilizados en la fabricación del producto: ");
                    Materiales = Console.ReadLine();

                    // Solicitar la inclusión de pilas del producto
                    int pilas = 0;
                    do
                    {
                        Console.Write("Introduzca (1) si el producto incluye pilas y (0) si el producto no incluye pilas: ");
                        pilas = int.Parse(Console.ReadLine());

                        if (pilas == 1)
                        {
                            IncluyePilas = true;
                        }
                        else if (pilas == 0)
                        {
                            IncluyePilas = false;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida.");
                        }
                    }
                    while (pilas < 0 || pilas > 1);


                    // Solicitar si el producto viene precargado
                    int precargado = 0;
                    do 
                    {
                        Console.Write("Introduzca (1) si el producto está precargado y (0) si el producto no está precargado: ");
                        precargado = int.Parse(Console.ReadLine());

                        if (precargado == 1)
                        {
                            Precargado = true;
                        }
                        else if (precargado == 0)
                        {
                            Precargado = false;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida.");
                        }
                    } while (precargado < 0 || precargado > 1);
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Se ha producido un error al introducir los valores específicos del producto electrónico. Pruebe a añadir de nuevo el producto");
                    // En caso de un error en la ejecución, declaro la variable ejecucíonCompletada a False, señalando que la ejecución no se ha dado como debería
                    ejecucionCompletada = false; 
                }
            }

            return ejecucionCompletada;
        }

        // Método que devuelve información sobre productos electrónicos para guardar en un archivo csv
        public override string SaveInfo()
        {
            return $"3;{Id};{Nombre};{Unidades};{PrecioUnidad};{Descripcion};{Materiales};;;;;{(IncluyePilas ? "1" : "0")};{(Precargado ? "1" : "0")}";
        }

    }
}
