namespace Cortacesped
{
    partial class FormJardin
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerVelocidad = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerVelocidad
            // 
            this.timerVelocidad.Interval = 400;
            this.timerVelocidad.Tick += new System.EventHandler(this.timerVelocidad_Tick);
            // 
            // FormJardin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 336);
            this.Name = "FormJardin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cortacesped";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJardin_FormClosing);
            this.Load += new System.EventHandler(this.FormJardin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerVelocidad;


    }
}

