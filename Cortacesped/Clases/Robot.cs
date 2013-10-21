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

                Parcela origen = m_Camino[0];
                m_Camino.RemoveAt(0);
                Parcela destino = m_Camino[0];

                // Llamada a la función de creación de camino entre origen y destino

                Amplitud(jardinAux);
                
            }
        }

        public List<Parcela> CalcularCaminoMinimo(Jardin jardinAux, Parcela origen, Parcela destino)
        {
            //List<Parcela> caminoMinimo = new List<Parcela>();
            List<Parcela> caminoAux = new List<Parcela>();
            Parcela parcelaAux = origen;
            Int32 valorSiguiente;




            /*
            Boolean movimiento = false;            
            foreach(Parcela parcelaAux in jardinAux.Parcelas)
            {
                this.Fila = parcelaAux.Fila;
                this.Columna = parcelaAux.Columna;
                
                // Analizamos si es posible ir a todas las direcciones y marcamos con
                // los valores correspondientes a cada parcela vecina.
                if(PosibleIr(RobotDireccion.Derecha, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada)
                    {
                        valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila, this.Columna + 1], origen, destino);
                        jardinAux.Parcelas[this.Fila, this.Columna + 1].Valor = valorSiguiente;
                        jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada = true;
                        movimiento = true;
                    }
                    
                }

                if(PosibleIr(RobotDireccion.Abajo, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada)
                    {
                        valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila + 1, this.Columna], origen, destino);
                        jardinAux.Parcelas[this.Fila + 1, this.Columna].Valor = valorSiguiente;
                        jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada = true;
                        movimiento = true;
                    }
                    
                    
                }

                if(PosibleIr(RobotDireccion.Izquierda, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada)
                    {
                        valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila, this.Columna - 1], origen, destino);
                        jardinAux.Parcelas[this.Fila, this.Columna - 1].Valor = valorSiguiente;
                        jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada = true;
                        movimiento = true;
                    }
                    
                }

                if(PosibleIr(RobotDireccion.Arriba, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada)
                    {
                        valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila - 1, this.Columna], origen, destino);
                        jardinAux.Parcelas[this.Fila - 1, this.Columna].Valor = valorSiguiente;
                        jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada = true;
                        movimiento = true;
                    }
                }

                if(!movimiento)
                {
                    jardinAux.Parcelas[parcelaAux.Fila, parcelaAux.Columna].Valor = Int32.MaxValue;
                }
                else
                {
                    movimiento = false;
                }
                
            }

            */









            // =======================================================================
            
            origen.Valor = CalcularValorParcela(origen, origen, destino);
            
            caminoAux.Add(origen);
                       
            
            while(caminoAux.Count > 0)
            {
                // Se toma la primera como referencia de partida y se busca la de menor valor.
                parcelaAux = caminoAux[0];
                for(int r = 0; r < caminoAux.Count; r++)
                {
                    if(caminoAux[r].Valor < parcelaAux.Valor)
                    {
                        parcelaAux = caminoAux[r];
                    }
                }

                // Buscamos y eliminamos la parcela elegida de la lista.
                caminoAux.RemoveAt(caminoAux.IndexOf(parcelaAux));

                // Actualizamos la posición del Robot (this)
                this.Fila = parcelaAux.Fila;
                this.Columna = parcelaAux.Columna;
                
                // Analizamos si es posible ir a todas las direcciones y marcamos con
                // los valores correspondientes a cada parcela vecina.
                if(PosibleIr(RobotDireccion.Derecha, jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila, this.Columna + 1], origen, destino);
                    if(valorSiguiente < parcelaAux.Valor)
                    {
                        jardinAux.Parcelas[this.Fila, this.Columna + 1].Valor = valorSiguiente;
                        caminoAux.Add(jardinAux.Parcelas[this.Fila, this.Columna + 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Abajo, jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila + 1, this.Columna], origen, destino);
                    if(valorSiguiente < parcelaAux.Valor)
                    {
                        jardinAux.Parcelas[this.Fila + 1, this.Columna].Valor = valorSiguiente;
                        caminoAux.Add(jardinAux.Parcelas[this.Fila + 1, this.Columna]);
                    }
                }

                if(PosibleIr(RobotDireccion.Izquierda, jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila, this.Columna - 1], origen, destino);
                    if(valorSiguiente < parcelaAux.Valor)
                    {
                        jardinAux.Parcelas[this.Fila, this.Columna - 1].Valor = valorSiguiente;
                        caminoAux.Add(jardinAux.Parcelas[this.Fila, this.Columna - 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Arriba, jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila - 1, this.Columna], origen, destino);
                    if(valorSiguiente < parcelaAux.Valor)
                    {
                        jardinAux.Parcelas[this.Fila - 1, this.Columna].Valor = valorSiguiente;
                        caminoAux.Add(jardinAux.Parcelas[this.Fila - 1, this.Columna]);
                    }
                }
            }
            

            return ConstruirCaminoMinimo(jardinAux, origen, destino);

        }


        private Boolean PosibleIr(RobotDireccion direccion, Jardin m_Jardin)
        {
            Boolean flag = false;
            switch(direccion)
            {
                case RobotDireccion.Derecha:
                    if((this.Columna < m_Jardin.Columnas - 1) && (m_Jardin.Parcelas[this.Fila, this.Columna + 1].Tag.ToString().Contains("Cesped")))
                    {
                        flag = true;
                    }
                    break;
                case RobotDireccion.Abajo:
                    if((this.Fila < m_Jardin.Filas - 1) && (m_Jardin.Parcelas[this.Fila + 1, this.Columna].Tag.ToString().Contains("Cesped")))
                    {
                        flag = true;
                    }
                    break;
                case RobotDireccion.Izquierda:
                    if((this.Columna > 0) && (m_Jardin.Parcelas[this.Fila, this.Columna - 1].Tag.ToString().Contains("Cesped")))
                    {
                        flag = true;
                    }
                    break;
                case RobotDireccion.Arriba:
                    if((this.Fila > 0) && (m_Jardin.Parcelas[this.Fila - 1, this.Columna].Tag.ToString().Contains("Cesped")))
                    {
                        flag = true;
                    }
                    break;
            }
            return flag;
        }
        
        private Int32 CalcularValorParcela(Parcela parcela, Parcela origen, Parcela destino)
        {
            return CalcularDistancia(parcela, destino);
            
            //Int32 funcionG = 1; // CalcularDistancia(origen, parcela);
            //Int32 funcionH = CalcularDistancia(parcela, destino);
            //Int32 funcion_N = funcionG + funcionH;
            //return funcion_N;
        }

        private Int32 CalcularDistancia(Parcela origen, Parcela destino)
        {
            Int32 distanciaY = Math.Abs(origen.Fila - destino.Fila);
            Int32 distanciaX = Math.Abs(origen.Columna - destino.Columna);
            return (distanciaY + distanciaX);
        }
        
        private List<Parcela> ConstruirCaminoMinimo(Jardin jardin, Parcela origen, Parcela destino)
        {

            List<Parcela> camino = new List<Parcela>();
            Int32 valorSiguiente = 0;
            Int32 valorMinimo = Int32.MaxValue;
            Parcela actual = origen;
            Parcela parcelaAux = origen;
            camino.Add(actual);
            
            while(!actual.Equals(destino))
            {
                this.Fila = actual.Fila;
                this.Columna = actual.Columna;

                // Obtener valor de la parcela Derecha
                if(PosibleIr(RobotDireccion.Derecha, jardin))
                {
                    valorSiguiente = jardin.Parcelas[actual.Fila, actual.Columna + 1].Valor;
                    if(valorSiguiente < valorMinimo)
                    {
                        valorMinimo = valorSiguiente;
                        parcelaAux = jardin.Parcelas[actual.Fila, actual.Columna + 1];
                    }
                }
                
                // Obtener valor de la parcela Inferior
                if(PosibleIr(RobotDireccion.Abajo, jardin))
                {
                    valorSiguiente = jardin.Parcelas[actual.Fila + 1, actual.Columna].Valor;
                    if(valorSiguiente < valorMinimo)
                    {
                        valorMinimo = valorSiguiente;
                        parcelaAux = jardin.Parcelas[actual.Fila + 1, actual.Columna];
                    }
                }
                
                // Obtener valor de la parcela Izquierda
                if(PosibleIr(RobotDireccion.Izquierda, jardin))
                {
                    valorSiguiente = jardin.Parcelas[actual.Fila, actual.Columna - 1].Valor;
                    if(valorSiguiente < valorMinimo)
                    {
                        valorMinimo = valorSiguiente;
                        parcelaAux = jardin.Parcelas[actual.Fila, actual.Columna - 1];
                    }
                }
                

                // Obtener valor de la parcela Superior
                if(PosibleIr(RobotDireccion.Arriba, jardin))
                {
                    valorSiguiente = jardin.Parcelas[actual.Fila - 1, actual.Columna].Valor;
                    if(valorSiguiente < valorMinimo)
                    {
                        valorMinimo = valorSiguiente;
                        parcelaAux = jardin.Parcelas[actual.Fila - 1, actual.Columna];
                    }
                }
                
                camino.Add(parcelaAux);
                actual = parcelaAux;

            }
            
            return camino;
            
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
