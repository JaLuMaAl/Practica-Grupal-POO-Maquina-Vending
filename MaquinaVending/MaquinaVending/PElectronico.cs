using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class PElectronico : Producto {
        public string Tipo { get; set; }
        public bool IncluyePilas { get; set; }
        public bool Precargado { get; set; }

        public PElectronico() { }
        public PElectronico(int id, string nombre, int unidadesMax, int unidadesDisponibles, double precioUnidad, string descripcion,bool incluyePilas, bool precargado)
            :base(id,nombre, unidadesMax, unidadesDisponibles, precioUnidad, descripcion)
        {
            IncluyePilas = incluyePilas;
            Precargado = precargado;
            
        }

        public PElectronico(int id):base(id) { }

        public override string MostrarInfoTotal() 
        {
            return $"{base.MostrarInfoTotal()}\n" +
                   $"¿Incluye pilas?: {(IncluyePilas ? "Sí" : "No")}\n" +
                   $"¿Está precargado?: {(Precargado ? "Sí" : "No")}\n";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.WriteLine("Introduzca (1) si el producto incluye pilas y (0) si el producto no incluye pilas");
            IncluyePilas = Console.ReadLine();
            Console.WriteLine("Introduzca cuanto pesa el producto en gramos");
            PesoGramos = int.Parse(Console.ReadLine());
        }
    }
}
