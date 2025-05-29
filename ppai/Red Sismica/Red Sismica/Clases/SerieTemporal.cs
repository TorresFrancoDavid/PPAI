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
        public SerieTemporal(bool condicionAlarma, DateTime fechaHoraRegistroMuestras, DateTime fechaHoraRegistro, int frecuenciaMuestreo)
        {
            CondicionAlarma = condicionAlarma;
            FechaHoraRegistroMuestras = fechaHoraRegistroMuestras;
            FechaHoraRegistro = fechaHoraRegistro;
            FrecuenciaMuestreo = frecuenciaMuestreo;
        }
    }
}
