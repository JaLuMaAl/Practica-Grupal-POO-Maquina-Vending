using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        
        // Precio por unidad del producto
        public double PrecioUnidad { get; set; }
        public string Descripcion { get; set; }

        public Producto() { }
        public Producto(int id, string nombre, int unidades, double precioUnidad, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnidad = precioUnidad;
            Descripcion = descripcion;
        }

        public Producto(int id)
        {
            Id = id + 1;
        }

        // Método que devuelve un string con la información del producto
        public virtual string MostrarInfo()
        {
            return $"({Id}) {Nombre}" +
                $"\n\t{Unidades} unidades disponibles" +
                $"\n\t{PrecioUnidad}€/unidad" +
                $"{Descripcion}\n";
        }
    }
}
