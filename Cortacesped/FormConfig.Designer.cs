namespace Cortacesped
{
    partial class FormConfig
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckAutoDimension = new System.Windows.Forms.CheckBox();
            this.numericAncho = new System.Windows.Forms.NumericUpDown();
            this.numericAlto = new System.Windows.Forms.NumericUpDown();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericOstaculos = new System.Windows.Forms.NumericUpDown();
            this.ckManualObstaculos = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRepetir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCamino = new System.Windows.Forms.RadioButton();
            this.rbAmplitud = new System.Windows.Forms.RadioButton();
            this.rbProfundidad = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOstaculos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ancho";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckAutoDimension);
            this.groupBox1.Controls.Add(this.numericAncho);
            this.groupBox1.Controls.Add(this.numericAlto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 67);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensiones";
            // 
            // ckAutoDimension
            // 
            this.ckAutoDimension.AutoSize = true;
            this.ckAutoDimension.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckAutoDimension.Location = new System.Drawing.Point(17, 29);
            this.ckAutoDimension.Name = "ckAutoDimension";
            this.ckAutoDimension.Size = new System.Drawing.Size(48, 17);
            this.ckAutoDimension.TabIndex = 13;
            this.ckAutoDimension.Text = "Auto";
            this.ckAutoDimension.UseVisualStyleBackColor = true;
            this.ckAutoDimension.CheckedChanged += new System.EventHandler(this.ckAutoDimension_CheckedChanged);
            // 
            // numericAncho
            // 
            this.numericAncho.Location = new System.Drawing.Point(224, 28);
            this.numericAncho.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericAncho.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericAncho.Name = "numericAncho";
            this.numericAncho.Size = new System.Drawing.Size(40, 20);
            this.numericAncho.TabIndex = 8;
            this.numericAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericAncho.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericAlto
            // 
            this.numericAlto.Location = new System.Drawing.Point(127, 28);
            this.numericAlto.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericAlto.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericAlto.Name = "numericAlto";
            this.numericAlto.Size = new System.Drawing.Size(40, 20);
            this.numericAlto.TabIndex = 7;
            this.numericAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericAlto.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciar.Image = global::Cortacesped.Properties.Resources.ok;
            this.btnIniciar.Location = new System.Drawing.Point(538, 131);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(59, 40);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "&Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Obstáculos (%)";
            // 
            // numericOstaculos
            // 
            this.numericOstaculos.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericOstaculos.Location = new System.Drawing.Point(232, 28);
            this.numericOstaculos.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.numericOstaculos.Name = "numericOstaculos";
            this.numericOstaculos.Size = new System.Drawing.Size(40, 20);
            this.numericOstaculos.TabIndex = 10;
            this.numericOstaculos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericOstaculos.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ckManualObstaculos
            // 
            this.ckManualObstaculos.AutoSize = true;
            this.ckManualObstaculos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckManualObstaculos.Location = new System.Drawing.Point(21, 29);
            this.ckManualObstaculos.Name = "ckManualObstaculos";
            this.ckManualObstaculos.Size = new System.Drawing.Size(110, 17);
            this.ckManualObstaculos.TabIndex = 12;
            this.ckManualObstaculos.Text = "Selección manual";
            this.ckManualObstaculos.UseVisualStyleBackColor = true;
            this.ckManualObstaculos.CheckedChanged += new System.EventHandler(this.ckManualObstaculos_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ckManualObstaculos);
            this.groupBox3.Controls.Add(this.numericOstaculos);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(309, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 67);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Obstáculos";
            // 
            // btnRepetir
            // 
            this.btnRepetir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepetir.Image = ((System.Drawing.Image)(resources.GetObject("btnRepetir.Image")));
            this.btnRepetir.Location = new System.Drawing.Point(538, 85);
            this.btnRepetir.Name = "btnRepetir";
            this.btnRepetir.Size = new System.Drawing.Size(59, 40);
            this.btnRepetir.TabIndex = 9;
            this.btnRepetir.Text = "&Repetir";
            this.btnRepetir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRepetir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRepetir.UseVisualStyleBackColor = true;
            this.btnRepetir.Click += new System.EventHandler(this.btnRepetir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbCamino);
            this.groupBox2.Controls.Add(this.rbAmplitud);
            this.groupBox2.Controls.Add(this.rbProfundidad);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 86);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritmos";
            // 
            // rbCamino
            // 
            this.rbCamino.AutoSize = true;
            this.rbCamino.Location = new System.Drawing.Point(169, 54);
            this.rbCamino.Name = "rbCamino";
            this.rbCamino.Size = new System.Drawing.Size(187, 17);
            this.rbCamino.TabIndex = 2;
            this.rbCamino.TabStop = true;
            this.rbCamino.Text = "Camino mínimo entre dos parcelas";
            this.rbCamino.UseVisualStyleBackColor = true;
            this.rbCamino.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbAmplitud
            // 
            this.rbAmplitud.AutoSize = true;
            this.rbAmplitud.Location = new System.Drawing.Point(361, 23);
            this.rbAmplitud.Name = "rbAmplitud";
            this.rbAmplitud.Size = new System.Drawing.Size(129, 17);
            this.rbAmplitud.TabIndex = 1;
            this.rbAmplitud.TabStop = true;
            this.rbAmplitud.Text = "Recorrido en Amplitud";
            this.rbAmplitud.UseVisualStyleBackColor = true;
            this.rbAmplitud.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbProfundidad
            // 
            this.rbProfundidad.AutoSize = true;
            this.rbProfundidad.Location = new System.Drawing.Point(42, 23);
            this.rbProfundidad.Name = "rbProfundidad";
            this.rbProfundidad.Size = new System.Drawing.Size(146, 17);
            this.rbProfundidad.TabIndex = 0;
            this.rbProfundidad.TabStop = true;
            this.rbProfundidad.Text = "Recorrido en Profundidad";
            this.rbProfundidad.UseVisualStyleBackColor = true;
            this.rbProfundidad.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(573, 120);
            this.dataGridView1.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(12, 177);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(585, 145);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estadísticas";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 334);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRepetir);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIniciar);
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración del jardín";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOstaculos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.NumericUpDown numericAncho;
        private System.Windows.Forms.NumericUpDown numericAlto;
        private System.Windows.Forms.CheckBox ckAutoDimension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericOstaculos;
        private System.Windows.Forms.CheckBox ckManualObstaculos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRepetir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCamino;
        private System.Windows.Forms.RadioButton rbAmplitud;
        private System.Windows.Forms.RadioButton rbProfundidad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}