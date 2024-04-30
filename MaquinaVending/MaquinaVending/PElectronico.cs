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
        // Atributos exclusivos de productos electrónicos
        private string _materiales;
        private bool _incluyePilas;
        private bool _precargado;

        // Constructor vacío
        public PElectronico() { }

        // Constructor parametrizado
        public PElectronico(int id, string nombre, int unidadesDisponibles, double precioUnidad, string descripcion,string materiales, bool incluyePilas, bool precargado)
            :base(id,nombre, unidadesDisponibles, precioUnidad, descripcion)
        {
            _materiales = materiales;
            _incluyePilas = incluyePilas;
            _precargado = precargado;          
        }

        public PElectronico(int id):base(id) { }

        // Método para mostrar información de productos electrónicos
        public override string MostrarInfoTotal() 
        {
            return $"{base.MostrarInfoTotal()}" +
                   $"\tMateriales empleados: {_materiales}"+
                   $"\tIncluye pilas: {(_incluyePilas ? "Sí" : "No")}\n" +
                   $"\tEstá precargado: {(_precargado ? "Sí" : "No")}\n";
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
                    _materiales = Console.ReadLine();

                    // Solicitar la inclusión de pilas del producto
                    int pilas = 0;
                    do
                    {
                        Console.Write("Introduzca (1) si el producto incluye pilas y (0) si el producto no incluye pilas: ");
                        pilas = int.Parse(Console.ReadLine());

                        if (pilas == 1)
                        {
                            _incluyePilas = true;
                        }
                        else if (pilas == 0)
                        {
                            _incluyePilas = false;
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
                            _precargado = true;
                        }
                        else if (precargado == 0)
                        {
                            _precargado = false;
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
            return $"3;{Id};{Nombre};{Unidades};{PrecioUnidad};{Descripcion};{_materiales};;;;;{(_incluyePilas ? "1" : "0")};{(_precargado ? "1" : "0")}";
        }

    }
}
