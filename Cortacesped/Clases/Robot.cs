using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Cortacesped.Clases
{
    public class Robot : Parcela
    {

        private Int32 m_Pasos;
        private RobotDireccion m_Direccion;
        private List<Parcela> m_Camino;
        private List<Parcela> m_CaminoCopia;
        
        public Robot() 
        {
            m_Pasos = 0;
            m_Camino = new List<Parcela>();
            m_CaminoCopia = new List<Parcela>();
        }

        public Int32 Pasos
        {
            get { return m_Pasos; }
            set { m_Pasos = value; }
        }

        public RobotDireccion Direccion
        {
            get { return m_Direccion; }
            set { m_Direccion = value; }
        }

        public enum RobotDireccion
        {
            Derecha,
            Abajo,
            Izquierda,
            Arriba
        }

        
        // Retorna una lista de objetos Parcela qe representa el camino.
        public List<Parcela> RecorridoDFS(Jardin jardinAux)
        {
            Profundidad(jardinAux);

            return m_CaminoCopia;
        }

        // Retorna una lista de objetos Parcela qe representa el camino.
        public List<Parcela> RecorridoBFS(Jardin jardinAux)
        {
            m_Camino.Add(jardinAux.Parcelas[0, 0]);
            m_CaminoCopia.Add(jardinAux.Parcelas[0, 0]);
            Amplitud(jardinAux);
            return m_CaminoCopia;
        }
                
        private void Profundidad(Jardin jardinAux)
        {
            // Mover derecha
            if((this.Columna < jardinAux.Columnas - 1) &&
                (jardinAux.Parcelas[this.Fila, this.Columna + 1].Tag.ToString().Contains("Cesped")) &&
                (!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada))
            {

                this.Columna = this.Columna + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);
                
                this.Columna = this.Columna - 1;
                //m_Camino.Insert(0, jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);


                //m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna + 1]);
                //_Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                //_Robot.Mover(ref _Robot, Robot.RobotDireccion.Derecha);
                //Mover(_Robot);
            }

            // Mover abajo
            if((this.Fila < jardinAux.Filas - 1) &&
                (jardinAux.Parcelas[this.Fila + 1, this.Columna].Tag.ToString().Contains("Cesped")) &&
                (!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);

                this.Fila = this.Fila - 1;
                //m_Camino.Insert(0, jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                
                //m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila + 1, _Robot.Columna]);
                //_Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                //_Robot.Mover(ref _Robot, Robot.RobotDireccion.Abajo);
                //Mover(_Robot);

            }

            // Mover izquierda
            if((this.Columna > 0) &&
                (jardinAux.Parcelas[this.Fila, this.Columna - 1].Tag.ToString().Contains("Cesped")) &&
                (!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada))
            {
                this.Columna = this.Columna - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);

                this.Columna = this.Columna + 1;
                //m_Camino.Insert(0, jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);


                //m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna - 1]);
                //_Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                //_Robot.Mover(ref _Robot, Robot.RobotDireccion.Izquierda);
                //Mover(_Robot);
            }

            // Mover arriba
            if((this.Fila > 0) &&
                (jardinAux.Parcelas[this.Fila - 1, this.Columna].Tag.ToString().Contains("Cesped")) &&
                (!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);

                this.Fila = this.Fila + 1;
                //m_Camino.Insert(0, jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                
                //m_Camino.Add(m_Jardin.Parcelas[_Robot.Fila - 1, _Robot.Columna]);
                //_Robot.Cortar(ref m_Jardin.Parcelas[_Robot.Fila, _Robot.Columna]);
                //_Robot.Mover(ref _Robot, Robot.RobotDireccion.Arriba);
                //Mover(_Robot);
            }

        }


        private List<Parcela> retroceso = new List<Parcela>();


        private void Amplitud(Jardin jardinAux)
        {
            if(m_Camino.Count > 0)
            {
                Parcela actual = m_Camino[0];

                
                //m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna]);
                
                // Mover derecha
                if((actual.Columna < jardinAux.Columnas - 1) &&
                    (jardinAux.Parcelas[actual.Fila, actual.Columna + 1].Tag.ToString().Contains("Cesped")) &&
                    (!jardinAux.Parcelas[actual.Fila, actual.Columna + 1].Visitada))
                {
                    
                    jardinAux.Parcelas[actual.Fila, actual.Columna + 1].Visitada = true;
                    m_Camino.Add(jardinAux.Parcelas[actual.Fila, actual.Columna + 1]);
                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna + 1]);
                    
                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna]);

                }

                // Mover abajo
                if((actual.Fila < jardinAux.Filas - 1) &&
                    (jardinAux.Parcelas[actual.Fila + 1, actual.Columna].Tag.ToString().Contains("Cesped")) &&
                    (!jardinAux.Parcelas[actual.Fila + 1, actual.Columna].Visitada))
                {
                    jardinAux.Parcelas[actual.Fila + 1, actual.Columna].Visitada = true;
                    m_Camino.Add(jardinAux.Parcelas[actual.Fila + 1, actual.Columna]);
                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila + 1, actual.Columna]);

                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna]);
                }

                // Mover izquierda
                if((actual.Columna > 0) &&
                    (jardinAux.Parcelas[actual.Fila, actual.Columna - 1].Tag.ToString().Contains("Cesped")) &&
                    (!jardinAux.Parcelas[actual.Fila, actual.Columna - 1].Visitada))
                {
                    jardinAux.Parcelas[actual.Fila, actual.Columna - 1].Visitada = true;
                    m_Camino.Add(jardinAux.Parcelas[actual.Fila, actual.Columna - 1]);
                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna - 1]);

                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna]);
                }

                // Mover arriba
                if((actual.Fila > 0) &&
                    (jardinAux.Parcelas[actual.Fila - 1, actual.Columna].Tag.ToString().Contains("Cesped")) &&
                    (!jardinAux.Parcelas[actual.Fila - 1, actual.Columna].Visitada))
                {
                    jardinAux.Parcelas[actual.Fila - 1, actual.Columna].Visitada = true;
                    m_Camino.Add(jardinAux.Parcelas[actual.Fila - 1, actual.Columna]);
                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila - 1, actual.Columna]);

                    m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna]);
                }


                
                

                //m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna]);
                m_Camino.RemoveAt(0);


                Parcela siguiente = m_Camino[0];

                Int32 distanciaY = Math.Abs(siguiente.Fila - actual.Fila);
                Int32 distanciaX = Math.Abs(siguiente.Columna - actual.Columna);
                Int32 total = distanciaY + distanciaX;

                while(total > 0)
                {
                    // Hay que subir
                    if(siguiente.Fila < actual.Fila)
                    {
                        if(PosibleIr(RobotDireccion.Arriba))
                        {
                            retroceso.Add(jardinAux.Parcelas[actual.Fila - 1, actual.Columna]);
                            actual.Fila--;
                            total--;
                        }
                        else
                        {
                            if(PosibleIr(RobotDireccion.Izquierda))
                            {
                                if(siguiente.Columna < actual.Columna)
                                {
                                    retroceso.Add(jardinAux.Parcelas[actual.Fila, actual.Columna - 1]);
                                    actual.Columna--;
                                    total--;
                                }
                            }
                            else if(PosibleIr(RobotDireccion.Derecha))
                            {

                            }
                            else if(PosibleIr(RobotDireccion.Abajo))
                            {

                            }



                        }


                    
                    }
                    
                    // Hay que bajar
                    if(siguiente.Fila > actual.Fila)
                    {
                        if(jardinAux.Parcelas[actual.Fila + 1, actual.Columna].Visitada)
                        {
                            retroceso.Add(jardinAux.Parcelas[actual.Fila + 1, actual.Columna]);
                            actual.Fila++;
                            total--;
                        }
                    }





                }

                

                

                Amplitud(jardinAux);
                //m_CaminoCopia.Add(jardinAux.Parcelas[actual.Fila, actual.Columna]);
            }
        }

        private void Retroceder()
        {

            //for(int r = 0; r < retroceso.Count; r++)
            //{
            //    m_CaminoCopia.Add(retroceso[r]);
            //}


            for(int r = retroceso.Count - 1; r >= 0; r--)
            {
                m_CaminoCopia.Add(retroceso[r]);
            }
                       

            

        }




        private Boolean PosibleIr(RobotDireccion direccion)
        {
            Boolean flag = false;



            return flag;
        }
        

        public void Cortar(ref Parcela parcela)
        {
            parcela.Tag = "Cesped_Corto";
            parcela.Image = Cortacesped.Properties.Resources.Cesped_Corto;
            parcela.Visitada = true;
        }


        public Robot MoverAmplitud(ref Parcela parcela)
        {
            this.Location = new Point(parcela.Location.X, parcela.Location.Y);
            //this.Image = Cortacesped.Properties.Resources.Robot_Right;
            //this.Direccion = RobotDireccion.Derecha;
            this.Columna = parcela.Columna;
            this.Fila = parcela.Fila;
            this.Pasos++;
            return this;
        }



        public Robot Mover(RobotDireccion direccion)
        {
            switch(direccion)
            {
                case RobotDireccion.Derecha:
                    this.Location = new Point(this.Location.X + Width, this.Location.Y);
                    this.Image = Cortacesped.Properties.Resources.Robot_Right;
                    this.Direccion = RobotDireccion.Derecha;
                    this.Columna++;
                    this.Pasos++;
                    break;
                case RobotDireccion.Abajo:
                    this.Location = new Point(this.Location.X, this.Location.Y + Width);
                    this.Image = Cortacesped.Properties.Resources.Robot_Down;
                    this.Direccion = RobotDireccion.Abajo;
                    this.Fila++;
                    this.Pasos++;
                    break;
                case RobotDireccion.Izquierda:
                    this.Location = new Point(this.Location.X - Width, this.Location.Y);
                    this.Image = Cortacesped.Properties.Resources.Robot_Left;
                    this.Direccion = RobotDireccion.Izquierda;
                    this.Columna--;
                    this.Pasos++;
                    break;
                case RobotDireccion.Arriba:
                    this.Location = new Point(this.Location.X, this.Location.Y - Width);
                    this.Image = Cortacesped.Properties.Resources.Robot_Up;
                    this.Direccion = RobotDireccion.Arriba;
                    this.Fila--;
                    this.Pasos++;
                    break;
            }
            return this;
        }

    }
}
