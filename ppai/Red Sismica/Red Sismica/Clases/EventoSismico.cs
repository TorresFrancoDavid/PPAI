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

            encontrado.FechaHoraFin = fechaHoraActual;

            CrearNuevoCambioEstado(fechaHoraActual, estado, usuario);
        }

        public void CrearNuevoCambioEstado(DateTime fechaHoraActual, Estado estado, Usuario usuario)
        {
            if (estado.NombreEstado == "Bloqueado En Revisión")
            {
                CambioEstado BloqueadoEnRevision = new CambioEstado(fechaHoraActual, estado, usuario);
                CambioEstados.Add(BloqueadoEnRevision);
                Console.WriteLine(BloqueadoEnRevision.FechaHoraInicio);
                Console.WriteLine(BloqueadoEnRevision.FechaHoraFin);
            }
            else if (estado.NombreEstado == "Rechazado")
            {
                CambioEstado Rechazado = new CambioEstado(fechaHoraActual, estado, usuario);
                CambioEstados.Add(Rechazado);
                Console.WriteLine(Rechazado.Usuario.Nombre);
                Console.WriteLine(Rechazado.Estado.NombreEstado);
                Console.WriteLine(Rechazado.FechaHoraInicio);
                Console.WriteLine(Rechazado.FechaHoraFin);
            }
            else if (estado.NombreEstado == "Confirmado")
            {
                CambioEstado Confirmado = new CambioEstado(fechaHoraActual, estado, usuario);
                CambioEstados.Add(Confirmado);
                Console.WriteLine(Confirmado.Usuario.Nombre);
                Console.WriteLine(Confirmado.Estado.NombreEstado);
                Console.WriteLine(Confirmado.FechaHoraInicio);
                Console.WriteLine(Confirmado.FechaHoraFin);
            }
        }

        public (string, string, string) ObtenerDatosSismicos()
        {
            string nombreAlcance = AlcanceSismo.Nombre;
            string nombreClasificacion = ClasificacionSismo.Nombre;
            string nombreOrigen = OrigenDeGeneracion.Nombre;

            return (nombreAlcance, nombreClasificacion, nombreOrigen);
        }

        public (List<string>, List<string>, List<string>) ObtenerSeriesTemporales()
        {
            List<string> listaSismografos = new List<string>();
            List<string> listaFechasHoras = new List<string>();
            List<string> listaValoresDenominacion = new List<string>();

            foreach(SerieTemporal serieTemporal in SeriesTemporales)
            {
                string sismografo = null;
                string fechasHoras = null;
                string valoresDenominacion = null;
                (sismografo, fechasHoras, valoresDenominacion) = serieTemporal.GetDatos();
                listaSismografos.Add(sismografo);
                listaFechasHoras.Add(fechasHoras);
                listaValoresDenominacion.Add(valoresDenominacion);
            }

            return (listaSismografos, listaFechasHoras, listaValoresDenominacion);
        }

        public void RechazarEvento(DateTime fechaHoraActual, Estado estado, Usuario usuario)
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

            encontrado.FechaHoraFin = fechaHoraActual;

            CrearNuevoCambioEstado(fechaHoraActual, estado, usuario);
            
        }

        public void ConfirmarEvento(DateTime fechaHoraActual, Estado estado, Usuario usuario)
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
            encontrado.FechaHoraFin = fechaHoraActual;

            CrearNuevoCambioEstado(fechaHoraActual, estado, usuario);

        }
    }

    

}
