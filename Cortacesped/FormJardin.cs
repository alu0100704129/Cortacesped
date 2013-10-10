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
    public partial class FormJardin : Form
    {

        private Jardin m_Jardin;
        private Parcela m_Robot;

        public FormJardin(ref Jardin jardin)
        {
            m_Jardin = jardin;
            InitializeComponent();
            ResizeForm();
            IniciarObjetosGraficos();
        }
        
        private void ResizeForm()
        {
            this.ClientSize = new Size(m_Jardin.Columnas*48, m_Jardin.Filas*48);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void IniciarObjetosGraficos()
        {
            //DisableParcela_Click(ref m_Robot);
            

            for(Int32 f = 0; f < m_Jardin.Filas; f++)
            {
                for(Int32 r = 0; r < m_Jardin.Columnas; r++)
                {
                    // Creamos un NUEVO control que es un objeto de tipo Parcela que hereda de PictureBox
                    
                    Parcela parcela = m_Jardin.Parcelas[f, r];

                    // Le asignamos las propiadades básicas al control teniendo en cuenta que es un PictureBox
                    //parcela.Fila = f;
                    //parcela.Columna = r;
                    //parcela.Name = "m_Parcela" + f.ToString() + r.ToString();
                    //parcela.Tag = "Cesped_Largo";
                    //parcela.Size = new Size(48, 48);
                    //parcela.Location = new Point(r * parcela.Size.Width, f * parcela.Size.Height);
                    //parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    
                    // Añadimos un evento a nuestro objeto de tipo Parcela
                    parcela.Click += new EventHandler(Evento_Click);

                    // Nuestro objeto Parcela hereda de PictureBox y, PictureBox, es un control,
                    // por lo tanto, nuestro objeto Parcela también es un control, y por ello, podemos
                    // añadirlo al contenedor de controles de nuestro formulario
                    this.Controls.Add(parcela);
                    
                }
            }

            // Colocamos, inicialmente, el Robot en la posición [0, 0];
            // Una forma de buscar --- m_Robot = (Parcela)this.Controls.Find("m_Parcela00", false)[0];
            m_Robot = new Parcela();
            m_Robot.Fila = 0;
            m_Robot.Columna = 0;
            m_Robot.Name = "Id_Robot";

            // Asignamos su etiqueta como robot y eliminamos el evento click
            m_Robot.Tag = "Robot";
            m_Robot.Size = new Size(48, 48);
            m_Robot.Location = new Point(0, 0);
            m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;

            m_Robot.Click -= Evento_Click;

            m_Jardin.Parcelas[0, 0] = m_Robot;

            this.Controls.Add(m_Robot);
            m_Robot.BringToFront();
            

            //m_Robot.Location = new Point(m_Robot.Location.X + 48, m_Robot.Location.Y);
            //this.Controls.RemoveByKey("m_Parcela00");

        }
        
        private void Evento_Click(object sender, EventArgs e)
        {
            Parcela parcela = (Parcela)sender;
            
            if(parcela.Tag.ToString() == "Cesped_Largo")
            {
                parcela.Image = Cortacesped.Properties.Resources.Arbol;
                parcela.Tag = "Arbol";
            }
            else
            {
                parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                parcela.Tag = "Cesped_Largo";
            }
        }

        private void DisableParcela_Click(ref Parcela parcela)
        {
            parcela.Click -= Evento_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            Size clientTam = this.ClientSize;
            Size formTam = this.Size;

            String a = this.Text;

            this.ClientSize = new Size(this.ClientSize.Width + 48, this.ClientSize.Height);
            clientTam = this.ClientSize;
            formTam = this.Size;

            a = this.Text;


        }

    }
}
