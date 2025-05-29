using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class Sesion
    {
        public DateTime FechaHoraDesde { get; set; }
        public DateTime FechaHoraHasta { get; set; }

        public Usuario Usuario { get; set; }

        public Sesion(DateTime fechaHoraDesde, Usuario usuario)
        {
            FechaHoraDesde = fechaHoraDesde;
            Usuario = usuario;
        }
    }
}
