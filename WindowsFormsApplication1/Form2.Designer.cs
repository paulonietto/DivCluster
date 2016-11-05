namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.txtQuantidadeGrupos = new System.Windows.Forms.TextBox();
            this.txtDados = new System.Windows.Forms.RichTextBox();
            this.chartVisualizaDados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGerarDados = new System.Windows.Forms.Button();
            this.btnSalvarArquivo = new System.Windows.Forms.Button();
            this.gridDados = new System.Windows.Forms.DataGridView();
            this.btnGeraGrupos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioCirculo = new System.Windows.Forms.RadioButton();
            this.radioQuadrado = new System.Windows.Forms.RadioButton();
            this.groupBoxShape = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartVisualizaDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxShape.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQuantidadeGrupos
            // 
            this.txtQuantidadeGrupos.Location = new System.Drawing.Point(6, 21);
            this.txtQuantidadeGrupos.Name = "txtQuantidadeGrupos";
            this.txtQuantidadeGrupos.Size = new System.Drawing.Size(37, 22);
            this.txtQuantidadeGrupos.TabIndex = 0;
            this.txtQuantidadeGrupos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidadeGrupos_KeyPress);
            // 
            // txtDados
            // 
            this.txtDados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDados.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDados.Location = new System.Drawing.Point(373, 2);
            this.txtDados.Name = "txtDados";
            this.txtDados.ReadOnly = true;
            this.txtDados.Size = new System.Drawing.Size(154, 381);
            this.txtDados.TabIndex = 4;
            this.txtDados.Text = "";
            this.txtDados.WordWrap = false;
            // 
            // chartVisualizaDados
            // 
            this.chartVisualizaDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartVisualizaDados.Location = new System.Drawing.Point(533, 2);
            this.chartVisualizaDados.Name = "chartVisualizaDados";
            this.chartVisualizaDados.Size = new System.Drawing.Size(422, 417);
            this.chartVisualizaDados.TabIndex = 5;
            this.chartVisualizaDados.Text = "chart1";
            // 
            // btnGerarDados
            // 
            this.btnGerarDados.Location = new System.Drawing.Point(112, 390);
            this.btnGerarDados.Name = "btnGerarDados";
            this.btnGerarDados.Size = new System.Drawing.Size(116, 31);
            this.btnGerarDados.TabIndex = 6;
            this.btnGerarDados.Text = "Generate Data";
            this.btnGerarDados.UseVisualStyleBackColor = true;
            this.btnGerarDados.Click += new System.EventHandler(this.btnGerarDados_Click);
            // 
            // btnSalvarArquivo
            // 
            this.btnSalvarArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalvarArquivo.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.save;
            this.btnSalvarArquivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvarArquivo.Location = new System.Drawing.Point(388, 390);
            this.btnSalvarArquivo.Name = "btnSalvarArquivo";
            this.btnSalvarArquivo.Size = new System.Drawing.Size(119, 29);
            this.btnSalvarArquivo.TabIndex = 7;
            this.btnSalvarArquivo.Text = "     Save to File";
            this.btnSalvarArquivo.UseVisualStyleBackColor = true;
            this.btnSalvarArquivo.Click += new System.EventHandler(this.btnSalvarArquivo_Click);
            // 
            // gridDados
            // 
            this.gridDados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gridDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDados.EnableHeadersVisualStyles = false;
            this.gridDados.Location = new System.Drawing.Point(4, 186);
            this.gridDados.Name = "gridDados";
            this.gridDados.RowTemplate.Height = 24;
            this.gridDados.Size = new System.Drawing.Size(363, 198);
            this.gridDados.TabIndex = 8;
            this.gridDados.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDados_EditingControlShowing);
            // 
            // btnGeraGrupos
            // 
            this.btnGeraGrupos.Location = new System.Drawing.Point(43, 49);
            this.btnGeraGrupos.Name = "btnGeraGrupos";
            this.btnGeraGrupos.Size = new System.Drawing.Size(111, 25);
            this.btnGeraGrupos.TabIndex = 9;
            this.btnGeraGrupos.Text = "Generate Grid";
            this.btnGeraGrupos.UseVisualStyleBackColor = true;
            this.btnGeraGrupos.Click += new System.EventHandler(this.btnGeraGrupos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQuantidadeGrupos);
            this.groupBox1.Controls.Add(this.btnGeraGrupos);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 91);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Number of Clusters";
            // 
            // radioCirculo
            // 
            this.radioCirculo.AutoSize = true;
            this.radioCirculo.Checked = true;
            this.radioCirculo.Location = new System.Drawing.Point(13, 27);
            this.radioCirculo.Name = "radioCirculo";
            this.radioCirculo.Size = new System.Drawing.Size(52, 21);
            this.radioCirculo.TabIndex = 11;
            this.radioCirculo.TabStop = true;
            this.radioCirculo.Text = "Ball";
            this.radioCirculo.UseVisualStyleBackColor = true;
            // 
            // radioQuadrado
            // 
            this.radioQuadrado.AutoSize = true;
            this.radioQuadrado.Location = new System.Drawing.Point(13, 54);
            this.radioQuadrado.Name = "radioQuadrado";
            this.radioQuadrado.Size = new System.Drawing.Size(143, 21);
            this.radioQuadrado.TabIndex = 12;
            this.radioQuadrado.TabStop = true;
            this.radioQuadrado.Text = "Square/Rectangle";
            this.radioQuadrado.UseVisualStyleBackColor = true;
            // 
            // groupBoxShape
            // 
            this.groupBoxShape.Controls.Add(this.radioCirculo);
            this.groupBoxShape.Controls.Add(this.radioQuadrado);
            this.groupBoxShape.Location = new System.Drawing.Point(4, 99);
            this.groupBoxShape.Name = "groupBoxShape";
            this.groupBoxShape.Size = new System.Drawing.Size(200, 81);
            this.groupBoxShape.TabIndex = 13;
            this.groupBoxShape.TabStop = false;
            this.groupBoxShape.Text = "Shape of Cluster(s)";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 427);
            this.Controls.Add(this.groupBoxShape);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridDados);
            this.Controls.Add(this.btnSalvarArquivo);
            this.Controls.Add(this.btnGerarDados);
            this.Controls.Add(this.chartVisualizaDados);
            this.Controls.Add(this.txtDados);
            this.Name = "Form2";
            this.Text = "Synthetic Data Generator";
            ((System.ComponentModel.ISupportInitialize)(this.chartVisualizaDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxShape.ResumeLayout(false);
            this.groupBoxShape.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuantidadeGrupos;
        private System.Windows.Forms.RichTextBox txtDados;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVisualizaDados;
        private System.Windows.Forms.Button btnGerarDados;
        private System.Windows.Forms.Button btnSalvarArquivo;
        private System.Windows.Forms.DataGridView gridDados;
        private System.Windows.Forms.Button btnGeraGrupos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioCirculo;
        private System.Windows.Forms.RadioButton radioQuadrado;
        private System.Windows.Forms.GroupBox groupBoxShape;
    }
}