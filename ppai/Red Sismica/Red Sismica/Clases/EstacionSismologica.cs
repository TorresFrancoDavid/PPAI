using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class EstacionSismologica
    {
        public string Nombre {  get; set; }
        public string CodigoEstacion {  get; set; }
        public EstacionSismologica(string nombre, string codigoEstacion)
        {
            Nombre = nombre;
            CodigoEstacion = codigoEstacion;
        }
    }
}
