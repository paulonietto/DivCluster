using System;
using System.Drawing;
using System.Windows.Forms;
using DivCluster;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        double[,] padroes;
        int totalPadroes;
        Form1 form1 = null;
        int quantidadeGrupos;
        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            LiberaBotoes(false);
        }

        #region Métodos Auxiliares
        private void LiberaBotoes(bool liberar)
        {
            btnGerarDados.Enabled = liberar;
            btnSalvarArquivo.Enabled = liberar;
        }
        private void AtualizaGridDadosGerados()
        {
            gridDados.Rows.Clear();
            gridDados.Columns.Clear();
            quantidadeGrupos = int.Parse(txtQuantidadeGrupos.Text);
            gridDados.Columns.Add("coluna1", "Parameters");
            for (int i = 1; i <= quantidadeGrupos; i++)
            {
                gridDados.Columns.Add("coluna" + (i + 1), "Cluster" + i);
            }
            string campo1 = "Data";
            gridDados.Rows.Add(campo1);
            string campo2 = "Min X";
            gridDados.Rows.Add(campo2);
            string campo3 = "Max X";
            gridDados.Rows.Add(campo3);
            string campo4 = "Min Y";
            gridDados.Rows.Add(campo4);
            string campo5 = "Max Y";
            gridDados.Rows.Add(campo5);
            gridDados.Columns[0].DefaultCellStyle.BackColor = Color.Gainsboro;
            gridDados.Columns[0].ReadOnly = true;
            gridDados.AllowUserToAddRows = false;
        }
        private void SalvaArquivo(string caminho)
        {
            try
            {
                StreamWriter escrever = new StreamWriter(caminho);
                for (int i = 0; i < padroes.GetLength(0); i++)
                {
                    escrever.WriteLine(padroes[i, 0] + "," + padroes[i, 1]);
                }
                escrever.Flush();
                escrever.Close();
            }
            catch (Exception)
            {
            }

        }
        private void CriaMatrizPadroes(ArrayList gruposDados)
        {
            int numeroPadroes = 0;
            for (int i = 0; i < gruposDados.Count; i++)
            {
                double[,] grupo = (double[,])gruposDados[i];
                numeroPadroes += grupo.GetLength(0);
            }
            padroes = new double[numeroPadroes, 2];
            int indiceX = 0;
            for (int i = 0; i < gruposDados.Count; i++)
            {
                double[,] grupo = (double[,])gruposDados[i];
                for (int j = 0; j < grupo.GetLength(0); j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        padroes[indiceX, k] = grupo[j, k];
                    }
                    indiceX++;
                }
            }
        }
        private int[,] RecuperarDadosGrid()
        {
            int[,] valoresGrid = new int[5, quantidadeGrupos];
            DataGridViewCell celula = null;
            for (int i = 1; i < gridDados.ColumnCount; i++)
            {
                for (int j = 0; j < gridDados.RowCount; j++)
                {
                    celula = gridDados[i, j];
                    valoresGrid[j, i - 1] = Convert.ToInt32(celula.Value.ToString());
                }
            }
            return valoresGrid;
        }
        private void MostraGrafico()
        {
            Series serie = new Series(); ;
            chartVisualizaDados.Series.Clear();
            chartVisualizaDados.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("chartArea");
            chartVisualizaDados.ChartAreas.Add(chartArea);
            serie.ChartType = SeriesChartType.Point;
            serie.ChartArea = "chartArea";
            serie.BorderColor = Color.Black;
            serie.XValueType = ChartValueType.Int32;
            for (int i = 0; i < totalPadroes; i++)
            {
                serie.Points.AddXY(padroes[i, 0], padroes[i, 1]);
            }
            chartVisualizaDados.Series.Add(serie);
           /* chartVisualizaDados.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartVisualizaDados.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartVisualizaDados.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartVisualizaDados.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartVisualizaDados.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;*/
            chartVisualizaDados.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chartVisualizaDados.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            // chartVisualizaDados.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            // chartVisualizaDados.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            // chartVisualizaDados.ChartAreas[0].AxisY.Interval = 1;

            /*    if (chartVisualizaDados.ChartAreas[0].AxisX.Minimum > chartVisualizaDados.ChartAreas[0].AxisY.Minimum)
                {
                    chartVisualizaDados.ChartAreas[0].AxisX.Minimum = chartVisualizaDados.ChartAreas[0].AxisY.Minimum;
                }
                else
                {
                    chartVisualizaDados.ChartAreas[0].AxisY.Minimum = chartVisualizaDados.ChartAreas[0].AxisX.Minimum;
                }
                if (chartVisualizaDados.ChartAreas[0].AxisX.Maximum > chartVisualizaDados.ChartAreas[0].AxisY.Maximum)
                {
                    chartVisualizaDados.ChartAreas[0].AxisY.Maximum = chartVisualizaDados.ChartAreas[0].AxisX.Maximum;
                }
                else
                {
                    chartVisualizaDados.ChartAreas[0].AxisX.Maximum = chartVisualizaDados.ChartAreas[0].AxisY.Maximum;
                }*/
        }
        private void AtualizaTxtDados()
        {
            totalPadroes = padroes.GetLength(0);
            String cluster = "";
            cluster += ("Cluster {\n");
            for (int i = 0; i < totalPadroes; i++)
            {
                cluster += "{";
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        cluster += string.Format("{0:0.###}", padroes[i, j]) + ", ";
                    }
                    else
                    {
                        cluster += string.Format("{0:0.###}", padroes[i, j]);
                    }

                }
                cluster += "}\n";
            }

            cluster += "}\n";
            txtDados.Text = cluster;
        }
        #endregion

        #region Eventos
        private void btnGerarDados_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] valoresGrid = RecuperarDadosGrid();
                ArrayList gruposDados = new ArrayList(valoresGrid.GetLength(0));
                try
                {
                    for (int i = 0; i < valoresGrid.GetLength(1); i++)
                    {
                        GeraDados geraDados = new GeraDados(valoresGrid[0, i], valoresGrid[1, i], valoresGrid[2, i], valoresGrid[3, i], valoresGrid[4, i]);
                        if (radioCirculo.Checked)
                        {
                            double x = (valoresGrid[2, i] - valoresGrid[1, i]);
                            double y = (valoresGrid[4, i] - valoresGrid[3, i]);
                            if (x == y)
                            {
                                double[,] grupo = geraDados.GeradorDeDadosCirculo();
                                gruposDados.Add(grupo.Clone());
                            }
                            else
                            {
                                MessageBox.Show("In cluster " + (i + 1) + ", X axis doesn't have diameter equal to the Y axis ", "Error");
                            }

                        }
                        else
                        {
                            double[,] grupo = geraDados.GeradorDeDadosQuadrado();
                            gruposDados.Add(grupo.Clone());
                        }
                    }
                    CriaMatrizPadroes(gruposDados);
                    AtualizaTxtDados();
                    MostraGrafico();
                    form1.RecebePadroesGerados(padroes);
                }
                catch (Exception)
                {
                    MessageBox.Show("Value Min must be less than value Max", "Error");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Enter a value in empty cell", "Error");
            }
        }
        private void txtQuantidadeGrupos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void btnGeraGrupos_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizaGridDadosGerados();
                LiberaBotoes(true);
            }
            catch (Exception)
            {

                MessageBox.Show("Enter a value", "Error");
            }

        }
        private void btnSalvarArquivo_Click(object sender, EventArgs e)
        {
            if (padroes != null)
            {
                SaveFileDialog salvarArquivo = new SaveFileDialog();
                salvarArquivo.Filter = "txt files|*.txt";
                salvarArquivo.ShowDialog();
                string caminho = salvarArquivo.FileName;
                SalvaArquivo(caminho);
            }

        }
        private void gridDados_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }

        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
