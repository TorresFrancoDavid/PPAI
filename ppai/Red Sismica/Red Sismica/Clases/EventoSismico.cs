using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class EventoSismico
    {
        public DateTime FechaHoraFin {  get; set; }
        public DateTime FechaHoraOcurrencia {  get; set; }
        public int LatitudEpicentro {  get; set; }
        public int LatitudHipocentro {  get; set; }
        public int LongitudEpicentro { get; set; }
        public int LongitudHipocentro { get; set; }
        public MagnitudRichter ValorMagnitud {  get; set; }
        public OrigenDeGeneracion OrigenDeGeneracion {  get; set; }
        public ClasificacionSismo ClasificacionSismo { get; set; }
        public AlcanceSismo AlcanceSismo {  get; set; }
        public Estado Estado {  get; set; }
        public List<CambioEstado> CambioEstados {  get; set; }
        public List<SerieTemporal> SeriesTemporales { get; set; }

        public EventoSismico(DateTime fechaHoraFin, DateTime fechaHoraOcurrencia, int latitudEpicentro, int latitudHipocentro, 
            int longitudEpicentro, int longitudHipocentro, MagnitudRichter valorMagnitud, OrigenDeGeneracion origenDeGeneracion,
            ClasificacionSismo clasificacionSismo, AlcanceSismo alcanceSismo, Estado estado, List<CambioEstado> listaCambioEstado, 
            List<SerieTemporal> listaSerieTemporal)
        {
            FechaHoraFin = fechaHoraFin;
            FechaHoraOcurrencia = fechaHoraOcurrencia;
            LatitudEpicentro = latitudEpicentro;
            LatitudHipocentro = latitudHipocentro;
            LongitudEpicentro = longitudEpicentro;
            LongitudHipocentro = longitudHipocentro;
            ValorMagnitud = valorMagnitud;
            OrigenDeGeneracion = origenDeGeneracion;
            ClasificacionSismo = clasificacionSismo;
            AlcanceSismo = alcanceSismo;
            Estado = estado;
            CambioEstados = listaCambioEstado;
            SeriesTemporales = listaSerieTemporal;
        }

        public bool EsAutoDetectado()
        {
            bool autoDetectado = Estado.EsAutoDetectado();
            return autoDetectado;
        }

        public void BloquearEvento(DateTime fechaHoraActual, Estado estado, Usuario usuario)
        {
            CambioEstado encontrado = null;
            foreach (CambioEstado cambioEstado in CambioEstados)
            {
                bool esEstadoActual = cambioEstado.EsEstadoActual();
                if (esEstadoActual)
                {
                    encontrado = cambioEstado;
                }

            }

            encontrado.FechaHoraFin = DateTime.Now;

            CrearNuevoCambioEstado(fechaHoraActual, estado, usuario);
        }

        public void CrearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Usuario usuario)
        {
            CambioEstado BloqueadoEnRevision = new CambioEstado(fechaHoraActual, estado, usuario);
        }
    }

    

}
