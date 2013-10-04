﻿using System;
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
            IniciarObjetosGraficos();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void IniciarObjetosGraficos()
        {

            for(Int32 f = 0; f < 7; f++)
            {
                for(Int32 r = 0; r < 10; r++)
                {
                    // Creamos un NUEVO control que es un objeto de tipo Parcela que hereda de PictureBox
                    Parcela parcela = new Parcela();

                    // Le asignamos las propiadades básicas al control teniendo en cuenta que es un PictureBox
                    parcela.Name = "m_Parcela" + f.ToString() + r.ToString();
                    parcela.Tag = "Cesped";
                    parcela.Size = new Size(48, 48);
                    parcela.Location = new Point(r * parcela.Size.Width, f * parcela.Size.Height);
                    parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    parcela.BackColor = Color.Green;

                    // Añadimos un evento a nuestro objeto de tipo Parcela
                    parcela.Click += new EventHandler(Evento_Click);

                    // Nuestro objeto Parcela hereda de PictureBox y, PictureBox, es un control,
                    // por lo tanto, nuestro objeto Parcela también es un control, y por ello, podemos
                    // añadirlo al contenedor de controles de nuestro formulario
                    this.Controls.Add(parcela);
                }
            }

            // Colocamos, inicialmente, el Robot en la posición [0, 0];
            Parcela p = (Parcela)this.Controls.Find("m_Parcela00", false)[0];
            p.Image = Cortacesped.Properties.Resources.Robot_Right;
            
            // Asignamos su etiqueta como robot y eliminamos el evento click
            p.Tag = "Robot";
            p.Click -= Evento_Click;



        }
               
        
        private void Evento_Click(object sender, EventArgs e)
        {
            Parcela parcela = (Parcela)sender;
            
            if(parcela.Tag.ToString() == "Cesped")
            {
                parcela.Image = Cortacesped.Properties.Resources.Arbol;
                parcela.Tag = "Arbol";
            }
            else
            {
                parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                parcela.Tag = "Cesped";
            }

        }

        

    }
}
