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

        //private Thread m_Hilo = new Thread(FormJardin.Mover);
        
        public FormJardin(ref Jardin jardin, ref Robot robot, String algoritmo)
        {
            m_Jardin = jardin;
            m_Robot = robot;
            m_Camino = new List<Parcela>();
            m_Algoritmo = algoritmo;

            InitializeComponent();
            IniciarObjetosGraficos();

            ResizeForm();
            
        }

        private void FormJardin_Load(object sender, EventArgs e)
        {
            
        }

        private void FormJardin_FormClosing(object sender, FormClosingEventArgs e)
        {
                        
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
                    m_Jardin.Parcelas[f, r].Click += new EventHandler(Evento_Click);

                    // Añadimos la parcela al contenedor de controles del formulario
                    this.Controls.Add(m_Jardin.Parcelas[f, r]);
                }
            }
            
            m_Robot.Click += new EventHandler(Evento_Click);

            this.Controls.Add(m_Robot);
            m_Robot.BringToFront();
            
        }
        
        private void Evento_Click(object sender, EventArgs e)
        {
            Parcela parcela = (Parcela)sender;
            
            if(parcela.Tag.ToString() == "Cesped_Largo")
            {
                parcela.Image = Cortacesped.Properties.Resources.Arbol;
                parcela.Tag = "Arbol";
            }
            else if(parcela is Robot)
            {
                m_Robot.Click -= Evento_Click;

                switch(m_Algoritmo)
                {
                    case "Profundidad":
                        m_Camino = m_Robot.RecorridoDFS(m_Jardin);
                        break;
                    case "Amplitud" :
                        m_Camino = m_Robot.RecorridoBFS(m_Jardin);
                        break;
                    case "Camino" :
                        m_Camino = m_Robot.CalcularCaminoMinimo(m_Jardin, m_Jardin.Parcelas[0, 0], m_Jardin.Parcelas[1, 3]);
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

        private void DisableParcela_Click(ref Parcela parcela)
        {
            parcela.Click -= Evento_Click;
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
                
                //m_Robot = m_Robot.Mover(Robot.RobotDireccion.Derecha);
                return;
            }
                        
            if(m_Robot.Fila > p.Fila)
            {
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Up;
                m_Robot.Direccion = Robot.RobotDireccion.Arriba;
                m_Robot.MoverAmplitud(ref p);
                
                //m_Robot = m_Robot.Mover(Robot.RobotDireccion.Arriba);
                return;
            }

            if(m_Robot.Fila < p.Fila)
            {
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Down;
                m_Robot.Direccion = Robot.RobotDireccion.Abajo;
                m_Robot.MoverAmplitud(ref p);
                
                //m_Robot = m_Robot.Mover(Robot.RobotDireccion.Abajo);
                return;
            }

            if(m_Robot.Columna > p.Columna)
            {
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Left;
                m_Robot.Direccion = Robot.RobotDireccion.Izquierda;
                m_Robot.MoverAmplitud(ref p);
                
                //m_Robot = m_Robot.Mover(Robot.RobotDireccion.Izquierda);
                return;
            }
            
        }



        /* NO TOCAR VERSION DE PRUEBAS
        public void Mover(Robot _Robot)
        {
            
            //System.Threading.Thread.Sleep(250);


            for(int a = 0; a < 2000; a++)
            {
                for(int b = 0; b < 20000; b++)
                {
                    String xc = "hola";
                }
            }


            this.Refresh();

            //_Robot.Refresh();

            // Mover derecha
            if((_Robot.Columna < m_Jardin.Columnas - 1) &&
                (m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna + 1].Tag.ToString().Contains("Cesped")) &&
                (!m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna + 1].Visitada))
            {
                m_Robot.RecorridoDFS(m_Jardin);

                m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna + 1]);
                                
                _Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                _Robot.Mover(ref _Robot, Robot.RobotDireccion.Derecha);
                
                
                Mover(_Robot);
            }
            
            // Mover abajo
            if((_Robot.Fila < m_Jardin.Filas - 1) &&
                (m_Jardin.Parcelas[_Robot.Fila + 1, _Robot.Columna].Tag.ToString().Contains("Cesped")) &&
                (!m_Jardin.Parcelas[_Robot.Fila + 1, _Robot.Columna].Visitada))
            {
                m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila + 1, _Robot.Columna]);
               
                _Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                
                _Robot.Mover(ref _Robot, Robot.RobotDireccion.Abajo);
                Mover(_Robot);
                
            }
            
            // Mover izquierda
            if((_Robot.Columna > 0) &&
                (m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna - 1].Tag.ToString().Contains("Cesped")) &&
                (!m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna - 1].Visitada))
            {
                m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna - 1]);
                
                _Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                
                _Robot.Mover(ref _Robot, Robot.RobotDireccion.Izquierda);
                Mover(_Robot);
            }
            
            // Mover arriba
            if((_Robot.Fila > 0) &&
                (m_Jardin.Parcelas[_Robot.Fila - 1, _Robot.Columna].Tag.ToString().Contains("Cesped")) &&
                (!m_Jardin.Parcelas[_Robot.Fila - 1, _Robot.Columna].Visitada))
            {
                m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila - 1, _Robot.Columna]);
                
                _Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                
                _Robot.Mover(ref _Robot, Robot.RobotDireccion.Arriba);
                Mover(_Robot);
            }


            
            this.Text = "Cortacesped Finalizado - " + m_Robot.Pasos.ToString();
            this.timerVelocidad.Enabled = false;
            
        }
        */


    }
}
