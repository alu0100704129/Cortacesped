using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Cortacesped.Clases;

namespace Cortacesped
{
    public partial class FormJardin : Form
    {

        private Jardin m_Jardin;
        private Robot m_Robot;
        private List<Parcela> m_Camino;
        private String m_Algoritmo;
        private Parcela m_Destino;
        
        public FormJardin(ref Jardin jardin, ref Robot robot, String algoritmo, Int32 velocidad)
        {
            m_Jardin = jardin;
            m_Robot = robot;
            m_Camino = new List<Parcela>();
            m_Algoritmo = algoritmo;
            

            m_Destino = m_Jardin.Parcelas[m_Jardin.Filas - 1, m_Jardin.Columnas - 1];
            m_Destino.BorderStyle = BorderStyle.None;

            InitializeComponent();
            IniciarObjetosGraficos();
            ResizeForm();
            this.timerVelocidad.Interval = velocidad;
        }

        private void FormJardin_Load(object sender, EventArgs e)
        {
            
        }

        private void FormJardin_FormClosing(object sender, FormClosingEventArgs e)
        {
            for(int fil = 0; fil < m_Jardin.Filas; fil++)
            {
                for(int col = 0; col < m_Jardin.Columnas; col++)
                {
                    DisableParcela_Click(ref m_Jardin.Parcelas[fil, col]);
                }
            }
            m_Robot.MouseClick -= Evento_Click;
        }

        private void ResizeForm()
        {
            this.ClientSize = new Size(m_Jardin.Columnas*m_Robot.Width, m_Jardin.Filas*m_Robot.Width);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void IniciarObjetosGraficos()
        {
            Int32 dimension = m_Jardin.Parcelas[0, 0].Size.Width;
            for(Int32 f = 0; f < m_Jardin.Filas; f++)
            {
                for(Int32 r = 0; r < m_Jardin.Columnas; r++)
                {
                    // Añadimos un evento a nuestra parcela
                    m_Jardin.Parcelas[f, r].MouseClick += new MouseEventHandler(Evento_Click);

                    // Añadimos la parcela al contenedor de controles del formulario
                    this.Controls.Add(m_Jardin.Parcelas[f, r]);
                }
            }
            m_Robot.MouseClick += new MouseEventHandler(Evento_Click);
            this.Controls.Add(m_Robot);
            m_Robot.BringToFront();
        }
        
        private void Evento_Click(object sender, MouseEventArgs e)
        {
            Parcela parcela = sender as Parcela;

            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if(m_Destino != null)
                {
                    m_Destino.BorderStyle = BorderStyle.None;
                }
                
                foreach(Parcela p in m_Jardin.Parcelas)
                {
                    if(p.Equals(parcela))
                    {
                        m_Destino = m_Jardin.Parcelas[p.Fila, p.Columna];
                        m_Destino.BorderStyle = BorderStyle.Fixed3D;
                        break;
                    }
                }
            }
            else
            {
                if(parcela.Tag.ToString() == "Cesped_Largo")
                {
                    parcela.Image = Cortacesped.Properties.Resources.Arbol;
                    parcela.Tag = "Arbol";
                }
                else if(parcela is Robot)
                {
                    m_Robot.MouseClick -= Evento_Click;

                    switch(m_Algoritmo)
                    {
                        case "Profundidad":
                            m_Camino = m_Robot.RecorridoDFS(m_Jardin);
                            break;
                        case "Amplitud":
                            m_Camino = m_Robot.RecorridoBFS(m_Jardin);
                            break;
                        case "Camino":
                            m_Camino = m_Robot.CalcularCaminoMinimo(m_Jardin, m_Jardin.Parcelas[0, 0], m_Destino);
                            break;
                    }

                    m_Robot.Fila = 0;
                    m_Robot.Columna = 0;
                    m_Robot.Location = new Point(0, 0);
                    m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;

                    m_Robot.Cortar(ref m_Jardin.Parcelas[0, 0]);
                    this.timerVelocidad.Enabled = true;
                }
                else
                {
                    parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    parcela.Tag = "Cesped_Largo";
                }
            }
        }

        private void DisableParcela_Click(ref Parcela parcela)
        {
            parcela.MouseClick -= Evento_Click;
        }
        
        private void timerVelocidad_Tick(object sender, EventArgs e)
        {
            if(m_Camino.Count > 0)
            {
                Mover();
                m_Camino.RemoveAt(0);
                this.Text = "Cortacesped - Pasos: " + m_Robot.Pasos.ToString();
            }
            else
            {
                this.timerVelocidad.Enabled = false;
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;
            }
        }
        
        private void Mover()
        {
            Parcela p = m_Camino[0];
            m_Robot.Cortar(ref m_Jardin.Parcelas[p.Fila, p.Columna]);

            if(m_Robot.Columna < p.Columna)
            {
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;
                m_Robot.Direccion = Robot.RobotDireccion.Derecha;
                m_Robot.MoverAmplitud(ref p);
                return;
            }
                        
            if(m_Robot.Fila > p.Fila)
            {
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Up;
                m_Robot.Direccion = Robot.RobotDireccion.Arriba;
                m_Robot.MoverAmplitud(ref p);
                return;
            }

            if(m_Robot.Fila < p.Fila)
            {
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Down;
                m_Robot.Direccion = Robot.RobotDireccion.Abajo;
                m_Robot.MoverAmplitud(ref p);
                return;
            }

            if(m_Robot.Columna > p.Columna)
            {
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Left;
                m_Robot.Direccion = Robot.RobotDireccion.Izquierda;
                m_Robot.MoverAmplitud(ref p);
                return;
            }
        }
    }
}
