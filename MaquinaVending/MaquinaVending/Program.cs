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
            // Instancio un objeto de la clase MaquinaVending
            MaquinaVending maquinaVending = new MaquinaVending();

            int opcion = 0;

            // Se muestra un menú que permite al usuario introducir un número para seleccionar la acción que desea realizar
            do
            {
                Console.Clear();

                Console.WriteLine(" --- MÁQUINA VENDING UFV --- ");
                Console.WriteLine("1. Comprar Productos");
                Console.WriteLine("2. Mostrar información de los Productos");
                Console.WriteLine("3. Carga individual de Productos");
                Console.WriteLine("4. Carga completa de Productos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                try 
                {
                    switch (opcion) 
                    {
                        case 1:
                            Console.Clear();
                            maquinaVending.ComprarProductos();
                            break;

                        case 2:
                            Console.Clear();
                            maquinaVending.MostrarInfoProductos();
                            break;

                        case 3:
                            Console.Clear();
                            maquinaVending.CargaIndividual();
                            break;

                        case 4:
                            Console.Clear();
                            maquinaVending.CargaCompleta();
                            break;

                        case 5:
                            Console.Clear();
                            maquinaVending.SalirGuardar();
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Se ha producido un error, ingrese un número válido.");
                }

                Console.WriteLine("Pulsa para continuar...");
                Console.ReadKey();

            } while (opcion != 5);

        }
    }
}
