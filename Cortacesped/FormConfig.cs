using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cortacesped.Clases;


namespace Cortacesped
{
    public partial class FormConfig : Form
    {

        private Jardin jardin;

        public FormConfig()
        {
            InitializeComponent();
        }

        private void ckAutoDimension_CheckedChanged(object sender, EventArgs e)
        {
            if(this.ckAutoDimension.Checked)
            {
                this.numericAlto.Enabled = false;
                this.numericAncho.Enabled = false;
            }
            else
            {
                this.numericAlto.Enabled = true;
                this.numericAncho.Enabled = true;
            }
        }

        private void ckManualObstaculos_CheckedChanged(object sender, EventArgs e)
        {
            if(this.ckManualObstaculos.Checked)
            {
                this.numericOstaculos.Enabled = false;
            }
            else
            {
                this.numericOstaculos.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            InitializeJardin();
            
            
        }


        private void InitializeJardin()
        {
            Int32 fil, col;
            Random rnd;
            if(this.ckAutoDimension.Checked)
            {
                rnd = new Random(DateTime.Now.Millisecond);
                fil = rnd.Next(Int32.Parse(this.numericAlto.Minimum.ToString()), 
                    Int32.Parse((this.numericAlto.Maximum+1).ToString()));
                col = rnd.Next(Int32.Parse(this.numericAncho.Minimum.ToString()),
                    Int32.Parse((this.numericAncho.Maximum + 1).ToString()));
            }
            else
            {
                fil = Int32.Parse(this.numericAlto.Value.ToString());
                col = Int32.Parse(this.numericAncho.Value.ToString());
            }
            
            ConstruirJardin(fil, col);

            
            FormJardin f = new FormJardin(ref jardin);
            this.Visible = false;
            f.ShowDialog(this);
            this.Visible = true;

        }

        private void ConstruirJardin(Int32 filas, Int32 columnas)
        {
            jardin = new Jardin(filas, columnas);

            
            for(Int32 fil = 0; fil < jardin.Filas; fil++)
            {
                for(Int32 col = 0; col < jardin.Columnas; col++)
                {
                    // Creamos un NUEVO control que es un objeto de tipo Parcela que hereda de PictureBox
                    Parcela parcela = new Parcela();

                    // Le asignamos las propiadades básicas al control teniendo en cuenta que es un PictureBox

                    parcela.Name = "m_Parcela" + fil.ToString() + col.ToString();
                    parcela.Tag = "Cesped_Largo";
                    parcela.Size = new Size(48, 48);
                    parcela.Location = new Point(col * parcela.Size.Width, fil * parcela.Size.Height);
                    parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    
                    parcela.Fila = fil;
                    parcela.Columna = col;
                    
                    jardin.Parcelas[fil, col] = parcela;

                    
                    

                }
            }

        }


    }
}
