using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class CambioEstado
    {
        public DateTime FechaHoraInicio {  get; set; }
        public DateTime FechaHoraFin {  get; set; }
        public Estado Estado { get; set; }
        public Usuario Usuario { get; set; }

        public CambioEstado(DateTime fechaHoraInicio, Estado estado, Usuario usuario)
        {
            FechaHoraInicio = fechaHoraInicio;
            Estado = estado;
            Usuario = usuario;
        }

        public bool EsEstadoActual()
        {
            if (FechaHoraFin == DateTime.MinValue) { return true; }
            return false;
        }
    }
}
