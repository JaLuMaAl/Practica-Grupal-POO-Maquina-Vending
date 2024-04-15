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

        public PElectronico(int id, string nombre, int unidades, double precioUnidad, string descripcion, bool incluyePilas, bool precargado)
            : base(id, nombre, unidades, precioUnidad, descripcion) 
        {
            Id = id;
            IncluyePilas = incluyePilas;
            Precargado = precargado;
            
        }

        public override string MostrarInfo() 
        {
            return $"{base.MostrarInfo()}\n" +
                   $"¿Incluye pilas?: {(IncluyePilas ? "Sí" : "No")}\n" +
                   $"¿Está precargado?: {(Precargado ? "Sí" : "No")}\n";
        }

    }
}
