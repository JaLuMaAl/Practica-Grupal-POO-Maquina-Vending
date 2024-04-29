using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class PAlimenticio : Producto
    {
        // Propiedades exclusivas de productos alimenticios
        public int Calorias { get; set; }
        public int Grasa { get; set; }
        public int Azucar {  get; set; }

        // Constructor vacío
        public PAlimenticio() { } 

        // Constructor parametrizado
        public PAlimenticio(int id,string nombre, int unidadesDisponibles, double precioUnidad, string descripcion, int kcal, int grasa, int azucar)
            :base(id,nombre,unidadesDisponibles, precioUnidad, descripcion)
        {
            Id = id;
            Calorias = kcal;
            Grasa = grasa;
            Azucar = azucar;
        }

        public PAlimenticio(int id) : base(id) { }

        // Método para mostrar información de productos alimenticios
        public override string MostrarInfoTotal()
        {
            return $"{base.MostrarInfoTotal()}\n" +
                $"\nCalorías: {Calorias} kcal\n" +
                $"Grasa: {Grasa}g\n" +
                $"Azucar: {Azucar}g\n";
        }

        // Método para solicitar detalles de productos alimenticios
        public override bool SolicitarDetalles() 
        {
            // Solicito los detalles comunes y almacena el booleano de regreso en una variable.
            bool ejecucionCompletada = base.SolicitarDetalles();

            // Si se ha realizado sin fallos la ejecución del método base, solicito los detalles específicos del producto alimenticio
            if (ejecucionCompletada) 
            {
                try 
                {
                    Console.Write("Introduce las calorías: ");
                    Calorias = int.Parse(Console.ReadLine());

                    Console.Write("Introduce la cantidad de grasa (en gramos): ");
                    Grasa = int.Parse(Console.ReadLine());

                    Console.Write("Introduce la cantidad de azúcar (en gramos): ");
                    Azucar = int.Parse(Console.ReadLine());
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Se ha producido un error al introducir los valores específicos del producto alimenticio. Pruebe a añadir de nuevo el producto");

                    // En caso de un error en la ejecución, declaro la variable ejecucíonCompletada a False, señalando que la ejecución no se ha dado como debería
                    ejecucionCompletada = false; 
                }
            }

            return ejecucionCompletada;
        }


        // Método que devuelve información sobre productos alimenticios para guardar en un archivo csv
        public override string SaveInfo()
        {
            return $"2;{Nombre};{UnidadesMax};{Unidades};{PrecioUnidad};{Descripcion};;;{Calorias};{Grasa};{Azucar};;";
        }
    }
}
