﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class PAlimenticio : Producto
    {
        // Información nutricional
        public int Calorias { get; set; }
        public int Grasa { get; set; }
        public int Azucar {  get; set; }

        public PAlimenticio() { } 
        public PAlimenticio(int id, string nombre, int unidades, double unitPrice, string descripcion, int kcal, int grasa, int azucar)
            :base(id, nombre, unidades, unitPrice, descripcion)
        {
            Calorias = kcal;
            Grasa = grasa;
            Azucar = azucar;
        }

        public override string MostrarInfo()
        {
            return base.MostrarInfo() + $"\n\tkcal: {Calorias} / grasa: {Grasa}g / azucar: {Azucar}g";
        }
    }
}
