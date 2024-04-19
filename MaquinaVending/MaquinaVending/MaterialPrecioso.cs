using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace MaquinaVending {
    internal class MaterialPrecioso : Producto {
        public string Tipo { get; set; }
        public double PesoGramos { get; set; }

        public MaterialPrecioso() { }
        public MaterialPrecioso(int id, string nombre, int unidadesMax, int unidadesDisponibles, double precioUnidad, string descripcion, TipoMaterialPrecioso tipo, double pesoGramos)
            : base(id, nombre, unidadesMax, unidadesDisponibles, precioUnidad, descripcion)
        {
            Id = id;
            Tipo = tipo;
            PesoGramos = pesoGramos;
        }
        public MaterialPrecioso(int id) : base(id) { }

        public override string MostrarInfoTotal() 
        {
            return $"{base.MostrarInfoTotal()}\n" +
                $"Tipo de Material: {Tipo}\n" +
                $"Peso (gramos): {PesoGramos}\n";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.WriteLine("Introduzca el tipo de material");
            Tipo = Console.ReadLine();
            Console.WriteLine("Introduzca cuanto pesa el producto en gramos");
            PesoGramos= int.Parse(Console.ReadLine());
        }

    }
}
