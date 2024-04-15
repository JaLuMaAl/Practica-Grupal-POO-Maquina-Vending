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

        // Constructor vacío
        public ProductManager() { }
        
        // Constructor parametrizado
        public ProductManager(List<Producto> listaP)
        {
            listaProductos = listaP;
        }

        // Solicita un ID y recorre la lista de productos en busca de un producto cuyo ID coincida con el introducido
        public Producto ElegirProducto()
        {
            Console.Write("Introduce el ID del producto: ");
            int id = int.Parse(Console.ReadLine());

            // Creo una instancia de la clase producto que almacenará el producto encontrado
            Producto pTemp = null;

            // Recorro la lista de productos comparando sus IDs con el introducido por el usuario
            foreach (Producto p in listaProductos)
            {
                if (p.Id == id)
                {
                    pTemp = p;
                }
                else
                {
                    Console.WriteLine("No se ha encontrado un producto con el ID introducido.");
                }
            }

            // Devuelvo el producto almacenado en pTemp, si no ha encontrado el producto devolverá null
            return pTemp;
        }

        public void Pagar(double precio)
        {
            Console.WriteLine("Métodos de pago disponible");
            Console.Write("\t1. Tarjeta\n\t2. Efectivo");

            int opcion = 0;

            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    PagoTarjeta(precio);
            }
        }

        public void PagoTarjeta(double precio)
        {
            Console.WriteLine("Introduce los sisguientes datos para completar la compra:");
            Console.Write("Número de tarjeta: ");
            int nTarjeta = int.Parse(Console.ReadLine());

            Console.Write("Fecha de caducidad: ");
            int fechaCaducidad = int.Parse(Console.ReadLine());

            Console.Write("Código de seguridad (CVV): ");
            int cvv = int.Parse(Console.ReadLine());

            Console.WriteLine($"Compra realizada con éxito por un importe de {precio}€");
        }

        public void PagoEfectivo(double precio)
        {

        }


    }
}
