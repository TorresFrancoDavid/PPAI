using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class MagnitudRichter
    {
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public MagnitudRichter(int numero, string descripcion)
        {
            Numero = numero;
            Descripcion = descripcion;
        }
    }

   
}
