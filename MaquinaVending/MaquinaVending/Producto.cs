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
        
        // Precio por unidad del producto
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

        public virtual void SolicitarDetalles()
        {
            Console.WriteLine("Introduce el nombre");
            Nombre = Console.ReadLine();
            Console.WriteLine("Introduce en número de unidades");
            UnidadesMax = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce en número de unidades");
            UnidadesDisponibles = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca el precio de unidad");
            PrecioUnidad = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca una descripción sobre el producto");
            Descripcion = Console.ReadLine();
        }

        public abstract string SaveInfo();

        public abstract string ToFile();
    }
}
