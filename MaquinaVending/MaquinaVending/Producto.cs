using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal abstract class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UnidadesMax { get; set; }
        public int UnidadesDisponibles { get; set; }
        public double PrecioUnidad { get; set; }
        public string Descripcion { get; set; }

        public Producto() { }
        public Producto(int id, string nombre, int unidadesMax, int unidadesDisponibles, double precioUnidad, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            UnidadesMax = unidadesMax;
            UnidadesDisponibles= unidadesDisponibles;
            PrecioUnidad = precioUnidad;
            Descripcion = descripcion;
        }

        public Producto(int id)
        {
            Id = id + 1;
        }

        //Mostrar información sobre el producto
        public string MostrarInfoParcial()
        {
            return $"({Id}) {Nombre}\n" +
                $"{UnidadesDisponibles} unidades disponibles\n" +
                $"{PrecioUnidad}€/unidad";
        }

        // Método que devuelve un string con la información del producto
        public virtual string MostrarInfoTotal()
        {
            return $"({Id}) {Nombre}\n" +
                $"{UnidadesDisponibles} unidades disponibles\n" +
                $"{PrecioUnidad}€/unidad\n" +
                $"{Descripcion}\n";
        }

        // Método que solicita los detalles del producto
        public virtual void SolicitarDetalles() {
            bool ejecucionCompletada = true;

            do {
                try {
                    Console.WriteLine("Introduce el nombre");
                    Nombre = Console.ReadLine();

                    Console.WriteLine("Introduce un número de unidades máximo");
                    UnidadesMax = int.Parse(Console.ReadLine());

                    Console.WriteLine("Introduce un número de unidades");
                    UnidadesDisponibles = int.Parse(Console.ReadLine());


                    Console.WriteLine("Por favor, introduzca un número entero de unidades");

                    Console.WriteLine("Introduzca el precio de unidad");
                    PrecioUnidad = double.Parse(Console.ReadLine());

                    Console.WriteLine("Introduzca una descripción sobre el producto");
                    Descripcion = Console.ReadLine();
                }
                catch (FormatException) {
                    ejecucionCompletada = false;
                    Console.WriteLine("Se ha producido un error al introducir los valores, vuelva a añadir el producto con unos valores válidos");
                }

            } while (!ejecucionCompletada);

        }
        public abstract string SaveInfo();
    }
}
