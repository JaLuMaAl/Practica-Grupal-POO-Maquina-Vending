using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MaquinaVending {
    internal class MaterialPrecioso : Producto {
        public enum TipoMaterialPrecioso 
        {
            Hierro,
            Oro,
            Plata
        }

        public TipoMaterialPrecioso Tipo { get; set; }
        public double PesoGramos { get; set; }

        public MaterialPrecioso(string nombre, int unidades, double precioUnidad, string descripcion, TipoMaterialPrecioso tipo, double pesoGramos)
            : base(nombre, unidades, precioUnidad, descripcion)
        {
            Tipo = tipo;
            PesoGramos = pesoGramos;
        }

        public override string MostrarInfo() 
        {
            return $"{base.MostrarInfo()}\n" +
                $"Tipo de Material: {Tipo}\n" +
                $"Peso (gramos): {PesoGramos}\n";
        }

    }
}
