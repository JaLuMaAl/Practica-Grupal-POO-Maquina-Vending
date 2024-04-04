using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        
        // Precio por unidad del producto
        public double UnitPrice { get; set; }
        public string Descripcion { get; set; }

        public Producto(string nombre, int unidades, double unitPrice, string descripcion)
        {
            Nombre = nombre;
            Unidades = unidades;
            UnitPrice = unitPrice;
            Descripcion = descripcion;
        }
    }
}
