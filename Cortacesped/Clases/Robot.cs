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
            m_Camino.Clear();
            m_CaminoCopia.Clear();
            m_Camino.Add(jardinAux.Parcelas[0, 0]);
            m_CaminoCopia.Add(jardinAux.Parcelas[0, 0]);
            Amplitud(jardinAux);
            return m_CaminoCopia;
        }
                
        private void Profundidad(Jardin jardinAux)
        {
            // Mover derecha
            if((PosibleIr(RobotDireccion.Derecha, jardinAux)) && (!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada))
            {
                this.Columna = this.Columna + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);
                
                this.Columna = this.Columna - 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
            
            // Mover abajo
            if((PosibleIr(RobotDireccion.Abajo, jardinAux)) && (!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);

                this.Fila = this.Fila - 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
            
            // Mover izquierda
            if((PosibleIr(RobotDireccion.Izquierda, jardinAux)) && (!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada))
            {
                this.Columna = this.Columna - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);

                this.Columna = this.Columna + 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
            

            // Mover arriba
            if((PosibleIr(RobotDireccion.Arriba, jardinAux)) && (!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(jardinAux);

                this.Fila = this.Fila + 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
        }
                
        private void Amplitud(Jardin jardinAux)
        {
            if(m_Camino.Count > 0)
            {
                Parcela actual = m_Camino[0];
                
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

                m_Camino.RemoveAt(0);
                
                // Llamada a la función de creación de camino entre origen y destino

                if(m_Camino.Count > 0)
                {
                    this.Pasos += CalcularDistancia(jardinAux.Parcelas[this.Fila, this.Columna], m_Camino[0]);
                }
                

                Amplitud(jardinAux);
                
            }

        }
        
        // Funcion publica que retornará una lista de parcelas
        public List<Parcela> CalcularCaminoMinimo(Jardin jardinAux, Parcela origen, Parcela destino)
        {
            
            Int32 valorSiguiente;

            foreach(Parcela parcelaAux in jardinAux.Parcelas)
            {
                this.Fila = parcelaAux.Fila;
                this.Columna = parcelaAux.Columna;
                
                // Analizamos si es posible ir a todas las direcciones y marcamos con
                // los valores correspondientes a cada parcela vecina.
                if(PosibleIr(RobotDireccion.Derecha, jardinAux))
                {
                    valorSiguiente = CalcularValorParcelaNew(jardinAux.Parcelas[this.Fila, this.Columna + 1], origen, destino);
                    jardinAux.Parcelas[this.Fila, this.Columna + 1].Valor = valorSiguiente;
                    
                }
                
                if(PosibleIr(RobotDireccion.Abajo, jardinAux))
                {
                    valorSiguiente = CalcularValorParcelaNew(jardinAux.Parcelas[this.Fila + 1, this.Columna], origen, destino);
                    jardinAux.Parcelas[this.Fila + 1, this.Columna].Valor = valorSiguiente;
                    
                }
                
                if(PosibleIr(RobotDireccion.Izquierda, jardinAux))
                {
                    valorSiguiente = CalcularValorParcelaNew(jardinAux.Parcelas[this.Fila, this.Columna - 1], origen, destino);
                    jardinAux.Parcelas[this.Fila, this.Columna - 1].Valor = valorSiguiente;                                    
                }
                
                if(PosibleIr(RobotDireccion.Arriba, jardinAux))
                {
                    valorSiguiente = CalcularValorParcelaNew(jardinAux.Parcelas[this.Fila - 1, this.Columna], origen, destino);
                    jardinAux.Parcelas[this.Fila - 1, this.Columna].Valor = valorSiguiente;                    
                }
            }
            


            /*
            List<Parcela> caminoAux = new List<Parcela>();
            Parcela parcelaAux = origen;
            Int32 valorSiguiente;
            
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
            */
            



            // Las parcelas ya están etiquetadas con su valor
            // Construimos el camino minimo según dichos valores.
            m_CaminoCopia.Clear();
            
            this.Fila = origen.Fila;
            this.Columna = origen.Columna;

            DfsMinimo(jardinAux, destino);
            
            return m_CaminoCopia;

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

        private Int32 CalcularValorParcelaNew(Parcela actual, Parcela origen, Parcela destino)
        {
            Int32 actualDestino = CalcularDistancia(actual, destino);
            //Int32 origenActual = CalcularDistancia(origen, actual);
            Int32 distancia = actualDestino;// +origenActual;
            return distancia;
        }
        
        //private Int32 CalcularValorParcela(Parcela parcela, Parcela origen, Parcela destino)
        //{
                        
        //    return CalcularDistancia(parcela, destino);
        //}
        
        private Int32 CalcularDistancia(Parcela origen, Parcela destino)
        {
            Int32 distanciaY = Math.Abs(origen.Fila - destino.Fila);
            Int32 distanciaX = Math.Abs(origen.Columna - destino.Columna);
            return (distanciaY + distanciaX);
        }

        private void DfsMinimoInverso(Jardin jardinAux, Parcela destino)
        {
            if(!jardinAux.Parcelas[this.Fila, this.Columna].Equals(destino))
            {
                // Mover derecha
                if(PosibleIr(RobotDireccion.Derecha, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada)
                    {
                        // Si el valor de la parcela actual es mayor o igual que su parcela derecha
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor <= jardinAux.Parcelas[this.Fila, this.Columna + 1].Valor)
                        {
                            this.Columna = this.Columna + 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Izquierda, jardinAux))
                            {
                                this.Columna = this.Columna - 1;

                            }
                        }
                        else
                        {
                            //this.Columna = this.Columna + 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            DfsMinimo(jardinAux, destino);

                        }
                    }
                }


                // Mover abajo
                if(PosibleIr(RobotDireccion.Abajo, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada)
                    {
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor <= jardinAux.Parcelas[this.Fila + 1, this.Columna].Valor)
                        {
                            this.Fila = this.Fila + 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Arriba, jardinAux))
                            {
                                this.Fila = this.Fila - 1;

                            }
                        }
                        else
                        {
                            //this.Fila = this.Fila + 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            DfsMinimo(jardinAux, destino);
                        }
                    }

                }

                // Mover izquierda
                if(PosibleIr(RobotDireccion.Izquierda, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada)
                    {
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor <= jardinAux.Parcelas[this.Fila, this.Columna - 1].Valor)
                        {
                            this.Columna = this.Columna - 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Derecha, jardinAux))
                            {
                                this.Columna = this.Columna + 1;

                            }
                        }
                        else
                        {
                            //this.Columna = this.Columna - 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            DfsMinimo(jardinAux, destino);

                        }
                    }



                }

                // Mover arriba
                if(PosibleIr(RobotDireccion.Arriba, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada)
                    {
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor <= jardinAux.Parcelas[this.Fila - 1, this.Columna].Valor)
                        {
                            this.Fila = this.Fila - 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Abajo, jardinAux))
                            {
                                this.Fila = this.Fila + 1;
                            }
                        }
                        else
                        {
                            //this.Fila = this.Fila - 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            DfsMinimo(jardinAux, destino);
                        }
                    }
                }

                if(m_CaminoCopia.Count > 0)
                {
                    if(!m_CaminoCopia[m_CaminoCopia.Count - 1].Equals(destino))
                    {
                        m_CaminoCopia.RemoveAt(m_CaminoCopia.Count - 1);
                    }
                }

            }
            else
            {
                return;
            }
        }
        
        private void DfsMinimoNew(Jardin jardinAux, Parcela destino)
        {
            // Mover derecha
            if((PosibleIr(RobotDireccion.Derecha, jardinAux)) && (!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada))
            {
                this.Columna = this.Columna + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                DfsMinimoNew(jardinAux, destino);

                this.Columna = this.Columna - 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }

            // Mover abajo
            if((PosibleIr(RobotDireccion.Abajo, jardinAux)) && (!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                DfsMinimoNew(jardinAux, destino);

                this.Fila = this.Fila - 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }

            // Mover izquierda
            if((PosibleIr(RobotDireccion.Izquierda, jardinAux)) && (!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada))
            {
                this.Columna = this.Columna - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                DfsMinimoNew(jardinAux, destino);

                this.Columna = this.Columna + 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
            
            // Mover arriba
            if((PosibleIr(RobotDireccion.Arriba, jardinAux)) && (!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                DfsMinimoNew(jardinAux, destino);

                this.Fila = this.Fila + 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
                        
        }


        private void DfsMinimo(Jardin jardinAux, Parcela destino)
        {
            if(!jardinAux.Parcelas[this.Fila, this.Columna].Equals(destino))
            {
                // Mover derecha
                if(PosibleIr(RobotDireccion.Derecha, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada)
                    {
                        // Si el valor de la parcela actual es mayor o igual que su parcela derecha
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor > jardinAux.Parcelas[this.Fila, this.Columna + 1].Valor)
                        {
                            this.Columna = this.Columna + 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Izquierda, jardinAux))
                            {
                                this.Columna = this.Columna - 1;
                            }
                        }
                        else
                        {
                            //this.Columna = this.Columna + 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //DfsMinimoInverso(jardinAux, destino);

                        }
                    }
                }
                                
                                
                // Mover abajo
                if(PosibleIr(RobotDireccion.Abajo, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada)
                    {
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor > jardinAux.Parcelas[this.Fila + 1, this.Columna].Valor)
                        {
                            this.Fila = this.Fila + 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Arriba, jardinAux))
                            {
                                this.Fila = this.Fila - 1;

                            }
                        }
                        else
                        {
                            //this.Fila = this.Fila + 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //DfsMinimoInverso(jardinAux, destino);
                        }
                    }
                    
                }
                
                // Mover izquierda
                if(PosibleIr(RobotDireccion.Izquierda, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada)
                    {
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor > jardinAux.Parcelas[this.Fila, this.Columna - 1].Valor)
                        {
                            this.Columna = this.Columna - 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Derecha, jardinAux))
                            {
                                this.Columna = this.Columna + 1;

                            }
                        }
                        else
                        {
                            //this.Columna = this.Columna - 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //DfsMinimoInverso(jardinAux, destino);
                            
                        }
                    }
                    
                    
                    
                }
                
                // Mover arriba
                if(PosibleIr(RobotDireccion.Arriba, jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada)
                    {
                        if(jardinAux.Parcelas[this.Fila, this.Columna].Valor > jardinAux.Parcelas[this.Fila - 1, this.Columna].Valor)
                        {
                            this.Fila = this.Fila - 1;
                            jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);

                            DfsMinimo(jardinAux, destino);
                            if(PosibleIr(RobotDireccion.Abajo, jardinAux))
                            {
                                this.Fila = this.Fila + 1;
                            }
                        }
                        else
                        {
                            //this.Fila = this.Fila - 1;
                            //jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                            //m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                            //DfsMinimoInverso(jardinAux, destino);
                        }
                    }
                }

                if(m_CaminoCopia.Count > 0)
                {
                    if(!m_CaminoCopia[m_CaminoCopia.Count - 1].Equals(destino))
                    {
                        m_CaminoCopia.RemoveAt(m_CaminoCopia.Count - 1);
                    }
                }
                
            }
            else
            {
                return;
            }
            
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


            /* Metodo de calculo usando un foreach obtenemos todas las distancias al destino.
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