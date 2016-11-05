using DivCluster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int colunas;
        private int linhas;
        private double[,] padroes;
        private string[] classe;
        private static ArrayList agrupamento;
        private double[,] padroes2;
        private String valorIndice;
        private Stopwatch stopwatch;
        private int indiceDiametro;
        private int[] numeroGrupos;
        public Form1()
        {
            CultureInfo culture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            InitializeComponent();
            Inicializar();
        }


        #region Métodos Auxiliares
        private void FinalizaProcessamento()
        {
            ControlaAnimacaoProcessamento(false);
            LiberaControles(true);
        }
        private void BloqueiaIndice()
        {
            groupBox4.Enabled = false;
        }
        private void LiberaIndiceValidacao()
        {
            chkDunn.Enabled = true;
            chkSilhouette.Enabled = true;
            if (classe != null)
            {
                chkRand.Enabled = true;
            }
            else
            {
                chkRand.Enabled = false;
            }
        }
        private void ResultadoAgrupamento()
        {
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            string tempo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                time.Hours, time.Minutes, time.Seconds,
                 time.Milliseconds / 10);
            AtualizaRichTextBox();
            AtualizaRichTextBox("RunTime = " + tempo);
        }
        public void RecebePadroesGerados(double[,] padroes)
        {
            this.padroes = padroes;
            InicializaPadroes();
            classe = null;
            LiberaDivCluster();
        }
        private void InicializaPadroes()
        {
            colunas = padroes.GetLength(1);
            linhas = padroes.GetLength(0);
            padroes2 = null;
        }
        private void ResetaTabPage2()
        {
            pictureBox.Image = null;
            labelProcesso.Text = "";
            LiberaControles(true);
            stopwatch.Stop();
        }
        private void Inicializar()
        {
            CarregarCmbAlgoritmos();
            CarregarCmbDiametro();
            BloquearDesbloquearAbas(false);
            CarregarCmbTamanhoPontos();
        }
        private void LiberarELimparCamposCluster(bool withEstimation)
        {
            txtNumberClusters.Text = "";
            txtJumpsThreshold.Text = "1";
            txtNumberRunningThreshold.Text = "";

            grpEstimation.Enabled = withEstimation;
            lblNumberClusters.Enabled = !withEstimation;
            txtNumberClusters.Enabled = !withEstimation;
        }
        private void LiberarCmbDiametro(bool diana)
        {
            if (diana)
            {
                cmbDiametro.Enabled = diana;
            }
            else
            {
                cmbDiametro.Enabled = diana;
            }
        }
        private void AbreArquivo(string arquivo)
        {
            StreamReader ler = new StreamReader(arquivo);
            ArrayList textoPadroes = new ArrayList();
            string linhaTexto;
            bool possuiClasse = false;
            while (ler.Peek() > -1)
            {
                linhaTexto = ler.ReadLine();
                if (linhaTexto.Substring(0, 1) == "@")
                {
                    if (linhaTexto.Contains("class"))
                    {
                        possuiClasse = true;
                    }
                }
                else if (linhaTexto.Substring(0, 1) != "%")
                {
                    textoPadroes.Add(linhaTexto);
                }
            }
            String[] quantidadeAtributos = textoPadroes[0].ToString().Split(',');
            colunas = quantidadeAtributos.Length;
            linhas = textoPadroes.Count;
            if (possuiClasse == true)
            {
                classe = new string[linhas];
                colunas--;
            }
            if (classe != null)
            {
                string valorClasse;
                for (int i = 0; i < linhas; i++)
                {
                    valorClasse = textoPadroes[i].ToString().Split(',')[colunas];
                    if (valorClasse == "")
                    {
                        classe[i] = "Unknown";
                    }
                    else
                    {
                        classe[i] = valorClasse;
                    }

                }
            }
            string valor;
            bool resultado;
            double valida;
            int[] tiposAtributos = new int[colunas];
            for (int i = 0; i < colunas; i++)
            {
                valor = textoPadroes[i].ToString().Split(',')[i];
                resultado = double.TryParse(valor, out valida);
                if (resultado)
                {
                    tiposAtributos[i] = 0;
                }
                else
                {
                    tiposAtributos[i] = 1;
                }
            }
            padroes = new double[linhas, colunas];
            Dictionary<string, int> letrasNumeros;
            bool valorAusente = false;
            bool alteraPadroes = false;
            string ausentes = "";
            string letrasParaNumeros = "";
            string ruido = "";
            for (int j = 0; j < colunas; j++)
            {
                letrasNumeros = new Dictionary<string, int>(linhas);
                int numero = 0;
                for (int i = 0; i < linhas; i++)
                {
                    valor = textoPadroes[i].ToString().Split(',')[j];
                    resultado = double.TryParse(valor, out valida);
                    if (resultado)
                    {
                        padroes[i, j] = valida;
                    }
                    else if (valor != "")
                    {
                        alteraPadroes = true;
                        if (letrasNumeros.ContainsKey(valor))
                        {
                            padroes[i, j] = letrasNumeros[valor];
                        }
                        else
                        {
                            if (valor != "" && tiposAtributos[j] == 1)
                            {
                                letrasNumeros.Add(valor, numero);
                                padroes[i, j] = numero;
                                letrasParaNumeros += "A" + (j + 1) + " '" + valor + "' = " + numero + "\n";
                                numero++;
                            }
                            else
                            {
                                padroes[i, j] = double.NaN;
                                valorAusente = true;
                                ruido += "P" + (i + 1) + " Attribute " + (j + 1) + "\n";
                            }

                        }
                    }
                    else
                    {
                        padroes[i, j] = double.NaN;
                        valorAusente = true;
                        alteraPadroes = true;
                        ausentes += "P" + (i + 1) + " Attribute " + (j + 1) + "\n";
                    }
                }
            }
            if (valorAusente)
            {
                AtributoAusente atributoAusente = new AtributoAusente(padroes, tiposAtributos);
                atributoAusente.ImputaAtributo();
            }
            if (alteraPadroes)
            {
                Form3 form3 = new Form3(ausentes, letrasParaNumeros, ruido);
                form3.Show();
            }
            InicializaPadroes();
            ler.Close();
        }
        private void AtualizaAgrupamento()
        {
            Dictionary<int, Double[]> grupo = new Dictionary<int, Double[]>(linhas);
            for (int i = 0; i < linhas; i++)
            {
                Double[] padrao = new Double[colunas];
                for (int j = 0; j < colunas; j++)
                {
                    padrao[j] = padroes[i, j];
                }
                grupo.Add((i + 1), padrao);
            }
            agrupamento = new ArrayList(1);
            agrupamento.Add(grupo);
        }
        private void AtualizaLabel(int linhas, int colunas)
        {
            lblAttributes.Text = colunas.ToString();
            lblInstances.Text = linhas.ToString();
        }
        private void AtualizaGrid(double[,] padroes, DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            string[] padrao;
            grid.Columns.Add("coluna1", "Patterns");
            for (int i = 1; i <= colunas; i++)
            {
                grid.Columns.Add("coluna" + (i + 1), "A" + i);
            }
            if (classe != null)
            {
                grid.Columns.Add("coluna" + (colunas + 2), "Class");
            }
            for (int i = 0; i < linhas; i++)
            {
                if (classe != null)
                {
                    padrao = new string[colunas + 2];
                }
                else
                {
                    padrao = new string[colunas + 1];
                }
                padrao[0] = "P" + (i + 1);
                grid.Columns[0].DefaultCellStyle.BackColor = Color.Gainsboro;
                for (int j = 0; j < colunas; j++)
                {
                    padrao[j + 1] = string.Format("{0:0.###}", padroes[i, j]);
                }
                if (classe != null)
                {
                    padrao[(colunas + 1)] = classe[i];
                }
                grid.Rows.Add(padrao);
            }
            grid.AllowUserToAddRows = false;
        }
        private void CarregarCmbAlgoritmos()
        {
            cmbAlgoritmos.Items.Insert(0, "DIANA");
            cmbAlgoritmos.Items.Insert(1, "DIANA With Centroid");
            cmbAlgoritmos.Items.Insert(2, "K-Means");
            cmbAlgoritmos.Items.Insert(3, "DIANA With Cluster Estimation");
            cmbAlgoritmos.Items.Insert(4, "DIANA With Centroid and Cluster Estimation");
            cmbAlgoritmos.Items.Insert(5, "K-Means With Cluster Estimation");
            cmbAlgoritmos.Items.Insert(6, "Cluster Estimation");
        }
        private void CarregarCmbDiametro()
        {
            cmbDiametro.Items.Insert(0, "Complete Diameter");
            cmbDiametro.Items.Insert(1, "Average Diameter");
            cmbDiametro.Items.Insert(2, "Centroid Diameter");
            cmbDiametro.SelectedIndex = 0;
        }
        private void CarregarCmbTamanhoPontos()
        {
            cmbTamanhoPonto.Items.Insert(0, 5);
            cmbTamanhoPonto.Items.Insert(1, 7);
            cmbTamanhoPonto.Items.Insert(2, 10);
            cmbTamanhoPonto.Items.Insert(3, 12);
            cmbTamanhoPonto.Items.Insert(4, 15);
            cmbTamanhoPonto.Items.Insert(5, 20);
            cmbTamanhoPonto.SelectedIndex = 0;
        }
        private void LiberaDivCluster()
        {
            BloquearDesbloquearAbas(true);
            AtualizaGrid(padroes, Grid);
            AtualizaGrid(padroes, Grid2);
            AtualizaLabel(linhas, colunas);
            CarregarCmbAtributos(colunas);
            AtualizaAgrupamento();
            chkMinMax.Checked = false;
            // chkDunn.Checked = false;
            //  chkSilhouette.Checked = false;
            chkRemoveDuplicate.Checked = false;
            if (classe != null)
            {
                chkContraditory.Enabled = true;
                chkContraditory.Checked = false;
                // chkRand.Enabled = true;
                // chkRand.Checked = false;
            }
            else
            {
                chkContraditory.Enabled = false;
                //  chkRand.Enabled = false;
            }

        }
        private void AtualizaRichTextBox()
        {
            txtClusterAlgoritms.Text = "";
            for (int i = 0; i < agrupamento.Count; i++)
            {
                txtClusterAlgoritms.Text += ("Cluster " + (i + 1) + " {\n\t");
                foreach (KeyValuePair<int, Double[]> item in (Dictionary<int, double[]>)agrupamento[i])
                {
                    txtClusterAlgoritms.Text += "P" + item.Key + " {";
                    for (int j = 0; j < item.Value.GetLength(0); j++)
                    {
                        if (j < (item.Value.GetLength(0) - 1))
                        {
                            txtClusterAlgoritms.Text += string.Format("{0:0.###}", item.Value[j]) + ",   ";
                        }
                        else
                        {
                            txtClusterAlgoritms.Text += string.Format("{0:0.###}", item.Value[j]);
                        }
                    }
                    if (classe != null && item.Key != 0)
                    {
                        int indice = item.Key - 1;
                        txtClusterAlgoritms.Text += ",   " + classe[indice];
                    }
                    txtClusterAlgoritms.Text += "}\n\t";
                }
                txtClusterAlgoritms.Text += "}\n";
            }
            //  txtClusterAlgoritms.Text = cluster;*/
            //txtClusterAlgoritms.Text = "";
            /*  for (int i = 0; i < agrupamento.Count; i++)
              {
                  foreach (KeyValuePair<int, Double[]> item in (Dictionary<int, double[]>)agrupamento[i])
                  {
                      for (int j = 0; j < item.Value.GetLength(0); j++)
                      {
                          if (j < (item.Value.GetLength(0) - 1))
                          {
                              txtClusterAlgoritms.Text += item.Value[j] + ",";
                          }
                          else
                          {
                              txtClusterAlgoritms.Text += item.Value[j];
                          }
                      }
                      if (classe != null && item.Key != 0)
                      {
                          txtClusterAlgoritms.Text += "," + classe[item.Key - 1];
                      }
                      txtClusterAlgoritms.Text += "\n";
                  }
                  txtClusterAlgoritms.Text += ("Cluster" + (i + 1) + "\n");
              }*/
        }
        private void AtualizaRichTextBox(String informacao)
        {
            txtClusterAlgoritms.Text += informacao;
            txtClusterAlgoritms.SelectionStart = txtClusterAlgoritms.Text.Length;
            txtClusterAlgoritms.ScrollToCaret();
        }
        private void LiberaControles(bool action)
        {
            tabPage3.Enabled = action;
            tabPage1.Enabled = action;
            btnStart.Enabled = action;
            cmbAlgoritmos.Enabled = action;
            groupBox4.Enabled = action;
            int index = cmbAlgoritmos.SelectedIndex;
            if (index < 2 || (index > 2 && index < 5))
            {
                cmbDiametro.Enabled = action;
            }
            if (index < 3)
            {

                lblNumberClusters.Enabled = action;
                txtNumberClusters.Enabled = action;
            }
            else
            {
                grpEstimation.Enabled = action;
            }
        }
        private void BloquearDesbloquearAbas(bool action)
        {
            chkMinMax.Enabled = action;
            chkRemoveDuplicate.Enabled = action;
            if (classe != null)
            {
                chkContraditory.Enabled = action;
            }
            else
            {
                chkContraditory.Enabled = false;
            }
            tabPage2.Enabled = action;
            tabPage3.Enabled = action;
            // tabPage2.Visible = false;
            // tabControl1.TabPages.Remove(tabPage2);
            //   tabControl1.TabPages.Remove(tabPage3);

        }
        private void CarregarCmbAtributos(int colunas)
        {
            cmbPrimeiroAtributo.Items.Clear();
            cmbSegundoAtributo.Items.Clear();
            for (int i = 0; i < colunas; i++)
            {
                cmbPrimeiroAtributo.Items.Insert(i, "A" + (i + 1));
                cmbSegundoAtributo.Items.Insert(i, "A" + (i + 1));
            }
            cmbPrimeiroAtributo.SelectedIndex = 0;
            cmbSegundoAtributo.SelectedIndex = 1;


        }
        private void ControlaAnimacaoProcessamento(bool liga)
        {
            if (liga)
            {
                pictureBox.Image = Properties.Resources.Loading;
                labelProcesso.Text = "Processing ...";
            }
            else
            {
                this.pictureBox.Image = Properties.Resources.Checked;
                labelProcesso.Text = "Done";
            }
        }
        private void ControlaTab1(bool action)
        {
            if (action)
            {
                pictureBoxTab1.Image = Properties.Resources.Loading;
                labelTab1.Text = "Processing ...";
            }
            else
            {
                AtualizaLabel(linhas, colunas);
                pictureBoxTab1.Image = null;
                labelTab1.Text = "";
                chkRemoveDuplicate.Checked = false;
                chkContraditory.Checked = false;
            }
        }
        #endregion

        #region Eventos
        private void btnShowGraphic_Click(object sender, EventArgs e)
        {
            int primeiroAtributo = cmbPrimeiroAtributo.SelectedIndex;
            int segundoAtributo = cmbSegundoAtributo.SelectedIndex;
            Series serie;
            chartCartesiano.Series.Clear();
            chartCartesiano.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("chartArea");
            chartCartesiano.ChartAreas.Add(chartArea);
            for (int i = 0; i < agrupamento.Count; i++)
            {
                serie = new Series("Cluster " + (i + 1));
                serie.Legend = "Legenda";
                serie.ChartType = SeriesChartType.Point;
                serie.ChartArea = "chartArea";
                //serie.Color = Color.Black;
                serie.BorderColor = Color.Black;
                serie.MarkerSize = (int)cmbTamanhoPonto.SelectedItem;
                serie.XValueType = ChartValueType.Int32;
                foreach (KeyValuePair<int, Double[]> item in (Dictionary<int, double[]>)agrupamento[i])
                {
                    serie.Points.AddXY
                            (item.Value[primeiroAtributo], item.Value[segundoAtributo]);
                }
                chartCartesiano.Series.Add(serie);
            }

            /* chartCartesiano.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
             chartCartesiano.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
             chartCartesiano.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
             chartCartesiano.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
             chartCartesiano.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;*/
            chartCartesiano.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chartCartesiano.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            //chartCartesiano.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            //chartCartesiano.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            // chartCartesiano.ChartAreas[0].AxisX.Interval = 1;
            /* if (chartCartesiano.ChartAreas[0].AxisX.Minimum > chartCartesiano.ChartAreas[0].AxisY.Minimum)
             {
                 chartCartesiano.ChartAreas[0].AxisX.Minimum = chartCartesiano.ChartAreas[0].AxisY.Minimum;
             }
             else
             {
                 chartCartesiano.ChartAreas[0].AxisY.Minimum = chartCartesiano.ChartAreas[0].AxisX.Minimum;
             }
             if (chartCartesiano.ChartAreas[0].AxisX.Maximum > chartCartesiano.ChartAreas[0].AxisY.Maximum)
             {
                 chartCartesiano.ChartAreas[0].AxisY.Maximum = chartCartesiano.ChartAreas[0].AxisX.Maximum;
             }
             else
             {
                 chartCartesiano.ChartAreas[0].AxisX.Maximum = chartCartesiano.ChartAreas[0].AxisY.Maximum;
             }*/
            // chartCartesiano.ChartAreas[0].AxisX.Minimum = 0;
            //chartCartesiano.ChartAreas[0].AxisY.Maximum = 3;
        }
        private void chkMinMax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMinMax.Checked)
            {
                if (padroes2 == null)
                {
                    padroes2 = (double[,])padroes.Clone();
                    ControlaTab1(true);
                    BloquearDesbloquearAbas(false);
                    ThreadMinMax.RunWorkerAsync();

                }
                else
                {
                    double[,] padroes3 = new double[linhas, colunas];
                    padroes3 = (double[,])padroes.Clone();
                    padroes = (double[,])padroes2.Clone();
                    padroes2 = (double[,])padroes3.Clone();
                    AtualizaGrid(padroes, Grid);
                    AtualizaGrid(padroes, Grid2);
                    AtualizaAgrupamento();
                }

            }
            else
            {
                if (padroes2 != null)
                {
                    double[,] padroes3 = new double[linhas, colunas];
                    padroes3 = (double[,])padroes.Clone();
                    padroes = (double[,])padroes2.Clone();
                    padroes2 = (double[,])padroes3.Clone();
                    AtualizaGrid(padroes, Grid);
                    AtualizaGrid(padroes, Grid2);
                    AtualizaAgrupamento();
                }
            }

        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog abreArquivo = new OpenFileDialog();
                abreArquivo.ShowDialog();
                string arquivo = abreArquivo.FileName;
                classe = null;
                AbreArquivo(arquivo);
                LiberaDivCluster();
            }
            catch (Exception)
            {


            }
        }
        private void cmbAlgoritmos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbAlgoritmos.SelectedIndex;
            if (index < 2 || index == 3 || index == 4)
            {
                LiberarCmbDiametro(true);
            }
            else
            {
                LiberarCmbDiametro(false);
            }
            if (index < 3)
            {
                LiberarELimparCamposCluster(false);
            }
            else {
                LiberarELimparCamposCluster(true);
            };
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                int algoritmo = cmbAlgoritmos.SelectedIndex;
                if (algoritmo > -1)
                {
                    ControlaAnimacaoProcessamento(true);
                    LiberaControles(false);
                    valorIndice = "";
                    indiceDiametro = cmbDiametro.SelectedIndex;
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                    if (algoritmo < 3)
                    {
                        if (int.Parse(txtNumberClusters.Text) > 0 && int.Parse(txtNumberClusters.Text) <= linhas)
                        {
                            ThreadAlgoritmos.RunWorkerAsync(algoritmo);
                        }
                        else
                        {
                            ResetaTabPage2();
                            MessageBox.Show("Enter a value between 1 and " + linhas, "Error");
                        }
                    }

                    else
                    {
                        if (double.Parse(txtJumpsThreshold.Text) > 0 && int.Parse(txtNumberRunningThreshold.Text) > 0)
                        {
                            if (algoritmo == 6)
                            {
                                groupBox4.Enabled = false;
                                ThreadEstimacao.RunWorkerAsync();
                            }
                            else
                            {
                                ThreadAlgoritmosEstimacao.RunWorkerAsync(algoritmo);
                            }
                        }
                        else
                        {
                            ResetaTabPage2();
                            MessageBox.Show("Enter a value more than 0", "Error");
                        }
                    }
                }
                else
                {
                    ResetaTabPage2();
                    MessageBox.Show("Select an algorithm", "Error");
                }

            }
            catch (Exception)
            {
                ResetaTabPage2();
                MessageBox.Show("Enter a value", "Error");
            }
        }
        private void txtJumpsThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void txtNumberRunningThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void txtNumberClusters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void btnGeraDados_Click(object sender, EventArgs e)
        {
            Form2 geradorDados = new Form2(this);
            geradorDados.Show();
        }
        private void chkRemoveDuplicate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemoveDuplicate.Checked)
            {
                ControlaTab1(true);
                BloquearDesbloquearAbas(false);
                ThreadRemoveDuplicate.RunWorkerAsync();
            }
        }
        private void chkContraditory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContraditory.Checked)
            {
                ControlaTab1(true);
                BloquearDesbloquearAbas(false);
                ThreadContraditory.RunWorkerAsync();
            }
        }
        private void chkDunn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDunn.Checked)
            {
                chkDunn.Checked = false;
                ControlaAnimacaoProcessamento(true);
                LiberaControles(false);
                ThreadDunn.RunWorkerAsync();
            }
        }
        private void chkSilhouette_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSilhouette.Checked)
            {
                chkSilhouette.Checked = false;
                ControlaAnimacaoProcessamento(true);
                LiberaControles(false);
                ThreadSilhouette.RunWorkerAsync();
            }

        }
        private void chkRand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRand.Checked)
            {
                chkRand.Checked = false;
                ControlaAnimacaoProcessamento(true);
                LiberaControles(false);
                ThreadRandStatistic.RunWorkerAsync();
            }
        }

        #endregion

        #region Threads
        private void ThreadRemoveDuplicate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (classe != null)
            {
                VerificaDuplicados verifica = new VerificaDuplicados(padroes, classe);
                verifica.Controle(out padroes, out classe);
            }
            else
            {
                VerificaDuplicados verifica = new VerificaDuplicados(padroes, classe);
                padroes = verifica.Controle();
            }
        }
        private void ThreadRemoveDuplicate_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (linhas != padroes.GetLength(0))
            {
                linhas = padroes.GetLength(0);
                padroes2 = null;
            }
            AtualizaGrid(padroes, Grid);
            AtualizaGrid(padroes, Grid2);
            AtualizaAgrupamento();
            ControlaTab1(false);
            BloquearDesbloquearAbas(true);
        }
        private void ThreadRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ResultadoAgrupamento();
            LiberaIndiceValidacao();
            FinalizaProcessamento();
        }
        private void ThreadAlgoritmos_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int algoritmo = (int)e.Argument;

            if (algoritmo == 0)
            {
                DIANA diana = new DIANA(padroes, int.Parse(txtNumberClusters.Text), indiceDiametro);
                agrupamento = diana.Agrupa();
            }
            else if (algoritmo == 2)
            {
                KMeans KMeans = new KMeans(padroes, int.Parse(txtNumberClusters.Text));
                agrupamento = KMeans.Agrupa();
            }
            else
            {
                DIANACentroide diana = new DIANACentroide(padroes, int.Parse(txtNumberClusters.Text), indiceDiametro);
                agrupamento = diana.Agrupa();
            }

        }
        private void ThreadAlgoritmosEstimacao_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int algoritmo = (int)e.Argument;
            double[,] padroesCopia = (double[,])padroes.Clone();
            EstimaGrupos estimaGrupos = new EstimaGrupos(padroesCopia, double.Parse(txtJumpsThreshold.Text, CultureInfo.InvariantCulture), int.Parse(txtNumberRunningThreshold.Text));
            int numeroGrupos = estimaGrupos.Controle();
            if (algoritmo == 3 && numeroGrupos > 0)
            {
                DIANA diana = new DIANA(padroes, numeroGrupos, indiceDiametro);
                agrupamento = diana.Agrupa();
            }
            else if (algoritmo == 5 && numeroGrupos > 0)
            {
                KMeans kMeans = new KMeans(padroes, numeroGrupos);
                agrupamento = kMeans.Agrupa();
            }
            else if (algoritmo == 4 && numeroGrupos > 0)
            {
                DIANACentroide diana = new DIANACentroide(padroes, numeroGrupos, indiceDiametro);
                agrupamento = diana.Agrupa();
            }
            else
            {
                MessageBox.Show("Nember of Clusters = " + numeroGrupos, "Error");
            }

        }
        private void ThreadRandStatistic_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            RandStatistic externa = new RandStatistic(classe, agrupamento);
            double indiceExterno = externa.CalculaRand();
            valorIndice = "\nRand Statistic = " + string.Format("{0:0.###}", indiceExterno);
        }
        private void ThreadDunn_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dunn dunn = new Dunn(padroes, agrupamento);
            double indiceDunn = dunn.CalculaIndice();
            //valorIndice += "\nDunn Validation = " + string.Format("{0:0.###}", indiceDunn);
            valorIndice = "\nDunn Validation = " + string.Format("{0:0.##}", indiceDunn);
        }
        private void ThreadDunn_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            AtualizaRichTextBox(valorIndice);
            FinalizaProcessamento();
        }
        private void ThreadRandStatistic_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            AtualizaRichTextBox(valorIndice);
            FinalizaProcessamento();
        }
        private void ThreadMinMax_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Normalization normalizacao = new Normalization();
            padroes = normalizacao.MinMax(padroes);
        }
        private void ThreadMinMax_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            AtualizaGrid(padroes, Grid);
            AtualizaGrid(padroes, Grid2);
            AtualizaAgrupamento();
            ControlaTab1(false);
            BloquearDesbloquearAbas(true);
        }
        private void ThreadContraditory_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            VerificaContraditorios contraditorios = new VerificaContraditorios(padroes, classe);
            contraditorios.Controle(out padroes, out classe);
        }
        private void ThreadEstimacao_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double[,] padroesCopia = (double[,])padroes.Clone();
            EstimaGrupos3 estima = new EstimaGrupos3(padroesCopia, double.Parse(txtJumpsThreshold.Text, CultureInfo.InvariantCulture), int.Parse(txtNumberRunningThreshold.Text));
            numeroGrupos = estima.Controle();
        }
        private void ThreadEstimacao_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            GraficoGrupos grafico = new GraficoGrupos(numeroGrupos);
            grafico.Show();
            ControlaAnimacaoProcessamento(false);
            LiberaControles(true);
        }
        private void ThreadSilhouette_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Silhouette silhouette = new Silhouette(padroes, agrupamento);
            double indiceSilhouette = silhouette.CalculaIndice();
            //valorIndice += "\nSilhouette Validation = " + string.Format("{0:0.###}", indiceSilhouette);
            valorIndice = "\nSilhouette Validation = " + string.Format("{0:0.##}", indiceSilhouette);
        }
        private void ThreadSilhouette_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            AtualizaRichTextBox(valorIndice);
            FinalizaProcessamento();
        }

        #endregion

    }
}
