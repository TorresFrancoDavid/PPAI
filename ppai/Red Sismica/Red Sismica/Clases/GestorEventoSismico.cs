using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Sismica.Clases
{
    public class GestorEventoSismico
    {
        public PantallaRegResultadoRM PantallaAsociada { get; set; }
        public List<EventoSismico> EventosSismicos { get; set; }
        public List<Estado> Estados { get; set; }
        public EventoSismico EventoSismicoSeleccionado { get; set; }
        public List<EventoSismico> EventosSismicosAutodetectadosyEnRevision { get; set; }
        public DateTime FechaHoraActual { get; set; }
        public Sesion SesionUsuarioLogueado { get; set; }

        public GestorEventoSismico(PantallaRegResultadoRM pantalla)
        {
            PantallaAsociada = pantalla;
            Estados = new List<Estado>();
            EventosSismicos = new List<EventoSismico>();
            EventosSismicosAutodetectadosyEnRevision = new List<EventoSismico>();
            BuscarEventosSismicos();
        }

        public void BuscarEventosSismicos()
        {
            DateTime hora1 = new DateTime(2025, 11, 02, 12, 05, 13);
            DateTime hora2 = new DateTime(2024, 12, 11, 12, 08, 35);
            DateTime hora3 = new DateTime(2024, 12, 11, 12, 05, 59);

            MagnitudRichter magnitud = new MagnitudRichter(5, "Intermedio");
            OrigenDeGeneracion origen = new OrigenDeGeneracion("Sismo interplaca", "Descripción del sismo interplaca");
            ClasificacionSismo clasificacion = new ClasificacionSismo(5, 8);
            AlcanceSismo alcance = new AlcanceSismo("Local", "Hasta 100km");

            Estado estado1 = new Estado("Evento Sísmico", "Auto Detectado");
            Estado estado2 = new Estado("Evento Sísmico", "Rechazado");
            Estado estado3 = new Estado("Evento Sísmico", "Bloqueado en Revisión");
            
            Estados.Add(estado1);
            Estados.Add(estado2);
            Estados.Add(estado3);

            Usuario usuario = new Usuario("123456", "Franco");
            SesionUsuarioLogueado = new Sesion(FechaHoraActual, usuario);
            CambioEstado cambioEstado = new CambioEstado(hora1, estado1, usuario);
            SerieTemporal serieTemporal = new SerieTemporal(true, hora2, hora1, 5);

            List<CambioEstado> listaCambioEstado = new List<CambioEstado>();
            listaCambioEstado.Add(cambioEstado);
            List<SerieTemporal> listaSerieTemporal = new List<SerieTemporal>();
            listaSerieTemporal.Add(serieTemporal);

            EventoSismico sismo1 = new EventoSismico(hora1, hora2, 2, 3, 4, 5, magnitud, origen, clasificacion, alcance, estado1,
                listaCambioEstado, listaSerieTemporal);
            EventoSismico sismo2 = new EventoSismico(hora1, hora1, 2, 3, 4, 5, magnitud, origen, clasificacion, alcance, estado1, 
                listaCambioEstado, listaSerieTemporal);
            EventoSismico sismo3 = new EventoSismico(hora1, hora3, 2, 3, 4, 5, magnitud, origen, clasificacion, alcance, estado1,
                listaCambioEstado, listaSerieTemporal);
            EventoSismico sismo4 = new EventoSismico(hora1, hora3, 2, 3, 4, 5, magnitud, origen, clasificacion, alcance, estado2,
                listaCambioEstado, listaSerieTemporal);


            EventosSismicos.Add(sismo1);
            EventosSismicos.Add(sismo2);
            EventosSismicos.Add(sismo3);
            EventosSismicos.Add(sismo4);



            foreach (EventoSismico sismo in EventosSismicos)
            {
                bool autodetectado = sismo.EsAutoDetectado();
                if (autodetectado)
                {
                    EventosSismicosAutodetectadosyEnRevision.Add(sismo);
                }

            }

            OrdenarEventosSismicos();
            PantallaAsociada.MostrarEventosSismicos(EventosSismicosAutodetectadosyEnRevision);
            PantallaAsociada.PedirSeleccionEventoSismico();

        }

        public void OrdenarEventosSismicos()
        {
            EventosSismicosAutodetectadosyEnRevision.Sort((p1, p2) => p2.FechaHoraOcurrencia.CompareTo(p1.FechaHoraOcurrencia));
            foreach (EventoSismico sismo in EventosSismicosAutodetectadosyEnRevision)
            {
                Console.WriteLine($"Hora Fin: {sismo.FechaHoraFin}, Hora comienzo: {sismo.FechaHoraOcurrencia}, {sismo.LatitudEpicentro}, " +
                $"{sismo.LatitudHipocentro}, {sismo.LongitudEpicentro}, {sismo.LongitudHipocentro}, {sismo.ValorMagnitud}"
                );
            }
        }

        public void TomarSeleccionEventoSismico(int indice)
        {
            EventoSismicoSeleccionado = EventosSismicosAutodetectadosyEnRevision[indice];
            Console.WriteLine(EventoSismicoSeleccionado.FechaHoraOcurrencia);

            Estado estado = BuscarEstadoBloqueadoEnRevision();

            GetFechaHoraActual();

            Usuario usuarioLogueado = SesionUsuarioLogueado.Usuario;

            BloquearEventoSeleccionado(usuarioLogueado);
        }

        public Estado BuscarEstadoBloqueadoEnRevision()
        {
            foreach (Estado estado in Estados)
            {
                bool esEventoSismico = estado.EsAmbitoEventoSismico();
                bool esBloqueadoEnRevision = estado.EsBloqueadoEnRevision();
                if (esEventoSismico && esBloqueadoEnRevision)
                {
                    return estado;
                }
            }
            return null;
        }

        public void GetFechaHoraActual()
        {
            FechaHoraActual = DateTime.Now;
        }

        public void BloquearEventoSeleccionado(Usuario usuarioLogueado)
        {
            Estado estadoBloqueado = new Estado("Evento Sísmico", "Bloqueado En Revisión");
            EventoSismicoSeleccionado.BloquearEvento(FechaHoraActual, estadoBloqueado, usuarioLogueado);
        }
    }
    
}
