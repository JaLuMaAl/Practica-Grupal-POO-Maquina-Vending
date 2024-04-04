using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class ProductoAlimenticio : Producto
    {
        // Información nutricional
        public int Calorias { get; set; }
        public int Grasa { get; set; }
        public int Azucar {  get; set; }

        public ProductoAlimenticio() { }
    }
}
