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

        // Añadir si hacen falta pilas o batería (bool), y los materiales utilizados (no se si sería un string, un enum o una lista)
        
        // Completar el constructor una vez incluidas las nuevas propiedades

        public PElectronico() { }
        public PElectronico(string nombre, int unidades, double precioUnidad, string descripcion, bool precargado)
            :base(nombre, unidades, precioUnidad, descripcion)
        {   
            Precargado = precargado;
            
        }

        public PElectronico(int id):base(id) { }

        public override string MostrarInfo() 
        {
            return $"{base.MostrarInfo()}\n" +
                   $"¿Incluye pilas?: {(IncluyePilas ? "Sí" : "No")}\n" +
                   $"¿Está precargado?: {(Precargado ? "Sí" : "No")}\n";
        }

    }
}
