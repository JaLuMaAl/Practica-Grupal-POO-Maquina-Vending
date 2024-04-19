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
        public PElectronico(int id, string nombre, int unidadesMax, int unidadesDisponibles, double precioUnidad, string descripcion,string tipo, bool incluyePilas, bool precargado)
            :base(id,nombre, unidadesMax, unidadesDisponibles, precioUnidad, descripcion)
        {
            Tipo = tipo;
            IncluyePilas = incluyePilas;
            Precargado = precargado;
            
        }

        public PElectronico(int id):base(id) { }

        public override string MostrarInfoTotal() 
        {
            return $"{base.MostrarInfoTotal()}\n" +
                   $"Tipo: {Tipo}"+
                   $"¿Incluye pilas?: {(IncluyePilas ? "Sí" : "No")}\n" +
                   $"¿Está precargado?: {(Precargado ? "Sí" : "No")}\n";
        }

        public override void SolicitarDetalles() {
            base.SolicitarDetalles(); // Solicitar detalles generales del producto

            Console.WriteLine("Introduzca el tipo de material:");
            Tipo = Console.ReadLine();

            bool opcionValida = false;

            // Solicitar información sobre si el producto incluye pilas
            do {
                Console.WriteLine("Introduzca (1) si el producto incluye pilas y (0) si el producto no incluye pilas:");
                string input = Console.ReadLine();

                switch (input) {
                    case "0":
                        IncluyePilas = false;
                        opcionValida = true;
                        break;
                    case "1":
                        IncluyePilas = true;
                        opcionValida = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Introduzca 1 o 0.");
                        break;
                }
            } while (!opcionValida);

            opcionValida = false; // Restablecer la variable para el siguiente uso

            // Solicitar información sobre si el producto está precargado
            do {
                Console.WriteLine("Introduzca (1) si el producto está precargado y (0) si el producto no está precargado:");
                string input = Console.ReadLine();

                switch (input) {
                    case "0":
                        Precargado = false;
                        opcionValida = true;
                        break;
                    case "1":
                        Precargado = true;
                        opcionValida = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Introduzca 1 o 0.");
                        break;
                }
            } while (!opcionValida);
        }

    }
}
