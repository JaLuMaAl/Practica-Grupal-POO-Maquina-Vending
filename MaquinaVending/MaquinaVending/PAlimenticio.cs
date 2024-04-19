using System;
using System.Collections.Generic;
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
        public PAlimenticio(int id,string nombre, int unidades, double precioUnidad, string descripcion, int kcal, int grasa, int azucar)
            :base(id,nombre, unidades, precioUnidad, descripcion)
        {
            Id = id;
            Calorias = kcal;
            Grasa = grasa;
            Azucar = azucar;
        }

        public PAlimenticio(int id) : base(id) { }

        public override string MostrarInfo()
        {
            return $"{base.MostrarInfo()}\n" +
                $"\nCalorías: {Calorias} kcal\n" +
                $"Grasa: {Grasa}g\n" +
                $"Azucar: {Azucar}g\n";
        }
    }
}
