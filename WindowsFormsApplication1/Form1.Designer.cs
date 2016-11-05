namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelTab1 = new System.Windows.Forms.Label();
            this.pictureBoxTab1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkContraditory = new System.Windows.Forms.CheckBox();
            this.chkRemoveDuplicate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.attributeValue = new System.Windows.Forms.Label();
            this.lblInstances = new System.Windows.Forms.Label();
            this.lblAttributes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMinMax = new System.Windows.Forms.CheckBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.btnGeraDados = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbDiametro = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkSilhouette = new System.Windows.Forms.CheckBox();
            this.chkRand = new System.Windows.Forms.CheckBox();
            this.chkDunn = new System.Windows.Forms.CheckBox();
            this.labelProcesso = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtClusterAlgoritms = new System.Windows.Forms.RichTextBox();
            this.grpEstimation = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumberRunningThreshold = new System.Windows.Forms.TextBox();
            this.txtJumpsThreshold = new System.Windows.Forms.TextBox();
            this.lblNumberClusters = new System.Windows.Forms.Label();
            this.txtNumberClusters = new System.Windows.Forms.TextBox();
            this.cmbAlgoritmos = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbPrimeiroAtributo = new System.Windows.Forms.ComboBox();
            this.cmbSegundoAtributo = new System.Windows.Forms.ComboBox();
            this.cmbTamanhoPonto = new System.Windows.Forms.ComboBox();
            this.chartCartesiano = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnShowGraphic = new System.Windows.Forms.Button();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.ThreadAlgoritmos = new System.ComponentModel.BackgroundWorker();
            this.ThreadAlgoritmosEstimacao = new System.ComponentModel.BackgroundWorker();
            this.ThreadDunn = new System.ComponentModel.BackgroundWorker();
            this.ThreadRandStatistic = new System.ComponentModel.BackgroundWorker();
            this.ThreadRemoveDuplicate = new System.ComponentModel.BackgroundWorker();
            this.ThreadMinMax = new System.ComponentModel.BackgroundWorker();
            this.ThreadContraditory = new System.ComponentModel.BackgroundWorker();
            this.ThreadEstimacao = new System.ComponentModel.BackgroundWorker();
            this.ThreadSilhouette = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTab1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.grpEstimation.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCartesiano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 501);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.labelTab1);
            this.tabPage1.Controls.Add(this.pictureBoxTab1);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.Grid);
            this.tabPage1.Controls.Add(this.btnGeraDados);
            this.tabPage1.Controls.Add(this.openFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(935, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Archive";
            // 
            // labelTab1
            // 
            this.labelTab1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTab1.AutoSize = true;
            this.labelTab1.Location = new System.Drawing.Point(723, 446);
            this.labelTab1.Name = "labelTab1";
            this.labelTab1.Size = new System.Drawing.Size(0, 17);
            this.labelTab1.TabIndex = 6;
            // 
            // pictureBoxTab1
            // 
            this.pictureBoxTab1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxTab1.Location = new System.Drawing.Point(748, 415);
            this.pictureBoxTab1.Name = "pictureBoxTab1";
            this.pictureBoxTab1.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxTab1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTab1.TabIndex = 7;
            this.pictureBoxTab1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox5.Controls.Add(this.chkContraditory);
            this.groupBox5.Controls.Add(this.chkRemoveDuplicate);
            this.groupBox5.Location = new System.Drawing.Point(658, 160);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 80);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preprocess";
            // 
            // chkContraditory
            // 
            this.chkContraditory.AutoSize = true;
            this.chkContraditory.Location = new System.Drawing.Point(23, 21);
            this.chkContraditory.Name = "chkContraditory";
            this.chkContraditory.Size = new System.Drawing.Size(227, 21);
            this.chkContraditory.TabIndex = 0;
            this.chkContraditory.Text = "Remove Contradictory Patterns";
            this.chkContraditory.UseVisualStyleBackColor = true;
            this.chkContraditory.CheckedChanged += new System.EventHandler(this.chkContraditory_CheckedChanged);
            // 
            // chkRemoveDuplicate
            // 
            this.chkRemoveDuplicate.AutoSize = true;
            this.chkRemoveDuplicate.Enabled = false;
            this.chkRemoveDuplicate.Location = new System.Drawing.Point(23, 48);
            this.chkRemoveDuplicate.Name = "chkRemoveDuplicate";
            this.chkRemoveDuplicate.Size = new System.Drawing.Size(208, 21);
            this.chkRemoveDuplicate.TabIndex = 1;
            this.chkRemoveDuplicate.Text = "Remove Repeating Patterns";
            this.chkRemoveDuplicate.UseVisualStyleBackColor = true;
            this.chkRemoveDuplicate.CheckedChanged += new System.EventHandler(this.chkRemoveDuplicate_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.attributeValue);
            this.groupBox2.Controls.Add(this.lblInstances);
            this.groupBox2.Controls.Add(this.lblAttributes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(658, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 97);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // attributeValue
            // 
            this.attributeValue.AutoSize = true;
            this.attributeValue.Location = new System.Drawing.Point(98, 67);
            this.attributeValue.Name = "attributeValue";
            this.attributeValue.Size = new System.Drawing.Size(0, 17);
            this.attributeValue.TabIndex = 3;
            // 
            // lblInstances
            // 
            this.lblInstances.AutoSize = true;
            this.lblInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstances.Location = new System.Drawing.Point(98, 18);
            this.lblInstances.Name = "lblInstances";
            this.lblInstances.Size = new System.Drawing.Size(13, 17);
            this.lblInstances.TabIndex = 1;
            this.lblInstances.Text = " ";
            // 
            // lblAttributes
            // 
            this.lblAttributes.AutoSize = true;
            this.lblAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributes.Location = new System.Drawing.Point(98, 67);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(13, 17);
            this.lblAttributes.TabIndex = 1;
            this.lblAttributes.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Attributes:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patterns:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.chkMinMax);
            this.groupBox1.Location = new System.Drawing.Point(658, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 60);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Normalization";
            // 
            // chkMinMax
            // 
            this.chkMinMax.AutoSize = true;
            this.chkMinMax.Location = new System.Drawing.Point(23, 22);
            this.chkMinMax.Name = "chkMinMax";
            this.chkMinMax.Size = new System.Drawing.Size(81, 21);
            this.chkMinMax.TabIndex = 0;
            this.chkMinMax.Text = "Min Max";
            this.chkMinMax.UseVisualStyleBackColor = true;
            this.chkMinMax.CheckedChanged += new System.EventHandler(this.chkMinMax_CheckedChanged);
            // 
            // Grid
            // 
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid.CausesValidation = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid.EnableHeadersVisualStyles = false;
            this.Grid.Location = new System.Drawing.Point(7, 46);
            this.Grid.Name = "Grid";
            this.Grid.RowTemplate.Height = 24;
            this.Grid.Size = new System.Drawing.Size(615, 417);
            this.Grid.TabIndex = 5;
            // 
            // btnGeraDados
            // 
            this.btnGeraDados.BackColor = System.Drawing.Color.White;
            this.btnGeraDados.Location = new System.Drawing.Point(108, 6);
            this.btnGeraDados.Name = "btnGeraDados";
            this.btnGeraDados.Size = new System.Drawing.Size(131, 34);
            this.btnGeraDados.TabIndex = 1;
            this.btnGeraDados.Text = "Generate Data";
            this.btnGeraDados.UseVisualStyleBackColor = false;
            this.btnGeraDados.Click += new System.EventHandler(this.btnGeraDados_Click);
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.Color.White;
            this.openFile.Location = new System.Drawing.Point(7, 6);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(95, 34);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open File";
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.cmbDiametro);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.labelProcesso);
            this.tabPage2.Controls.Add(this.pictureBox);
            this.tabPage2.Controls.Add(this.btnStart);
            this.tabPage2.Controls.Add(this.txtClusterAlgoritms);
            this.tabPage2.Controls.Add(this.grpEstimation);
            this.tabPage2.Controls.Add(this.lblNumberClusters);
            this.tabPage2.Controls.Add(this.txtNumberClusters);
            this.tabPage2.Controls.Add(this.cmbAlgoritmos);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(935, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cluster Algorithms";
            // 
            // cmbDiametro
            // 
            this.cmbDiametro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiametro.Enabled = false;
            this.cmbDiametro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDiametro.Location = new System.Drawing.Point(8, 54);
            this.cmbDiametro.Name = "cmbDiametro";
            this.cmbDiametro.Size = new System.Drawing.Size(152, 24);
            this.cmbDiametro.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkSilhouette);
            this.groupBox4.Controls.Add(this.chkRand);
            this.groupBox4.Controls.Add(this.chkDunn);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(8, 229);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 104);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Validation";
            // 
            // chkSilhouette
            // 
            this.chkSilhouette.AutoSize = true;
            this.chkSilhouette.Location = new System.Drawing.Point(6, 48);
            this.chkSilhouette.Name = "chkSilhouette";
            this.chkSilhouette.Size = new System.Drawing.Size(220, 21);
            this.chkSilhouette.TabIndex = 2;
            this.chkSilhouette.Text = "Silhouette Validation (Internal)";
            this.chkSilhouette.UseVisualStyleBackColor = true;
            this.chkSilhouette.CheckedChanged += new System.EventHandler(this.chkSilhouette_CheckedChanged);
            // 
            // chkRand
            // 
            this.chkRand.AutoSize = true;
            this.chkRand.Location = new System.Drawing.Point(6, 75);
            this.chkRand.Name = "chkRand";
            this.chkRand.Size = new System.Drawing.Size(195, 21);
            this.chkRand.TabIndex = 1;
            this.chkRand.Text = "Rand Validation (External)";
            this.chkRand.UseVisualStyleBackColor = true;
            this.chkRand.CheckedChanged += new System.EventHandler(this.chkRand_CheckedChanged);
            // 
            // chkDunn
            // 
            this.chkDunn.AutoSize = true;
            this.chkDunn.Location = new System.Drawing.Point(6, 21);
            this.chkDunn.Name = "chkDunn";
            this.chkDunn.Size = new System.Drawing.Size(191, 21);
            this.chkDunn.TabIndex = 0;
            this.chkDunn.Text = "Dunn Validation (Internal)";
            this.chkDunn.UseVisualStyleBackColor = true;
            this.chkDunn.CheckedChanged += new System.EventHandler(this.chkDunn_CheckedChanged);
            // 
            // labelProcesso
            // 
            this.labelProcesso.AutoSize = true;
            this.labelProcesso.Location = new System.Drawing.Point(130, 431);
            this.labelProcesso.Name = "labelProcesso";
            this.labelProcesso.Size = new System.Drawing.Size(0, 17);
            this.labelProcesso.TabIndex = 8;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(74, 416);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(78, 352);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 40);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtClusterAlgoritms
            // 
            this.txtClusterAlgoritms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClusterAlgoritms.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtClusterAlgoritms.Location = new System.Drawing.Point(502, 7);
            this.txtClusterAlgoritms.Name = "txtClusterAlgoritms";
            this.txtClusterAlgoritms.ReadOnly = true;
            this.txtClusterAlgoritms.Size = new System.Drawing.Size(411, 455);
            this.txtClusterAlgoritms.TabIndex = 7;
            this.txtClusterAlgoritms.Text = "";
            this.txtClusterAlgoritms.WordWrap = false;
            // 
            // grpEstimation
            // 
            this.grpEstimation.Controls.Add(this.label5);
            this.grpEstimation.Controls.Add(this.label4);
            this.grpEstimation.Controls.Add(this.txtNumberRunningThreshold);
            this.grpEstimation.Controls.Add(this.txtJumpsThreshold);
            this.grpEstimation.Enabled = false;
            this.grpEstimation.Location = new System.Drawing.Point(8, 136);
            this.grpEstimation.Name = "grpEstimation";
            this.grpEstimation.Size = new System.Drawing.Size(314, 87);
            this.grpEstimation.TabIndex = 4;
            this.grpEstimation.TabStop = false;
            this.grpEstimation.Text = "Estimation of the Number of Clusters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Number of Runnings for Each Threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Jump Threshold";
            // 
            // txtNumberRunningThreshold
            // 
            this.txtNumberRunningThreshold.Location = new System.Drawing.Point(7, 53);
            this.txtNumberRunningThreshold.Name = "txtNumberRunningThreshold";
            this.txtNumberRunningThreshold.Size = new System.Drawing.Size(37, 22);
            this.txtNumberRunningThreshold.TabIndex = 2;
            this.txtNumberRunningThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberRunningThreshold_KeyPress);
            // 
            // txtJumpsThreshold
            // 
            this.txtJumpsThreshold.Location = new System.Drawing.Point(7, 22);
            this.txtJumpsThreshold.Name = "txtJumpsThreshold";
            this.txtJumpsThreshold.Size = new System.Drawing.Size(37, 22);
            this.txtJumpsThreshold.TabIndex = 0;
            this.txtJumpsThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJumpsThreshold_KeyPress);
            // 
            // lblNumberClusters
            // 
            this.lblNumberClusters.AutoSize = true;
            this.lblNumberClusters.Enabled = false;
            this.lblNumberClusters.Location = new System.Drawing.Point(65, 98);
            this.lblNumberClusters.Name = "lblNumberClusters";
            this.lblNumberClusters.Size = new System.Drawing.Size(129, 17);
            this.lblNumberClusters.TabIndex = 3;
            this.lblNumberClusters.Text = "Number of Clusters";
            // 
            // txtNumberClusters
            // 
            this.txtNumberClusters.Enabled = false;
            this.txtNumberClusters.Location = new System.Drawing.Point(15, 95);
            this.txtNumberClusters.Name = "txtNumberClusters";
            this.txtNumberClusters.Size = new System.Drawing.Size(44, 22);
            this.txtNumberClusters.TabIndex = 2;
            this.txtNumberClusters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberClusters_KeyPress);
            // 
            // cmbAlgoritmos
            // 
            this.cmbAlgoritmos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAlgoritmos.Location = new System.Drawing.Point(8, 7);
            this.cmbAlgoritmos.Name = "cmbAlgoritmos";
            this.cmbAlgoritmos.Size = new System.Drawing.Size(289, 24);
            this.cmbAlgoritmos.TabIndex = 0;
            this.cmbAlgoritmos.SelectedIndexChanged += new System.EventHandler(this.cmbAlgoritmos_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.cmbTamanhoPonto);
            this.tabPage3.Controls.Add(this.chartCartesiano);
            this.tabPage3.Controls.Add(this.btnShowGraphic);
            this.tabPage3.Controls.Add(this.Grid2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(935, 472);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Graphic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Point Size";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbPrimeiroAtributo);
            this.groupBox3.Controls.Add(this.cmbSegundoAtributo);
            this.groupBox3.Location = new System.Drawing.Point(9, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(90, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attributes";
            // 
            // cmbPrimeiroAtributo
            // 
            this.cmbPrimeiroAtributo.FormattingEnabled = true;
            this.cmbPrimeiroAtributo.Location = new System.Drawing.Point(6, 21);
            this.cmbPrimeiroAtributo.Name = "cmbPrimeiroAtributo";
            this.cmbPrimeiroAtributo.Size = new System.Drawing.Size(73, 24);
            this.cmbPrimeiroAtributo.TabIndex = 0;
            // 
            // cmbSegundoAtributo
            // 
            this.cmbSegundoAtributo.FormattingEnabled = true;
            this.cmbSegundoAtributo.Location = new System.Drawing.Point(6, 61);
            this.cmbSegundoAtributo.Name = "cmbSegundoAtributo";
            this.cmbSegundoAtributo.Size = new System.Drawing.Size(72, 24);
            this.cmbSegundoAtributo.TabIndex = 1;
            // 
            // cmbTamanhoPonto
            // 
            this.cmbTamanhoPonto.FormattingEnabled = true;
            this.cmbTamanhoPonto.Location = new System.Drawing.Point(25, 158);
            this.cmbTamanhoPonto.Name = "cmbTamanhoPonto";
            this.cmbTamanhoPonto.Size = new System.Drawing.Size(45, 24);
            this.cmbTamanhoPonto.TabIndex = 2;
            // 
            // chartCartesiano
            // 
            this.chartCartesiano.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            legend1.Name = "Legenda";
            this.chartCartesiano.Legends.Add(legend1);
            this.chartCartesiano.Location = new System.Drawing.Point(105, 6);
            this.chartCartesiano.Name = "chartCartesiano";
            this.chartCartesiano.Size = new System.Drawing.Size(585, 456);
            this.chartCartesiano.TabIndex = 4;
            this.chartCartesiano.Text = "chart1";
            // 
            // btnShowGraphic
            // 
            this.btnShowGraphic.BackColor = System.Drawing.Color.White;
            this.btnShowGraphic.Location = new System.Drawing.Point(15, 249);
            this.btnShowGraphic.Name = "btnShowGraphic";
            this.btnShowGraphic.Size = new System.Drawing.Size(72, 29);
            this.btnShowGraphic.TabIndex = 3;
            this.btnShowGraphic.Text = "Plot";
            this.btnShowGraphic.UseVisualStyleBackColor = false;
            this.btnShowGraphic.Click += new System.EventHandler(this.btnShowGraphic_Click);
            // 
            // Grid2
            // 
            this.Grid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.EnableHeadersVisualStyles = false;
            this.Grid2.Location = new System.Drawing.Point(696, 6);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowTemplate.Height = 24;
            this.Grid2.Size = new System.Drawing.Size(229, 456);
            this.Grid2.TabIndex = 5;
            // 
            // ThreadAlgoritmos
            // 
            this.ThreadAlgoritmos.WorkerSupportsCancellation = true;
            this.ThreadAlgoritmos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadAlgoritmos_DoWork);
            this.ThreadAlgoritmos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadRunWorkerCompleted);
            // 
            // ThreadAlgoritmosEstimacao
            // 
            this.ThreadAlgoritmosEstimacao.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadAlgoritmosEstimacao_DoWork);
            this.ThreadAlgoritmosEstimacao.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadRunWorkerCompleted);
            // 
            // ThreadDunn
            // 
            this.ThreadDunn.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadDunn_DoWork);
            this.ThreadDunn.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadDunn_RunWorkerCompleted);
            // 
            // ThreadRandStatistic
            // 
            this.ThreadRandStatistic.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadRandStatistic_DoWork);
            this.ThreadRandStatistic.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadRandStatistic_RunWorkerCompleted);
            // 
            // ThreadRemoveDuplicate
            // 
            this.ThreadRemoveDuplicate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadRemoveDuplicate_DoWork);
            this.ThreadRemoveDuplicate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadRemoveDuplicate_RunWorkerCompleted);
            // 
            // ThreadMinMax
            // 
            this.ThreadMinMax.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadMinMax_DoWork);
            this.ThreadMinMax.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadMinMax_RunWorkerCompleted);
            // 
            // ThreadContraditory
            // 
            this.ThreadContraditory.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadContraditory_DoWork);
            this.ThreadContraditory.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadRemoveDuplicate_RunWorkerCompleted);
            // 
            // ThreadEstimacao
            // 
            this.ThreadEstimacao.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadEstimacao_DoWork);
            this.ThreadEstimacao.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadEstimacao_RunWorkerCompleted);
            // 
            // ThreadSilhouette
            // 
            this.ThreadSilhouette.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ThreadSilhouette_DoWork);
            this.ThreadSilhouette.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ThreadSilhouette_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 500);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DivCluster";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTab1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.grpEstimation.ResumeLayout(false);
            this.grpEstimation.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCartesiano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnGeraDados;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpEstimation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumberRunningThreshold;
        private System.Windows.Forms.TextBox txtJumpsThreshold;
        private System.Windows.Forms.Label lblNumberClusters;
        private System.Windows.Forms.TextBox txtNumberClusters;
        private System.Windows.Forms.ComboBox cmbAlgoritmos;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnShowGraphic;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.ComboBox cmbSegundoAtributo;
        private System.Windows.Forms.ComboBox cmbPrimeiroAtributo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label attributeValue;
        private System.Windows.Forms.Label lblAttributes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInstances;
        private System.Windows.Forms.RichTextBox txtClusterAlgoritms;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.CheckBox chkMinMax;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCartesiano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbTamanhoPonto;
        private System.Windows.Forms.CheckBox chkDunn;
        private System.ComponentModel.BackgroundWorker ThreadAlgoritmos;
        private System.ComponentModel.BackgroundWorker ThreadAlgoritmosEstimacao;
        private System.ComponentModel.BackgroundWorker ThreadDunn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelProcesso;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkRand;
        private System.ComponentModel.BackgroundWorker ThreadRandStatistic;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkRemoveDuplicate;
        private System.ComponentModel.BackgroundWorker ThreadRemoveDuplicate;
        private System.Windows.Forms.PictureBox pictureBoxTab1;
        private System.Windows.Forms.Label labelTab1;
        private System.ComponentModel.BackgroundWorker ThreadMinMax;
        private System.Windows.Forms.CheckBox chkContraditory;
        private System.ComponentModel.BackgroundWorker ThreadContraditory;
        private System.Windows.Forms.ComboBox cmbDiametro;
        private System.ComponentModel.BackgroundWorker ThreadEstimacao;
        private System.Windows.Forms.CheckBox chkSilhouette;
        private System.ComponentModel.BackgroundWorker ThreadSilhouette;
    }
}

