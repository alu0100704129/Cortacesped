﻿using System;
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
        private DateTime inicioTime, finalTime;
        private Resultado resultado;
        private Boolean m_BotonDown;
        private Int32 m_PosX, m_PosY;
        private Int32 m_Velocidad;
                
        public FormJardin(ref Jardin jardin, ref Robot robot, String algoritmo, Int32 velocidad, ref Resultado result)
        {
            
            m_Jardin = jardin;
            m_Robot = robot;
            m_Camino = new List<Parcela>();
            m_Algoritmo = algoritmo;
            resultado = result;
            m_Velocidad = velocidad;

            m_Destino = m_Robot.Destino;
            m_Destino.BorderStyle = BorderStyle.None;
                        
            InitializeComponent();

            ResizeForm();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void FormJardin_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            IniciarObjetosGraficos();
            this.timerVelocidad.Interval = m_Velocidad;
            this.ResumeLayout();
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
            this.timerVelocidad.Enabled = false;
        }

        private void ResizeForm()
        {
            this.ClientSize = new Size(m_Jardin.Columnas*m_Robot.Width, m_Jardin.Filas*m_Robot.Width);
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
            m_Robot.MouseDown += new MouseEventHandler(Robot_MouseDown);
            m_Robot.MouseMove += new MouseEventHandler(Robot_MouseMove);
            m_Robot.MouseUp += new MouseEventHandler(Robot_MouseUp);

            this.Controls.Add(m_Robot);
            m_Robot.BringToFront();
        }

        private void Robot_MouseDown(object sender, MouseEventArgs e)
        {
            // Si se ha pulsado el boton izquierdo
            if(e.Button == MouseButtons.Right)
            {
                m_BotonDown = true;
                m_PosX = e.X;
                m_PosY = e.Y;
            }
        }

        // Eventi para mover el robot con el raton
        private void Robot_MouseMove(object sender, MouseEventArgs e)
        {
            if(m_BotonDown)
            {
                m_Robot.Left += e.X - m_PosX;
                m_Robot.Top += e.Y - m_PosY;
            }
        }

        private void Robot_MouseUp(object sender, MouseEventArgs e)
        {
            // si el boton derecho se libera
            if(e.Button == MouseButtons.Right)
            {
                m_BotonDown = false;

                Int32 pX = m_Robot.Location.X;
                Int32 pY = m_Robot.Location.Y;
                Decimal ratioX = (Decimal)(pX / m_Robot.Width);
                Decimal ratioY = (Decimal)(pY / m_Robot.Height);
                Decimal mtrX = Math.Round(ratioX, 0, MidpointRounding.AwayFromZero);
                Decimal mtrY = Math.Round(ratioY, 0, MidpointRounding.AwayFromZero);
                Int32 posX = (Int32)mtrX * m_Robot.Width;
                Int32 posY = (Int32)mtrY * m_Robot.Height;
                m_Robot.Location = new Point(posX, posY);

                foreach(Parcela p in m_Jardin.Parcelas)
                {
                    if(p.Equals(m_Robot))
                    {
                        m_Robot.Fila = p.Fila;
                        m_Robot.Columna = p.Columna;
                        m_Robot.Origen = m_Jardin.Parcelas[p.Fila, p.Columna];
                        break;
                    }
                }
            }

        }
        
        // Evento Click de los objetos Parcela
        private void Evento_Click(object sender, MouseEventArgs e)
        {
            if(!m_BotonDown)
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
                            m_Robot.Destino = m_Jardin.Parcelas[p.Fila, p.Columna];
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
                        // Desactivamos los eventos del robot.
                        m_Robot.MouseClick -= Evento_Click;
                        m_Robot.MouseDown -= Robot_MouseDown;
                        m_Robot.MouseMove -= Robot_MouseMove;
                        m_Robot.MouseUp -= Robot_MouseUp;
                        m_Robot.Pasos = 0;
                        m_Camino.Clear();
                        m_Jardin.Parcelas[m_Robot.Origen.Fila, m_Robot.Origen.Columna].Visitada = true;

                        inicioTime = new DateTime(DateTime.Now.Ticks);
                        switch(m_Algoritmo)
                        {
                            case "Profundidad":
                                m_Camino = m_Robot.RecorridoDFS(ref m_Jardin);
                                m_Robot.Pasos = m_Camino.Count;
                                break;
                            case "Amplitud":
                                m_Camino = m_Robot.RecorridoBFS(ref m_Jardin);
                                m_Robot.Pasos += m_Camino.Count;
                                break;
                            case "Camino":
                                m_Camino = m_Robot.CalcularCaminoMinimo(m_Jardin, m_Jardin.Parcelas[m_Robot.Fila, m_Robot.Columna], m_Destino);
                                m_Robot.Pasos = m_Camino.Count;
                                break;
                        }
                        finalTime = new DateTime(DateTime.Now.Ticks);
                        TimeSpan duration = finalTime - inicioTime;
                        resultado.Tiempo = duration.Milliseconds;

                        m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;

                        m_Robot.Cortar(m_Robot.Origen);
                        m_Jardin.Parcelas[m_Robot.Origen.Fila, m_Robot.Origen.Columna].Visitada = true;
                                                
                        DialogResult result = MessageBox.Show("¿Desea visualizar el recrrido?", "Cortacesped", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if(result == DialogResult.No)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.timerVelocidad.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                        parcela.Tag = "Cesped_Largo";
                    }
                }
            }
            
        }

        // Metodo para deshabilitar el evento Click de los objetos parcela
        private void DisableParcela_Click(ref Parcela parcela)
        {
            parcela.MouseClick -= Evento_Click;
        }
        
        // Evento disparador del timer
        private void timerVelocidad_Tick(object sender, EventArgs e)
        {
            if(m_Camino.Count > 0)
            {
                Mover();
                m_Camino.RemoveAt(0);
            }
            else
            {
                this.timerVelocidad.Enabled = false;
                m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;
            }
        }
        
        // Metodo para mover el robot en la pantalla grafica
        private void Mover()
        {
            Parcela p = m_Camino[0];
            m_Robot.Cortar(m_Jardin.Parcelas[p.Fila, p.Columna]);

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
