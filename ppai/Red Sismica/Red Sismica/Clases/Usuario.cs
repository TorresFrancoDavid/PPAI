using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class Usuario
    {
        public string Contraseña { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public string Nombre { get; set; }
        public Usuario(string contraseña, string nombre) 
        {
            Contraseña = contraseña;
            Nombre = nombre;
            FechaHoraAlta = DateTime.Now;
        }
    }
}
