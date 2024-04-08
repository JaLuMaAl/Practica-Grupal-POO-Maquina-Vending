using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class PElectronico : Producto
    {
        // Indicador de si el producto está por defecto cargado y listo para su uso
        public bool Precargado { get; set; }
        public bool Bateria { get; set; }

        // Añadir si hacen falta pilas o batería (bool), y los materiales utilizados (no se si sería un string, un enum o una lista)
        
        // Completar el constructor una vez incluidas las nuevas propiedades

        public PElectronico() { }
        public PElectronico(string nombre, int unidades, double unitPrice, string descripcion, bool precargado)
            :base(nombre, unidades, unitPrice, descripcion)
        {   
            Precargado = precargado;
        }

        public override string MostrarInfo()
        {
            
        }
    }
}
