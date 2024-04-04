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
        // Constraseña que servirá para verificar al administrador para acceder a sus acciones
        public int Contraseña {  get; set; }

        public Admin() { }
        public Admin(int contraseña)
        {
            Contraseña = contraseña;
        }
    }
}
