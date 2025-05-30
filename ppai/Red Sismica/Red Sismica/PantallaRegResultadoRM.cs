using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red_Sismica.Clases;

namespace Red_Sismica
{
    public partial class PantallaRegResultadoRM : Form
    {
        public GestorEventoSismico Gestor { get; set; }
        public PantallaRegResultadoRM()
        {
            InitializeComponent();
            dataGridView1.Visible = false;

        }

        public void adquirirDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarPantalla();
        }

        public void HabilitarPantalla()
        {
            Gestor = new GestorEventoSismico(this);

        }

        public void MostrarEventosSismicos(List<EventoSismico> lista)
        {
            if (lista.Count > 0)
            {
                dataGridView1.Visible = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }


                dataGridView1.DataSource = null;
                for (int i = 0; i < lista.Count; i++)
                {
                    dataGridView1.Rows.Add(lista[i].FechaHoraOcurrencia,
                        $"{lista[i].LatitudEpicentro}°, {lista[i].LongitudEpicentro}°",
                        $"{lista[i].LatitudHipocentro}°, {lista[i].LongitudHipocentro}°", lista[i].ValorMagnitud.Numero);

                }
            }
            else
            {
                MessageBox.Show(
                "No hay eventos sismicos que correspondan a la busqueda",
                "Fin CU",
                MessageBoxButtons.OK
                );
                Environment.Exit(0);
            }
        }
        public void PedirSeleccionEventoSismico()
        {
            label1.Visible = true;
            button1.Visible = true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                Gestor.TomarSeleccionEventoSismico(indice);
                label1.Visible = false;
                button1 .Visible = false;
                dataGridView1 .Enabled = false;
            }

        }

        public void MostrarDatosSismicos(string nombreAlcance, string nombreClasificacion, string nombreOrigen)
        {
            label3.Text = nombreAlcance;
            label5.Text = nombreClasificacion;
            label7.Text = nombreOrigen;
            label2 .Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
        }

        public void MostrarOpcVisualizarMapayEstacion()
        {
            label8.Visible = true;
            DialogResult resultado = MessageBox.Show(
                "¿Visualizar en un mapa el evento sísmico y las estaciones sismológicas involucradas?",
                "Visualizar evento sísmico",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("*Visualizando mapa*");
            }
            else
            {
                Gestor.OmitirVisualizacionMapayEstacion();
            }
        }

        public void MostrarOpcModificarEvento()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea modificar los datos de magnitud, alcance y origen de generación del evento sísmico?",
                "Modificar evento sísmico",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("*Panel para modificar datos*");
            }
            else
            {
                Gestor.OmitirModificacionEvento();
            }

        }

        public void MostrarOpcConfirmarEvento()
        {
            button2.Visible = true;
        }

        public void MostrarOpcRechazarEvento()
        {
            button3.Visible = true;
        }

        public void MostrarOpcSolicitarRevision()
        {
            button4.Visible = true;
        }

        public void PedirSeleccionOpcion()
        {
            label9.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gestor.OpcionIngresada = "Rechazar";
            Gestor.TomarOpcRechazarEvento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gestor.OpcionIngresada = "Confirmar";
            Gestor.TomarOpcConfirmarEvento();
        }
    }
}
