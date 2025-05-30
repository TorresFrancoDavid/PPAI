
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class Sismografo
    {
        public DateTime FechaAdquisicion {  get; set; }
        public string IdentificadorSismografo { get; set; }
        public int NroSerie { get; set; }
        public EstacionSismologica EstacionSismologica { get; set; }
        public Sismografo(DateTime fechaAdquisicion, string identificadorSismografo, int nroSerie, EstacionSismologica estacion)
        {
            FechaAdquisicion = fechaAdquisicion;
            IdentificadorSismografo = identificadorSismografo;
            NroSerie = nroSerie;
            EstacionSismologica = estacion;
        }

        public string GetEstacionSismologica()
        {
            string nombre = EstacionSismologica.Nombre;
            return nombre;
        }
    }
}
