using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class GraficoGrupos : Form
    {
        int[] grupos;
        public GraficoGrupos(int[] grupos)
        {
            this.grupos = grupos;
            InitializeComponent();
            GeraGrafico(0, (grupos.Length-1));
            CarregarCmbThresholds();
        }
        private void GeraGrafico(int min, int max)
        {
            Series serie = new Series(); ;
            chartGrupos.Series.Clear();
            chartGrupos.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("chartArea");
            chartGrupos.ChartAreas.Add(chartArea);
            serie.ChartType = SeriesChartType.Line;
            serie.ChartArea = "chartArea";
            serie.YValueType = ChartValueType.Int32;
            for (int i = min; i <= max; i++)
            {
                serie.Points.AddXY(i, grupos[i]);
            }
            chartGrupos.ChartAreas[0].AxisX.Minimum = min;
            chartGrupos.ChartAreas[0].AxisX.Maximum = max;
            chartGrupos.Series.Add(serie);
            chartGrupos.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartGrupos.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartGrupos.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartGrupos.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartGrupos.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartGrupos.ChartAreas[0].AxisY.Title = "Number of Clusters";
            chartGrupos.ChartAreas[0].AxisX.Title = "Threshold";
           // chartGrupos.ChartAreas[0].AxisY.Interval = 1;
        }
        private void CarregarCmbThresholds()
        {
            cmbMenorLimiar.Items.Clear();
            cmbMaiorLimiar.Items.Clear();
            int total = grupos.Length;
            List<string> atributos = new List<string>();
            for (int i = 0; i < total - 1; i++)
            {
                cmbMenorLimiar.Items.Insert(i, i);
                cmbMaiorLimiar.Items.Insert(i, (i + 1));
            }
            cmbMenorLimiar.SelectedIndex = 0;
            cmbMaiorLimiar.SelectedIndex = total - 2;
        }
        private void btnGeraGrafico_Click(object sender, EventArgs e)
        {
            int min = cmbMenorLimiar.SelectedIndex;
            int max = (int)cmbMaiorLimiar.SelectedItem;
            GeraGrafico(min, max);
        }
        private void cmbMenorLimiar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int min = cmbMenorLimiar.SelectedIndex;
            cmbMaiorLimiar.Items.Clear();
            int total = grupos.Length;
            int indice = 0;
            for (int i = min; i < total - 1; i++)
            {
                cmbMaiorLimiar.Items.Insert(indice, (i + 1));
                indice++;
            }
            cmbMaiorLimiar.SelectedIndex = cmbMaiorLimiar.Items.Count - 1;
        }
    }
}
