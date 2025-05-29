using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red_Sismica.Clases;

namespace Red_Sismica
{
    public partial class PantallaRegResultadoRM : Form
    {
        private GestorEventoSismico Gestor { get; set; }
        public PantallaRegResultadoRM()
        {
            InitializeComponent();
            dataGridView1.Visible = false;

        }

        private void adquirirDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarPantalla();
        }

        public void HabilitarPantalla()
        {
            Gestor = new GestorEventoSismico(this);

        }

        public void MostrarEventosSismicos(List<EventoSismico> lista)
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

        public void PedirSeleccionEventoSismico()
        {
            label1.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                Gestor.TomarSeleccionEventoSismico(indice);
                label1.Visible = false;
                button1 .Visible = false;
                dataGridView1 .Visible = false;
            }
        }
    }
}
