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
    public partial class Form1 : Form
    {

        
        
        public Form1()
        {
            InitializeComponent();
            IniciarBotones();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void IniciarBotones()
        {

            for(Int32 f = 0; f < 7; f++)
            {
                for(Int32 r = 0; r < 10; r++)
                {
                    // Creamos un NUEVO control que es un objeto de tipo PictureBox
                    //PictureBox parcela = new PictureBox();
                    Parcela parcela = new Parcela();



                    // Le asignamos las propiadades básicas al control
                    parcela.Name = "m_Pic" + f.ToString() + r.ToString();
                    parcela.Tag = "Cesped";
                    parcela.Size = new Size(48, 48);
                    parcela.Location = new Point(r * parcela.Size.Width, f * parcela.Size.Height);
                    parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    parcela.BackColor = Color.Green;

                    // Añadimos un evento a nuestro control
                    parcela.Click += new EventHandler(Evento_Click);

                    //Añadimos el control al contenedor de controles de nuestro formulario
                    this.Controls.Add(parcela);
                }
            }

            // Colocamos, inicialmente, el Robot en la posición [0, 0];
            PictureBox p = (PictureBox)this.Controls.Find("m_Pic00", false)[0];
            p.Image = Cortacesped.Properties.Resources.Robot_Right;
            
            // Asignamos su etiqueta como robot y eliminamos el evento click
            p.Tag = "Robot";
            p.Click -= Evento_Click;



        }
               
        
        private void Evento_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            
            String nombre = picBox.Image.ToString();

            if(picBox.Tag.ToString() == "Cesped")
            {
                picBox.Image = Cortacesped.Properties.Resources.Arbol;
                picBox.Tag = "Arbol";
            }
            else
            {
                picBox.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                picBox.Tag = "Cesped";
            }

        }

        

    }
}
