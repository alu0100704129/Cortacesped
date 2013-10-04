using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                    PictureBox pic = new PictureBox();

                    // Le asignamos las propiadades básicas al control
                    pic.Name = "m_Pic" +f.ToString() + r.ToString();
                    pic.Tag = "Cesped";
                    pic.Size = new Size(48, 48);
                    pic.Location = new Point(r * pic.Size.Width, f * pic.Size.Height);
                    pic.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    pic.BackColor = Color.Green;

                    // Añadimos un evento a nuestro control
                    pic.Click += new EventHandler(Evento_Click);

                    //Añadimos el control al contenedor de controles de nuestro formulario
                    this.Controls.Add(pic);
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
