using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class MuestraSismica
    {
        public DateTime FechaHoraMuestra { get; set; }

        public List<DetalleMuestraSismica> DetallesMuestraSismica { get; set; } 

        public MuestraSismica(DateTime fechaHoraMuestra, List<DetalleMuestraSismica> detallesMuestraSismica)
        {
            FechaHoraMuestra = fechaHoraMuestra;
            DetallesMuestraSismica = detallesMuestraSismica;

        }

        public (string, string) GetDatos() 
        { 
            string fechaHora = FechaHoraMuestra.ToString();
            string valoresDenominacion = "|";
            foreach (DetalleMuestraSismica detalle in DetallesMuestraSismica)
            {
                string valor = detalle.GetDatos();
                valoresDenominacion += valor + "|";
            }
            return (fechaHora, valoresDenominacion);
        }
    }
}
