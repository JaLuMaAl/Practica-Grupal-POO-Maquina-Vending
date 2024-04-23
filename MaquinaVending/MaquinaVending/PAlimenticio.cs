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
        // Información nutricional
        public int Calorias { get; set; }
        public int Grasa { get; set; }
        public int Azucar {  get; set; }

        public PAlimenticio() { } 
        public PAlimenticio(int id,string nombre, int unidadesMax, int unidadesDisponibles, double precioUnidad, string descripcion, int kcal, int grasa, int azucar)
            :base(id,nombre, unidadesMax,unidadesDisponibles, precioUnidad, descripcion)
        {
            Id = id;
            Calorias = kcal;
            Grasa = grasa;
            Azucar = azucar;
        }

        public PAlimenticio(int id) : base(id) { }

        public override string MostrarInfoTotal()
        {
            return $"{base.MostrarInfoTotal()}\n" +
                $"\nCalorías: {Calorias} kcal\n" +
                $"Grasa: {Grasa}g\n" +
                $"Azucar: {Azucar}g\n";
        }

        public override void SolicitarDetalles() { 
            base.SolicitarDetalles();
            Console.WriteLine("Introduzca la cantidad de calorías que contiene el producto");
            Calorias = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca la cantidad de grasa en gramos");
            Grasa = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca la cantidad de azúcar en gramos");
            Azucar = int.Parse(Console.ReadLine());
        }

        public override string SaveInfo()
        {
            return $"2;{Nombre};{UnidadesMax};{UnidadesDisponibles};{PrecioUnidad};{Descripcion};;;{Calorias};{Grasa};{Azucar};;";
        }
    }
}
