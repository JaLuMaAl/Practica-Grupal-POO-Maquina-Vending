using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending
{
    internal class Admin
    {
        // Clave que verificará al administrador para poder acceder a sus acciones exclusivas
        public int Clave { get; set; }

        public Admin() { }
        public Admin(int clave)
        {
            Clave = clave;
        }

        // Método booleano que solicita una clave y la compara con la del admin, si coinciden devuelve true, sino devuelve false
        public bool CheckAdmin()
        {
            bool check = false;

            // Solicito la clave al usuario
            Console.Write("Introduce la clave de administrador para acceder a esta funcionalidad: ");
            int clave = int.Parse(Console.ReadLine());

            // Comparo la clave obtenida con la del admin
            if (Clave == clave)
            {
                check = true;
            }

            return check;
        }
    }
}
