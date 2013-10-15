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
        private Robot m_Robot;

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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            InitializeJardin();
        }

        private void btnRepetir_Click(object sender, EventArgs e)
        {
            if(jardin != null)
            {
                RestablecerJardin();
                FormJardin f = new FormJardin(ref jardin, ref m_Robot);
                this.Visible = false;
                f.ShowDialog(this);
                this.Visible = true;
                this.Text = "Configuración del jardin - " + m_Robot.Pasos.ToString() + " pasos.";
                
            }
        }

        private void RestablecerJardin()
        {
            for(int fil = 0; fil < jardin.Filas; fil++)
            {
                for(int col = 0; col < jardin.Columnas; col++)
                {
                    if(jardin.Parcelas[fil, col].Tag.ToString() == "Cesped_Corto")
                    {
                        jardin.Parcelas[fil, col].Tag = "Cesped_Largo";
                        jardin.Parcelas[fil, col].Visitada = false;
                        jardin.Parcelas[fil, col].Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    }
                }
            }
            m_Robot.Fila = 0;
            m_Robot.Columna = 0;
            m_Robot.Pasos = 0;
            m_Robot.Location = new Point(0, 0);
            m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;
            jardin.Parcelas[0, 0].Visitada = true;
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
            

            ConstruirJardin(fil, col, this.ckManualObstaculos.Checked);
            
            FormJardin f = new FormJardin(ref jardin, ref m_Robot);

            //FormJardin f = new FormJardin(new Jardin(jardin));
            this.Visible = false;
            f.ShowDialog(this);
            this.Visible = true;
            this.Text = "Configuración del jardin - " + m_Robot.Pasos.ToString() + " pasos.";

        }

        private void ConstruirJardin(Int32 filas, Int32 columnas, Boolean obstaculosManual)
        {
            Int32 posX, posY, dimension;
            jardin = new Jardin(filas, columnas);
            Random rnd = new Random(DateTime.Now.Millisecond);
            Int32 tamJardin = filas * columnas;
            Decimal factor = (Decimal.Parse(this.numericOstaculos.Value.ToString()) / 100) * tamJardin;
            Int32 total = (Int32)factor;
            
            Int32 altoObjeto = ((Screen.PrimaryScreen.Bounds.Height-80) / filas);
            Int32 anchoObjeto = ((Screen.PrimaryScreen.Bounds.Width-40) / columnas);

            if(altoObjeto > anchoObjeto)
            {
                dimension = anchoObjeto;
            }
            else
            {
                dimension = altoObjeto;
            }
                       

            for(Int32 fil = 0; fil < jardin.Filas; fil++)
            {
                for(Int32 col = 0; col < jardin.Columnas; col++)
                {
                    // Creamos un NUEVO control que es un objeto de tipo Parcela que hereda de PictureBox
                    Parcela parcela = new Parcela();

                    // Le asignamos las propiadades básicas al control teniendo en cuenta que es un PictureBox
                    parcela.Fila = fil;
                    parcela.Columna = col;
                    
                    parcela.Name = "m_Parcelaf" + fil.ToString() + "c" + col.ToString();
                    parcela.Size = new Size(dimension, dimension);
                    parcela.Location = new Point(col * parcela.Size.Width, fil * parcela.Size.Height);
                    parcela.Tag = "Cesped_Largo";
                    parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    parcela.SizeMode = PictureBoxSizeMode.StretchImage;
                    
                    jardin.Parcelas[fil, col] = parcela;
                    this.pBar.PerformStep();
                }
            }

            jardin.Parcelas[0, 0].Tag = "Cesped_Corto";
            jardin.Parcelas[0, 0].Image = Cortacesped.Properties.Resources.Cesped_Corto;
            jardin.Parcelas[0, 0].Visitada = true;

            m_Robot = new Robot();
            m_Robot.Fila = 0;
            m_Robot.Columna = 0;
            m_Robot.Pasos = 0;
            m_Robot.Name = "Id_Robot";
            m_Robot.Tag = "Robot";
            m_Robot.Size = new Size(dimension, dimension);
            m_Robot.Location = new Point(0, 0);
            m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;
            m_Robot.SizeMode = PictureBoxSizeMode.StretchImage;
            m_Robot.Direccion = Robot.RobotDireccion.Derecha;
            
            if(!obstaculosManual)
            {
                while(total > 0)
                {
                    posX = rnd.Next(0, columnas);
                    posY = rnd.Next(0, filas);
                    if(jardin.Parcelas[posY, posX].Tag.ToString() == "Cesped_Largo")
                    {
                        jardin.Parcelas[posY, posX].Tag = "Arbol";
                        jardin.Parcelas[posY, posX].Image = Cortacesped.Properties.Resources.Arbol;
                        total -= 1;
                    }
                }
            }
        }       

    }
}
