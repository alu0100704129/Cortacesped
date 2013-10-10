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
            
            IniciarObjetosGraficos();
            
            ResizeForm();
        }
        
        private void ResizeForm()
        {
            //Int32 tamAlto = Screen.PrimaryScreen.Bounds.Height;
            //Int32 tamAncho = Screen.PrimaryScreen.Bounds.Width;

            //Int32 altoObjeto = tamAlto / m_Jardin.Filas;

            //Int32 anchoObjeto = tamAncho / m_Jardin.Columnas;

            



            
            this.ClientSize = new Size(m_Jardin.Columnas*m_Robot.Width, m_Jardin.Filas*m_Robot.Width);
            this.StartPosition = FormStartPosition.CenterScreen;

            
           


            //ancho = (Int32)(m_Robot.Width / m_Jardin.Columnas);
            //alto = (Int32)(m_Robot.Height / m_Jardin.Filas);


            //this.ClientSize = new System.Drawing.Size(ancho, alto); 

            //String a = "hola";

            


        }

        private void IniciarObjetosGraficos()
        {
            //DisableParcela_Click(ref m_Robot);
            Int32 dimension = m_Jardin.Parcelas[0, 0].Size.Width;

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
            m_Robot.SizeMode = PictureBoxSizeMode.StretchImage;
            m_Robot.Click += new EventHandler(Evento_Click);

            // Asignamos su etiqueta como robot y eliminamos el evento click
            m_Robot.Tag = "Robot";
            m_Robot.Size = new Size(dimension, dimension);
            m_Robot.Location = new Point(0, 0);
            m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;

            

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
            else if(parcela.Tag.ToString() == "Robot")
            {
                this.timerVelocidad.Enabled = true;
                //m_Robot.Click -= Evento_Click;
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

       

        private void timerVelocidad_Tick(object sender, EventArgs e)
        {
            Parcela actual, siguiente;

            // Moverse a la derecha
            if((m_Robot.Columna < m_Jardin.Columnas - 1) && 
                (m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna + 1].Tag.ToString().Contains("Cesped")) && 
                (!m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna + 1].Visitada))
            {
                siguiente = m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna + 1];
                //actual = m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna];

                actual = (Parcela)this.Controls.Find("m_Parcela" + m_Robot.Fila.ToString() + m_Robot.Columna.ToString(), false)[0];

                actual.Tag = "Cesped_Corto";
                actual.Image = Cortacesped.Properties.Resources.Cesped_Corto;
                actual.Visitada = true;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = actual;

                m_Robot.Location = new Point(m_Robot.Location.X + m_Robot.Width, m_Robot.Location.Y);
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;

                m_Robot.Columna++;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = m_Robot;
                
            }
            // Moverse abajo
            else if((m_Robot.Fila < m_Jardin.Filas - 1) && 
                (m_Jardin.Parcelas[m_Robot.Fila + 1, m_Robot.Columna].Tag.ToString().Contains("Cesped")) &&
                (!m_Jardin.Parcelas[m_Robot.Fila + 1, m_Robot.Columna].Visitada))
            {
                siguiente = m_Jardin.Parcelas[m_Robot.Fila+1, m_Robot.Columna];
                //actual = m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna];

                actual = (Parcela)this.Controls.Find("m_Parcela" + m_Robot.Fila.ToString() + m_Robot.Columna.ToString(), false)[0];

                actual.Tag = "Cesped_Corto";
                actual.Image = Cortacesped.Properties.Resources.Cesped_Corto;
                actual.Visitada = true;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = actual;

                m_Robot.Location = new Point(m_Robot.Location.X, m_Robot.Location.Y + m_Robot.Width);
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Down;

                m_Robot.Fila++;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = m_Robot;                
            }
            // Moverse a la izquierda
            else if((m_Robot.Columna > 0) && 
                (m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna - 1].Tag.ToString().Contains("Cesped")) &&
                (!m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna - 1].Visitada))
            {
                siguiente = m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna-1];
                //actual = m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna];

                actual = (Parcela)this.Controls.Find("m_Parcela" + m_Robot.Fila.ToString() + m_Robot.Columna.ToString(), false)[0];
                actual.Tag = "Cesped_Corto";
                actual.Image = Cortacesped.Properties.Resources.Cesped_Corto;
                actual.Visitada = true;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = actual;

                m_Robot.Location = new Point(m_Robot.Location.X - m_Robot.Width, m_Robot.Location.Y);
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Left;

                m_Robot.Columna--;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = m_Robot;
                
            }
            // Moverse arriba
            else if((m_Robot.Fila > 0) &&
                (m_Jardin.Parcelas[m_Robot.Fila - 1, m_Robot.Columna].Tag.ToString().Contains("Cesped")) &&
                (!m_Jardin.Parcelas[m_Robot.Fila - 1, m_Robot.Columna].Visitada))
            {
                siguiente = m_Jardin.Parcelas[m_Robot.Fila - 1, m_Robot.Columna];
                //actual = m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna];

                actual = (Parcela)this.Controls.Find("m_Parcela" + m_Robot.Fila.ToString() + m_Robot.Columna.ToString(), false)[0];
                actual.Tag = "Cesped_Corto";
                actual.Image = Cortacesped.Properties.Resources.Cesped_Corto;
                actual.Visitada = true;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = actual;

                m_Robot.Location = new Point(m_Robot.Location.X, m_Robot.Location.Y - m_Robot.Width);
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Up;

                m_Robot.Fila--;
                m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna] = m_Robot;

            }
            else
            {
                this.Text = "Cortacesped Finalizado";
                this.timerVelocidad.Stop();
            }

            
            
        }

        private void FormJardin_Load(object sender, EventArgs e)
        {

        }

        
    }
}
