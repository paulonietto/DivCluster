namespace WindowsFormsApplication1
{
    partial class GraficoGrupos
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
            this.chartGrupos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMenorLimiar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMaiorLimiar = new System.Windows.Forms.ComboBox();
            this.btnGeraGrafico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrupos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartGrupos
            // 
            this.chartGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartGrupos.Location = new System.Drawing.Point(171, 12);
            this.chartGrupos.Name = "chartGrupos";
            this.chartGrupos.Size = new System.Drawing.Size(540, 441);
            this.chartGrupos.TabIndex = 0;
            this.chartGrupos.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMaiorLimiar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbMenorLimiar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 188);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thresholds";
            // 
            // cmbMenorLimiar
            // 
            this.cmbMenorLimiar.FormattingEnabled = true;
            this.cmbMenorLimiar.Location = new System.Drawing.Point(15, 54);
            this.cmbMenorLimiar.Name = "cmbMenorLimiar";
            this.cmbMenorLimiar.Size = new System.Drawing.Size(121, 24);
            this.cmbMenorLimiar.TabIndex = 0;
            this.cmbMenorLimiar.SelectionChangeCommitted += new System.EventHandler(this.cmbMenorLimiar_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minimum Threshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum Threshold";
            // 
            // cmbMaiorLimiar
            // 
            this.cmbMaiorLimiar.FormattingEnabled = true;
            this.cmbMaiorLimiar.Location = new System.Drawing.Point(15, 134);
            this.cmbMaiorLimiar.Name = "cmbMaiorLimiar";
            this.cmbMaiorLimiar.Size = new System.Drawing.Size(121, 24);
            this.cmbMaiorLimiar.TabIndex = 3;
            // 
            // btnGeraGrafico
            // 
            this.btnGeraGrafico.Location = new System.Drawing.Point(46, 248);
            this.btnGeraGrafico.Name = "btnGeraGrafico";
            this.btnGeraGrafico.Size = new System.Drawing.Size(75, 23);
            this.btnGeraGrafico.TabIndex = 2;
            this.btnGeraGrafico.Text = "Plot";
            this.btnGeraGrafico.UseVisualStyleBackColor = true;
            this.btnGeraGrafico.Click += new System.EventHandler(this.btnGeraGrafico_Click);
            // 
            // GraficoGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 465);
            this.Controls.Add(this.btnGeraGrafico);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartGrupos);
            this.Name = "GraficoGrupos";
            this.Text = "Estimation of the Number of Clusters";
            ((System.ComponentModel.ISupportInitialize)(this.chartGrupos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGrupos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMaiorLimiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMenorLimiar;
        private System.Windows.Forms.Button btnGeraGrafico;
    }
}