using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal abstract class Producto 
    {
        public int Id { get; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double PrecioUnidad { get; set; }
        public string Descripcion { get; set; }

        // Constructor vacío
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

        //Mostrar información sobre el producto
        public string MostrarInfoParcial() 
        {
            return $"({Id}) {Nombre}\n" +
                $"Unidades disponibles: {Unidades} \n" +
                $"Precio: {PrecioUnidad} euros / unidad";
        }

        // Método que devuelve un string con la información del producto
        public virtual string MostrarInfoTotal()
        {
            return $"({Id}) {Nombre}\n" +
                $"Unidades disponibles: {Unidades} \n" +
                $"Precio: {PrecioUnidad} euros / unidad\n" +
                $"{Descripcion}";
        }

        // Método que solicita los detalles del producto y modifica las propiedades del mismo
        public virtual bool SolicitarDetalles() 
        {
            // Variable que almacena si la ejecución del programa se ha completado. True si se ha realizado con éxito, False si ha habido algún error
            bool ejecucionCompletada = false;

            try 
            {
                Console.Write("Introduzca el nombre del producto: ");
                Nombre = Console.ReadLine();

                Console.Write("Introduzca las unidades: ");
                Unidades = int.Parse(Console.ReadLine());

                Console.Write("Introduzca el precio por unidad: ");
                PrecioUnidad = double.Parse(Console.ReadLine());

                Console.Write("Introduzca una descripción sobre el producto: ");
                Descripcion = Console.ReadLine();
                ejecucionCompletada = true;
               
            }
            catch (FormatException) 
            {
                Console.WriteLine("Se ha producido un error al introducir los valores, pruebe a vuelver a añadir el producto con unos valores válidos");
            }

            return ejecucionCompletada;
        }

        // Método abstracto encargado de devolver un string con la información de los productos, para facilitar su guardado en archivo
        public abstract string SaveInfo();
    }
}
