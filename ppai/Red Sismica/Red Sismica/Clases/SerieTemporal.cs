using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class SerieTemporal
    {
        public bool CondicionAlarma {  get; set; }
        public DateTime FechaHoraRegistroMuestras {  get; set; }
        public DateTime FechaHoraRegistro {  get; set; }
        public int FrecuenciaMuestreo {  get; set; }
        public List<MuestraSismica> MuestrasSismicas { get; set; }

        public Sismografo Sismografo { get; set; }
        public SerieTemporal(bool condicionAlarma, DateTime fechaHoraRegistroMuestras, DateTime fechaHoraRegistro, 
            int frecuenciaMuestreo, Sismografo sismografo, List<MuestraSismica> muestrasSismicas)
        {
            CondicionAlarma = condicionAlarma;
            FechaHoraRegistroMuestras = fechaHoraRegistroMuestras;
            FechaHoraRegistro = fechaHoraRegistro;
            FrecuenciaMuestreo = frecuenciaMuestreo;
            Sismografo = sismografo;
            MuestrasSismicas = muestrasSismicas;
        }

        public (string, string, string) GetDatos()
        {
            string listaFechasHoras = null;
            string listaValoresDenominacion = null;
            foreach(MuestraSismica muestraSismica in MuestrasSismicas)
            {
                string fechaHora = null;
                string valoresDenominacion = null;
                (fechaHora, valoresDenominacion) = muestraSismica.GetDatos();
                listaFechasHoras += "\n" + fechaHora;
                listaValoresDenominacion += "\n" + valoresDenominacion;
            }
            string sismografo = Sismografo.GetEstacionSismologica();
            return (sismografo, listaFechasHoras, listaValoresDenominacion);
        }
    }
}
