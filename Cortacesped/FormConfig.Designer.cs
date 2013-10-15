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
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btnRepetir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOstaculos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 54);
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
            this.groupBox1.Size = new System.Drawing.Size(179, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensiones";
            // 
            // ckAutoDimension
            // 
            this.ckAutoDimension.AutoSize = true;
            this.ckAutoDimension.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckAutoDimension.Location = new System.Drawing.Point(15, 38);
            this.ckAutoDimension.Name = "ckAutoDimension";
            this.ckAutoDimension.Size = new System.Drawing.Size(48, 17);
            this.ckAutoDimension.TabIndex = 13;
            this.ckAutoDimension.Text = "Auto";
            this.ckAutoDimension.UseVisualStyleBackColor = true;
            this.ckAutoDimension.CheckedChanged += new System.EventHandler(this.ckAutoDimension_CheckedChanged);
            // 
            // numericAncho
            // 
            this.numericAncho.Location = new System.Drawing.Point(122, 52);
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
            10,
            0,
            0,
            0});
            // 
            // numericAlto
            // 
            this.numericAlto.Location = new System.Drawing.Point(122, 26);
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
            7,
            0,
            0,
            0});
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciar.Image = global::Cortacesped.Properties.Resources.ok;
            this.btnIniciar.Location = new System.Drawing.Point(297, 105);
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
            this.label3.Location = new System.Drawing.Point(14, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Obstáculos (%)";
            // 
            // numericOstaculos
            // 
            this.numericOstaculos.Enabled = false;
            this.numericOstaculos.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericOstaculos.Location = new System.Drawing.Point(91, 52);
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
            this.ckManualObstaculos.Checked = true;
            this.ckManualObstaculos.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.groupBox3.Controls.Add(this.ckManualObstaculos);
            this.groupBox3.Controls.Add(this.numericOstaculos);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(206, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 87);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Obstáculos";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(93, 160);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(263, 23);
            this.pBar.Step = 1;
            this.pBar.TabIndex = 8;
            // 
            // btnRepetir
            // 
            this.btnRepetir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepetir.Image = ((System.Drawing.Image)(resources.GetObject("btnRepetir.Image")));
            this.btnRepetir.Location = new System.Drawing.Point(232, 105);
            this.btnRepetir.Name = "btnRepetir";
            this.btnRepetir.Size = new System.Drawing.Size(59, 40);
            this.btnRepetir.TabIndex = 9;
            this.btnRepetir.Text = "&Repetir";
            this.btnRepetir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRepetir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRepetir.UseVisualStyleBackColor = true;
            this.btnRepetir.Click += new System.EventHandler(this.btnRepetir_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 195);
            this.Controls.Add(this.btnRepetir);
            this.Controls.Add(this.pBar);
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
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button btnRepetir;
    }
}