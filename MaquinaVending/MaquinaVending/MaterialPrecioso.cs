﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace MaquinaVending {
    internal class MaterialPrecioso : Producto 
    {
        // Atributos exclusivos de los productos de tipo material precioso
        private string TipoMaterial;
        private double PesoGramos;

        // Constructor vacío
        public MaterialPrecioso() { }

        // Constructor parametrizado
        public MaterialPrecioso(int id, string nombre, int unidades, double precioUnidad, string descripcion, string material, double pesoGramos)
            : base(id, nombre, unidades, precioUnidad, descripcion)
        {
            TipoMaterial = material;
            PesoGramos = pesoGramos;
        }

        public MaterialPrecioso(int id) : base(id) { }

        // // Método para mostrar información de productos de tipo material precioso
        public override string MostrarInfoTotal() 
        {
            return $"{base.MostrarInfoTotal()}" +
                $"Tipo de Material: {TipoMaterial}\n" +
                $"Peso (gramos): {PesoGramos}\n";
        }

        // Método para solicitar detalles del producto del tipo material precioso
        public override bool SolicitarDetalles() 
        {
            // Solicitar detalles comunes
            bool ejecucionCompletada = base.SolicitarDetalles(); 
            
            // Si se ha realizado con éxito la primera parte de la ejecución, solicito los detalles específicos
            if (ejecucionCompletada) 
            {
                try 
                {
                    Console.WriteLine("Introduzca el tipo de material del que está compuesto el producto: ");
                    TipoMaterial = Console.ReadLine();
                    Console.WriteLine("Introduzca el peso del producto (gramos) con decimales: ");
                    PesoGramos = int.Parse(Console.ReadLine());
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Se ha producido un error al introducir los valores específicos de material precioso. Pruebe a añadir de nuevo el producto");
                    // En caso de un error en la ejecución, declaro la variable ejecucíonCompletada a False, señalando que la ejecución no se ha dado como debería
                    ejecucionCompletada = false; 
                }
            }

            // Devuelvo el estado final de la variable que almacena si se ha completado la ejecución del código
            return ejecucionCompletada;
        }

        // Método que devuelve información sobre productos de tipo material precioso para guardar en un archivo csv
        public override string SaveInfo()
        {
            return $"1;{Id};{Nombre};{Unidades};{PrecioUnidad};{Descripcion};{TipoMaterial};{PesoGramos};;;;;";
        }

    }
}
