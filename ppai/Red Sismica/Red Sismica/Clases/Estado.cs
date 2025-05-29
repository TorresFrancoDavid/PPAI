using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red_Sismica.Clases
{
    public class Estado
    {
        public string Ambito { get; set; }
        public string NombreEstado {  get; set; }
        public Estado(string ambito, string nombreEstado)
        {
            Ambito = ambito;
            NombreEstado = nombreEstado;
        }

        public bool EsAutoDetectado()
        {
            if (Ambito == "Evento Sísmico" && NombreEstado == "Auto Detectado")
            {
                return true;
            }
            return false;
        }

        public bool EsAmbitoEventoSismico()
        {
            if (Ambito == "Evento Sísmico")
            {
                return true;
            }
            return false;
        }

        public bool EsBloqueadoEnRevision()
        {
            if (NombreEstado == "Bloqueado en Revisión")
            {
                return true;
            }
            return false;

        }
    }
}
