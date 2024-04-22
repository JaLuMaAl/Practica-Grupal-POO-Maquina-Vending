using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instancio las clases MaquinaVending y ProductManager
            MaquinaVending maquinaVending = new MaquinaVending();

            int opcion = 0;

            do
            {
                Console.WriteLine(" --- MÁQUINA VENDING UFV --- ");
                Console.WriteLine("1. Comprar Productos");
                Console.WriteLine("2. Mostrar información de Producto");
                Console.WriteLine("3. Carga individual de Productos");
                Console.WriteLine("4. Carga completa de Productos");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1: 
                        maquinaVending.ComprarProductos();
                        break;
                    case 2:
                        maquinaVending.MostrarInfoProductos();
                        break;
                    case 3:
                        maquinaVending.CargaIndividual();
                        break;
                    case 4:
                        maquinaVending.CargaCompleta();
                        break;
                    case 5:
                        maquinaVending.SalirGuardar();
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 5);

        }
    }
}
