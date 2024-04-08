using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    
    internal class ProductManager
    {
        public List<Producto> listaProductos;

        public ProductManager(List<Producto> listaP)
        {
            listaProductos = listaP;
        }
    }
}
