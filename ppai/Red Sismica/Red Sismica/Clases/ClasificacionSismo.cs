using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class ClasificacionSismo
    {
        public int KmProfundidadDesde { get; set; }
        public int KmProfundidadHasta { get; set; }
        public string Nombre { get; set; }
        public ClasificacionSismo(int kmProfundidadDesde, int kmProfundidadHasta) 
        {
            KmProfundidadDesde = kmProfundidadDesde;
            KmProfundidadHasta = kmProfundidadHasta;
            if(kmProfundidadDesde < 61)
            {
                Nombre = "superficial";
            }
            else if (kmProfundidadDesde < 300) {
                Nombre = "intermedio";
            }
            else if (kmProfundidadDesde < 650)
            {
                Nombre = "profundo";
            }
        }

    }
}
