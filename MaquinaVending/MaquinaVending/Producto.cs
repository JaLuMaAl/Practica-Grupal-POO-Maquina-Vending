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
        // Propiedades comunes a todos tipos de productos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UnidadesDisponibles { get; set; }
        public double PrecioUnidad { get; set; }
        public string Descripcion { get; set; }

        // Esta propiedad se ha creado para que el admin sea capaz de introducir un valor máximo de unidades (capacidad) en la máquina vending
        public int UnidadesMax { get; set; }

        // Constructor vacío
        public Producto() { }

        // Constructor parametrizado
        public Producto(int id, string nombre, int unidadesMax, int unidadesDisponibles, double precioUnidad, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            UnidadesMax = unidadesMax;
            UnidadesDisponibles= unidadesDisponibles;
            PrecioUnidad = precioUnidad;
            Descripcion = descripcion;
        }

        // Constructor usado al añadir un nuevo producto para que no se creen productos con un id repetido
        public Producto(int id)
        {
            Id = id + 1;
        }

        // Método que muestra información parcial del producto, se usa cuando el usuario quiere comprar productos
        public string MostrarInfoParcial()
        {
            return $"({Id}) {Nombre}\n" +
                $"{UnidadesDisponibles} unidades disponibles\n" +
                $"{PrecioUnidad}€/unidad";
        }

        // Método que devuelve un string con la información completa del producto
        public virtual string MostrarInfoTotal()
        {
            return $"({Id}) {Nombre}\n" +
                $"{UnidadesDisponibles} unidades disponibles\n" +
                $"{PrecioUnidad}€/unidad\n" +
                $"{Descripcion}\n";
        }

        // Método que solicita detalles del producto
        public virtual void SolicitarDetalles()
        {
            Console.Write("Introduce el nombre del nuevo producto: ");
            Nombre = Console.ReadLine();
            Console.Write("Introduce el número de unidades disponibles: ");
            UnidadesMax = int.Parse(Console.ReadLine());
            Console.Write("Introduce la capacidad máxima de unidades: ");
            UnidadesDisponibles = int.Parse(Console.ReadLine());
            Console.Write("Introduzca el precio de una unidad del producto (en euros): ");
            PrecioUnidad = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca una descripción sobre el producto: ");
            Descripcion = Console.ReadLine();
        }

        // Método abstracto implementado en las clases derivadas
        public abstract string SaveInfo();
    }
}
