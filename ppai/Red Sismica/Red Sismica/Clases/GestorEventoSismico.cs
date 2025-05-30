using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string OpcionIngresada { get; set; }

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

            TipoDeDato tipoDeDato1 = new TipoDeDato("Hz", "hercio", 5.5);
            TipoDeDato tipoDeDato2 = new TipoDeDato("Km/seg", "kilómetro sobre segundo", 10);
            TipoDeDato tipoDeDato3 = new TipoDeDato("Km/ciclo", "kilómetro sobre ciclo", 7.3);

            DetalleMuestraSismica detalleMuestraSismica1 = new DetalleMuestraSismica(11.2, tipoDeDato1);
            DetalleMuestraSismica detalleMuestraSismica2 = new DetalleMuestraSismica(8.5, tipoDeDato2);
            DetalleMuestraSismica detalleMuestraSismica3 = new DetalleMuestraSismica(3.3, tipoDeDato3);
            DetalleMuestraSismica detalleMuestraSismica4 = new DetalleMuestraSismica(3.2, tipoDeDato1);
            DetalleMuestraSismica detalleMuestraSismica5 = new DetalleMuestraSismica(9.0, tipoDeDato2);
            DetalleMuestraSismica detalleMuestraSismica6 = new DetalleMuestraSismica(8.8, tipoDeDato3);

            List<DetalleMuestraSismica> detallesMuestraSismica1 = new List<DetalleMuestraSismica>();
            detallesMuestraSismica1.Add(detalleMuestraSismica1);
            detallesMuestraSismica1.Add(detalleMuestraSismica2);
            detallesMuestraSismica1.Add(detalleMuestraSismica3);

            List<DetalleMuestraSismica> detallesMuestraSismica2 = new List<DetalleMuestraSismica>();
            detallesMuestraSismica2.Add(detalleMuestraSismica4);
            detallesMuestraSismica2.Add(detalleMuestraSismica5);
            detallesMuestraSismica2.Add(detalleMuestraSismica6);

            MuestraSismica muestraSismica1 = new MuestraSismica(hora1, detallesMuestraSismica1);
            MuestraSismica muestraSismica2 = new MuestraSismica(hora2, detallesMuestraSismica2);
            MuestraSismica muestraSismica3 = new MuestraSismica(hora3, detallesMuestraSismica2);

            muestraSismica1.DetallesMuestraSismica.Add(detalleMuestraSismica1);
            muestraSismica1.DetallesMuestraSismica.Add(detalleMuestraSismica2);
            muestraSismica1.DetallesMuestraSismica.Add(detalleMuestraSismica3);
            muestraSismica2.DetallesMuestraSismica.Add(detalleMuestraSismica4);
            muestraSismica2.DetallesMuestraSismica.Add(detalleMuestraSismica5);
            muestraSismica2.DetallesMuestraSismica.Add(detalleMuestraSismica6);
            muestraSismica3.DetallesMuestraSismica.Add(detalleMuestraSismica4);
            muestraSismica3.DetallesMuestraSismica.Add(detalleMuestraSismica5);
            muestraSismica3.DetallesMuestraSismica.Add(detalleMuestraSismica6);

            List<MuestraSismica> muestrasSismicas1 = new List<MuestraSismica>();
            List<MuestraSismica> muestrasSismicas2 = new List<MuestraSismica>();

            muestrasSismicas1.Add(muestraSismica1);
            muestrasSismicas1.Add(muestraSismica2);
            muestrasSismicas2.Add(muestraSismica3);
            muestrasSismicas2.Add(muestraSismica3);


            EstacionSismologica estacionSismologica1 = new EstacionSismologica("Estación Argentina", "AR");
            EstacionSismologica estacionSismologica2 = new EstacionSismologica("Estación Chilena", "CL");

            Sismografo sismografo1 = new Sismografo(hora1, "BZJS", 456, estacionSismologica1);
            Sismografo sismografo2 = new Sismografo(hora3, "ISAD", 387, estacionSismologica1);
            Sismografo sismografo3 = new Sismografo(hora2, "FASW", 973, estacionSismologica2);
            Sismografo sismografo4 = new Sismografo(hora1, "MSPR", 112, estacionSismologica2);

            SerieTemporal serieTemporal1 = new SerieTemporal(false, hora1, hora2, 5, sismografo1, muestrasSismicas1);
            SerieTemporal serieTemporal2 = new SerieTemporal(true, hora2, hora3, 7, sismografo2, muestrasSismicas2);
            SerieTemporal serieTemporal3 = new SerieTemporal(false, hora3, hora1, 3, sismografo3, muestrasSismicas2);
            SerieTemporal serieTemporal4 = new SerieTemporal(false, hora2, hora1, 4, sismografo4, muestrasSismicas2);

            MagnitudRichter magnitud1 = new MagnitudRichter(4, "Bajo");
            MagnitudRichter magnitud2 = new MagnitudRichter(5, "Intermedio");
            MagnitudRichter magnitud3 = new MagnitudRichter(6, "Alto");

            OrigenDeGeneracion origen = new OrigenDeGeneracion("Sismo interplaca", "Descripción del sismo interplaca");
            ClasificacionSismo clasificacion = new ClasificacionSismo(5, 8);
            AlcanceSismo alcance = new AlcanceSismo("Local", "Hasta 100km");

            Estado estado1 = new Estado("Evento Sísmico", "Auto Detectado");
            Estado estado2 = new Estado("Evento Sísmico", "Rechazado");
            Estado estado3 = new Estado("Evento Sísmico", "Bloqueado en Revisión");
            Estado estado4 = new Estado("Evento Sísmico", "Confirmado");

            Estados.Add(estado1);
            Estados.Add(estado2);
            Estados.Add(estado3);
            Estados.Add(estado4);

            Usuario usuario = new Usuario("123456", "Franco");
            SesionUsuarioLogueado = new Sesion(FechaHoraActual, usuario);
            CambioEstado cambioEstado = new CambioEstado(hora1, estado1, usuario);

            List<CambioEstado> listaCambioEstado = new List<CambioEstado>();
            listaCambioEstado.Add(cambioEstado);

            List<SerieTemporal> listaSerieTemporal1 = new List<SerieTemporal>();
            listaSerieTemporal1.Add(serieTemporal1);
            listaSerieTemporal1.Add(serieTemporal2);
            listaSerieTemporal1.Add(serieTemporal3);

            List<SerieTemporal> listaSerieTemporal2 = new List<SerieTemporal>();
            listaSerieTemporal2.Add(serieTemporal1);
            listaSerieTemporal2.Add(serieTemporal3);
            listaSerieTemporal2.Add(serieTemporal4);


            EventoSismico sismo1 = new EventoSismico(hora1, hora2, 2, 3, 4, 5, magnitud2, origen, clasificacion, alcance, estado1,
                listaCambioEstado, listaSerieTemporal1);
            EventoSismico sismo2 = new EventoSismico(hora3, hora1, 2, 3, 4, 5, magnitud1, origen, clasificacion, alcance, estado1, 
                listaCambioEstado, listaSerieTemporal2);
            EventoSismico sismo3 = new EventoSismico(hora2, hora3, 2, 3, 4, 5, magnitud1, origen, clasificacion, alcance, estado1,
                listaCambioEstado, listaSerieTemporal2);
            EventoSismico sismo4 = new EventoSismico(hora2, hora3, 2, 3, 4, 5, magnitud3, origen, clasificacion, alcance, estado2,
                listaCambioEstado, listaSerieTemporal1);


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

        public Usuario ObtenerUsuarioLogueado()
        {
            Usuario usuarioLogueado = SesionUsuarioLogueado.Usuario;
            return usuarioLogueado;
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

            Estado estado = BuscarEstadoBloqueadoEnRevision();

            GetFechaHoraActual();

            Usuario usuarioLogueado = ObtenerUsuarioLogueado();

            BloquearEventoSeleccionado(usuarioLogueado);

            BuscarDatosSismicos();

            BuscarSeriesTemporales();


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

        public void BuscarDatosSismicos()
        {
            (string nombreAlcance, string nombreClasificacion, string nombreOrigen) = EventoSismicoSeleccionado.ObtenerDatosSismicos();

            PantallaAsociada.MostrarDatosSismicos(nombreAlcance, nombreClasificacion, nombreOrigen);
        }

        public void BuscarSeriesTemporales()
        {
            List<string> listaSismografos = new List<string>();
            List<string> listaFechasHoras = new List<string>();
            List<string> listaValoresDenominacion = new List<string>();
            (listaSismografos, listaFechasHoras, listaValoresDenominacion) = EventoSismicoSeleccionado.ObtenerSeriesTemporales();

            /*foreach (string  s in listaSismografos)
            {
                Console.WriteLine(s);
                foreach (string f in listaFechasHoras)
                {
                    Console.WriteLine(f);
                    foreach (string v in listaValoresDenominacion)
                    {
                        Console.WriteLine(v);
                    }
                }
            }
            */

            ClasificarSeriesPorEstacion();

            HabilitarOpcVisualizarMapayEstacion();
        }

        public void ClasificarSeriesPorEstacion()
        {
            LlamarCUGenerarSismograma();
        }

        public void LlamarCUGenerarSismograma()
        {

        }

        public void HabilitarOpcVisualizarMapayEstacion()
        {
            PantallaAsociada.MostrarOpcVisualizarMapayEstacion();
        }

        public void OmitirVisualizacionMapayEstacion() 
        {
            HabilitarOpcionModificarEvento();
        }

        public void HabilitarOpcionModificarEvento()
        {
            PantallaAsociada.MostrarOpcModificarEvento();
        }

        public void OmitirModificacionEvento()
        {
            PantallaAsociada.MostrarOpcConfirmarEvento();
            PantallaAsociada.MostrarOpcRechazarEvento();
            PantallaAsociada.MostrarOpcSolicitarRevision();
            PantallaAsociada.PedirSeleccionOpcion();

        }

        public void TomarOpcRechazarEvento()
        {
            bool existenDatos = ValidarExistenciaDatosEvento();
            bool opcionValida = ValidarOpcIngresada();
            if (existenDatos && opcionValida)
            {
                GetFechaHoraActual();
                Estado estado = BuscarEstadoRechazado();
                Usuario usuarioLogueado = ObtenerUsuarioLogueado();
                RechazarEvento(estado, usuarioLogueado);

                FinCU();
            }
        }

        public bool ValidarExistenciaDatosEvento()
        {
            if (EventoSismicoSeleccionado.ValorMagnitud != null && EventoSismicoSeleccionado.AlcanceSismo != null &&
                EventoSismicoSeleccionado.OrigenDeGeneracion != null)
            {
                return true;
            }
            return false;
            
        }

        public bool ValidarOpcIngresada()
        {
            if (OpcionIngresada != null) 
            {  
                return true; 
            }
            return false;

        }

        public Estado BuscarEstadoRechazado()
        {
            foreach (Estado estado in Estados)
            {
                bool esEventoSismico = estado.EsAmbitoEventoSismico();
                bool esRechazado = estado.EsRechazado();

                if (esEventoSismico && esRechazado)
                {
                    return estado;
                }
            }
            return null;
        }

        public void RechazarEvento(Estado estado, Usuario usuarioLogueado)
        {
            EventoSismicoSeleccionado.RechazarEvento(FechaHoraActual, estado, usuarioLogueado);
        }

        public void FinCU()
        {
            MessageBox.Show(
                "Operación completada correctamente.",
                "Fin CU",
                MessageBoxButtons.OK
                );

            Environment.Exit(0);

        }
        public void TomarOpcConfirmarEvento()
        {
            bool existenDatos = ValidarExistenciaDatosEvento();
            bool opcionValida = ValidarOpcIngresada();
            if (existenDatos && opcionValida)
            {
                GetFechaHoraActual();
                Estado estado = BuscarEstadoConfirmado();
                Usuario usuarioLogueado = ObtenerUsuarioLogueado();
                ConfirmarEvento(estado, usuarioLogueado);

                FinCU();
            }
        }

        public Estado BuscarEstadoConfirmado()
        {
            foreach (Estado estado in Estados)
            {
                bool esEventoSismico = estado.EsAmbitoEventoSismico();
                bool esConfirmado = estado.EsConfirmado();

                if (esEventoSismico && esConfirmado)
                {
                    return estado;
                }
            }
            return null;
        }

        public void ConfirmarEvento(Estado estado, Usuario usuarioLogueado)
        {
            EventoSismicoSeleccionado.ConfirmarEvento(FechaHoraActual, estado, usuarioLogueado);
        }

    }
    
}
