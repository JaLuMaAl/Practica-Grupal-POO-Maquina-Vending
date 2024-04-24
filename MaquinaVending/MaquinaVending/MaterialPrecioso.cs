using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace MaquinaVending {
    internal class MaterialPrecioso : Producto 
    {
        // Propiedades exclusivas de productos de tipo material precioso
        public string TipoMaterial { get; set; }
        public double PesoGramos { get; set; }

        // Constructor vacío
        public MaterialPrecioso() { }

        // Constructor parametrizado
        public MaterialPrecioso(int id, string nombre, int unidadesMax, int unidadesDisponibles, double precioUnidad, string descripcion, string material, double pesoGramos)
            : base(id, nombre, unidadesMax, unidadesDisponibles, precioUnidad, descripcion)
        {
            Id = id;
            TipoMaterial = material;
            PesoGramos = pesoGramos;
        }

        public MaterialPrecioso(int id) : base(id) { }

        // // Método para mostrar información de productos de tipo material precioso
        public override string MostrarInfoTotal() 
        {
            return $"{base.MostrarInfoTotal()}\n" +
                $"Tipo de Material: {TipoMaterial}\n" +
                $"Peso (gramos): {PesoGramos}\n";
        }

        // Método para solicitar detalles de productos tipo material precioso
        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.WriteLine("Introduzca el tipo de material: ");
            TipoMaterial = Console.ReadLine();
            Console.WriteLine("Introduzca cuanto pesa el producto (en gramos): ");
            PesoGramos= int.Parse(Console.ReadLine());
        }

        // Método que devuelve información sobre productos de tipo material precioso para guardar en un archivo csv
        public override string SaveInfo()
        {
            return $"1;{Nombre};{UnidadesMax};{UnidadesDisponibles};{PrecioUnidad};{Descripcion};{TipoMaterial};{PesoGramos};;;;;";
        }

    }
}
