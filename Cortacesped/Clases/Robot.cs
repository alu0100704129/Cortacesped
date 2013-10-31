using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Cortacesped.Clases
{
    /*
     * La clase Robot hereda de la clase Parcela la cual heredaba de PictureBox.
     * Esta clase será la que usaremos para representar a nuestro robot cortacesped,
     * y donde implementaremos los algoritmos.
     * Además de los atributos y funciones que hereda, se ha añadido un enumerado 
     * RobotDireccion que servirá para determinar en que dirección se tiene que mover
     * y con ello cambiaremos su imagen. También incopora dos atributos de tipo de su
     * clase base Parcela que representarán el origen y el destino del robot.
     * Por ultimo la clase incorpora una lista de objetos parcela para ir guardando
     * el camino por el que va pasando.
     */
    public class Robot : Parcela
    {
        private Int32 m_Pasos;
        private RobotDireccion m_Direccion;
        private List<Parcela> m_Camino;
        private List<Parcela> m_CaminoCopia;
        private Parcela m_Origen;
        private Parcela m_Destino;
        
        // Constructor
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

        public Parcela Origen
        {
            get { return m_Origen; }
            set { m_Origen = value; }
        }

        public Parcela Destino
        {
            get { return m_Destino; }
            set { m_Destino = value; }
        }

        // Enumerado que representa la dirección del robot
        public enum RobotDireccion
        {
            Derecha,
            Abajo,
            Izquierda,
            Arriba
        }

        /*
         * Función que retorna una lista de objetos Parcela que representan 
         * el camino a recorrer según el Algoritmo en Profundidad.
         */
        public List<Parcela> RecorridoDFS(ref Jardin jardinAux)
        {
            m_Camino.Clear();
            m_CaminoCopia.Clear();
            Profundidad(ref jardinAux);
            return m_CaminoCopia;
        }

        /*
         * Función que retorna una lista de objetos Parcela que representan 
         * el camino a recorrer según el Algoritmo en Amplitud.
         */
        public List<Parcela> RecorridoBFS(ref Jardin jardinAux)
        {
            m_Camino.Clear();
            m_CaminoCopia.Clear();
            m_Camino.Add(this.Origen);
            m_CaminoCopia.Add(this.Origen);
            Amplitud(ref jardinAux);
            return m_CaminoCopia;
        }
        
        /*
         * Método que calcula el recorrido en Profundidad
         * Devuelve void porque usa el atributo de la clase
         * de tipo Lista de parcelas (m_Camino) el cual será 
         * retornado por la función llamante.
         * Recibe como parámetro una referencia o puntero (ref)
         * de un objeto JArdin para que los cambios que se hagan
         * en el mismo estén actualizados en la aplicación.
         */
        private void Profundidad(ref Jardin jardinAux)
        {
            // Si nos podemos mover derecha y esa parcela no ha sido visitada
            if((PosibleIr(RobotDireccion.Derecha, ref jardinAux)) && (!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada))
            {
                this.Columna = this.Columna + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(ref jardinAux);
                this.Columna = this.Columna - 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }

            // Si nos podemos mover abajo y esa parcela no ha sido visitada
            if((PosibleIr(RobotDireccion.Abajo, ref jardinAux)) && (!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila + 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(ref jardinAux);
                this.Fila = this.Fila - 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }

            // Si nos podemos mover a la izquierda y esa parcela no ha sido visitada
            if((PosibleIr(RobotDireccion.Izquierda, ref jardinAux)) && (!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada))
            {
                this.Columna = this.Columna - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(ref jardinAux);
                this.Columna = this.Columna + 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
            
            // Si nos podemos mover arriba y esa parcela no ha sido visitada
            if((PosibleIr(RobotDireccion.Arriba, ref jardinAux)) && (!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada))
            {
                this.Fila = this.Fila - 1;
                jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                m_Camino.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
                Profundidad(ref jardinAux);
                this.Fila = this.Fila + 1;
                m_CaminoCopia.Add(jardinAux.Parcelas[this.Fila, this.Columna]);
            }
        }

        /*
         * Método que calcula el recorrido en Amplitud
         * Devuelve void porque usa el atributo de la clase
         * de tipo Lista de parcelas (m_Camino) el cual será 
         * retornado por la función llamante.
         */
        private void Amplitud(ref Jardin jardinAux)
        {
            Parcela actual;
            if(m_Camino.Count > 0)
            {
                // Cogemos la primera parcela que esté en la lista
                actual = m_Camino[0];
                
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

                // Eliminamos de la lista el que esté el primero
                m_Camino.RemoveAt(0);
                
                /*
                 * En este punto se debería hacer una llamada a un método
                 * que calcule el camino mínimo entre la posición actual y
                 * la siguiente posición para que visualmente el robot no
                 * de saltos en la pantalla.
                 * En su defecto lo que hacemos es calcular la distancia
                 * entre esos dos pontos y sumarla en pasos para posteriormente
                 * calcular el numero total de pasos que el robot debería dar.
                 */
                if(m_Camino.Count > 0)
                {
                    this.Pasos += CalcularDistancia(jardinAux.Parcelas[this.Fila, this.Columna], m_Camino[0]);
                }

                Amplitud(ref jardinAux);
                
            }

        }
        
        /*
         * Funcion que retornará una lista de parcelas con el
         * camino minimo entre origen y destino, parametros de 
         * tipo Parcela que recibe
         */
        public List<Parcela> CalcularCaminoMinimo(Jardin jardinAux, Parcela origen, Parcela destino)
        {
            
            Int32 valorSiguiente;

            /*
             * En este bucle recorremos todas las parcelas del jardín
             * y les asignamos un valor de distancia al objetivo 
             * analizando si es posible ir a todas las direcciones 
             * y marcando los valores correspondientes a cada parcela vecina.
             */
            foreach(Parcela parcelaAux in jardinAux.Parcelas)
            {
                this.Fila = parcelaAux.Fila;
                this.Columna = parcelaAux.Columna;

                if(PosibleIr(RobotDireccion.Derecha, ref jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila, this.Columna + 1], origen, destino);
                    jardinAux.Parcelas[this.Fila, this.Columna + 1].Valor = valorSiguiente;
                    
                }

                if(PosibleIr(RobotDireccion.Abajo, ref jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila + 1, this.Columna], origen, destino);
                    jardinAux.Parcelas[this.Fila + 1, this.Columna].Valor = valorSiguiente;
                    
                }

                if(PosibleIr(RobotDireccion.Izquierda, ref jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila, this.Columna - 1], origen, destino);
                    jardinAux.Parcelas[this.Fila, this.Columna - 1].Valor = valorSiguiente;                                    
                }

                if(PosibleIr(RobotDireccion.Arriba, ref jardinAux))
                {
                    valorSiguiente = CalcularValorParcela(jardinAux.Parcelas[this.Fila - 1, this.Columna], origen, destino);
                    jardinAux.Parcelas[this.Fila - 1, this.Columna].Valor = valorSiguiente;                    
                }
            }

            m_CaminoCopia.Clear();
            this.Fila = origen.Fila;
            this.Columna = origen.Columna;

            /*
             * Las parcelas ya están etiquetadas con su valor por lo
             * cual pasamos a calcular el camino mínimo llamando a 
             * dicho métdo.
             */
            CaminoMinimo(ref jardinAux, origen, destino);
            
            return m_CaminoCopia;

        }
        
        /*
         * Función que retorna si es posible desplazarse según la dirección
         */
        private Boolean PosibleIr(RobotDireccion direccion, ref Jardin m_Jardin)
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

        /* 
         * Función que devuelve el valor que se le asocia a la parcela.
         * Esta función permite modificarse facilmente para añadir el
         * calculo desde él origen a la posición actual y asi poder
         * implementar otros algoritmos.
         */
        private Int32 CalcularValorParcela(Parcela actual, Parcela origen, Parcela destino)
        {
            return CalcularDistancia(actual, destino);
        }
        
        /* 
         * Función que calcula la distancia Manhattan entre las
         * Parcelas origen y destino.
         */
        private Int32 CalcularDistancia(Parcela origen, Parcela destino)
        {
            Int32 distanciaY = Math.Abs(origen.Fila - destino.Fila);
            Int32 distanciaX = Math.Abs(origen.Columna - destino.Columna);
            return (distanciaY + distanciaX);
        }

        /*
         * Método void que calcula el camino mínimo entre dos Parcelas
         * origen y destino aplicando un algoritmo en escalada que usará
         * los valores de las parcelas recientemente etiquetadas para
         * mover el robot
         * Ha este método en particular se le ha implentado una mejora 
         * que consiste en calcular cuatro camino cada uno de ellos con 
         * una secuencia de direcciones diferente. El algoritmo elegirá
         * de los cuatro caminos encontrados aquel que sea menor.
         * Para dejar el algoritmo en su estado original debera comentar
         * el fragmento de codigo comprendido entre el comentario ==SEGUNDO
         * BLOQUE DE DIRECCIONES== y el comentario ==FIN DE LOS BLOQUES DE 
         * DIRECCIONES== ambos inclusibe.
         */
        private void CaminoMinimo(ref Jardin jardinAux, Parcela origen, Parcela destino)
        {
            
            List<Parcela> vecinos = new List<Parcela>();
            List<Parcela> camino = new List<Parcela>();
            IEnumerable<Parcela> query;

            List<List<Parcela>> caminos = new List<List<Parcela>>();
            
            // == PRIMER BLOQUE DE DIRECCIONES ==
            while((this.Fila != destino.Fila) || (this.Columna != destino.Columna))
            {
                if(PosibleIr(RobotDireccion.Derecha, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna + 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Abajo, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila + 1, this.Columna]);
                    }
                }

                if(PosibleIr(RobotDireccion.Arriba, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila - 1, this.Columna]);
                    }
                }

                if(PosibleIr(RobotDireccion.Izquierda, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna - 1]);
                    }
                }
                               

                // Si se ha podido mover
                if(vecinos.Count > 0)
                {
                    // Ordena la lista, escoge el de menor coste y lo añade al camino.
                    query = vecinos.OrderBy(x => x.Valor);
                    this.Fila = query.ElementAt(0).Fila;
                    this.Columna = query.ElementAt(0).Columna;
                    jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                    camino.Add(jardinAux.Parcelas[query.ElementAt(0).Fila, query.ElementAt(0).Columna]);
                }
                else
                {
                    if(camino.Count > 0)
                    {
                        // Retrocedemos
                        this.Fila = camino[camino.Count - 2].Fila;
                        this.Columna = camino[camino.Count - 2].Columna;
                        camino.RemoveAt(camino.Count - 1);
                    }
                }
                
                // Se vacía la lista de vecinos para volver a empezar
                vecinos.Clear();

            }

            // Se añade el camino encontrado a la lista de caminos
            caminos.Add(camino);
                                   

            /*
             * Aquí comienza la mejora con la combinación
             * de direcciones para deteminar el menor de
             * los caminos posibles segun este algoritmo.
             */
            // == SEGUNDO BLOQUE DE DIRECCIONES ==
            this.Fila = origen.Fila;
            this.Columna = origen.Columna;
            camino = new List<Parcela>();
            
            // Se reestablece el jardin poniendo las parcelas como no visitadas
            foreach(Parcela p in jardinAux.Parcelas)
            {
                if(p.Visitada)
                {
                    p.Visitada = false;
                }
            }


            while((this.Fila != destino.Fila) || (this.Columna != destino.Columna))
            {
                if(PosibleIr(RobotDireccion.Abajo, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila + 1, this.Columna]);
                    }
                }

                if(PosibleIr(RobotDireccion.Izquierda, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna - 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Derecha, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna + 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Arriba, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila - 1, this.Columna]);
                    }
                }
                
                // Si me he podido mover
                if(vecinos.Count > 0)
                {
                    //Ordeno la lista, escogemos el de menor coste y lo añadimos al camino.
                    query = vecinos.OrderBy(x => x.Valor);
                    
                    //vecinos = vecinos.OrderBy(x => x.Valor).ToList<Parcela>();
                    
                    this.Fila = query.ElementAt(0).Fila;
                    this.Columna = query.ElementAt(0).Columna;
                    jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                    camino.Add(jardinAux.Parcelas[query.ElementAt(0).Fila, query.ElementAt(0).Columna]);
                }
                else
                {
                    if(camino.Count > 0)
                    {
                        this.Fila = camino[camino.Count - 2].Fila;
                        this.Columna = camino[camino.Count - 2].Columna;
                        camino.RemoveAt(camino.Count - 1);
                    }
                }

                vecinos.Clear();

            }

            caminos.Add(camino);
            

            // ================================= TERCER BLOQUE DE DIRECCIONES =======================================
            this.Fila = origen.Fila;
            this.Columna = origen.Columna;
            camino = new List<Parcela>();
            foreach(Parcela p in jardinAux.Parcelas)
            {
                if(p.Visitada)
                {
                    p.Visitada = false;
                }
            }
            
            while((this.Fila != destino.Fila) || (this.Columna != destino.Columna))
            {
                if(PosibleIr(RobotDireccion.Izquierda, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna - 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Arriba, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila - 1, this.Columna]);
                    }
                }

                if(PosibleIr(RobotDireccion.Abajo, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila + 1, this.Columna]);
                    }
                }

                if(PosibleIr(RobotDireccion.Derecha, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna + 1]);
                    }
                }
                
                

                // Si me he podido mover
                if(vecinos.Count > 0)
                {
                    //Ordeno la lista, escogemos el de menor coste y lo añadimos al camino.
                    query = vecinos.OrderBy(x => x.Valor);

                    this.Fila = query.ElementAt(0).Fila;
                    this.Columna = query.ElementAt(0).Columna;
                    jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                    camino.Add(jardinAux.Parcelas[query.ElementAt(0).Fila, query.ElementAt(0).Columna]);
                }
                else
                {
                    if(camino.Count > 0)
                    {
                        this.Fila = camino[camino.Count - 2].Fila;
                        this.Columna = camino[camino.Count - 2].Columna;
                        camino.RemoveAt(camino.Count - 1);
                    }
                }

                vecinos.Clear();

            }

            caminos.Add(camino);
            

            // ================================= CUARTO BLOQUE DE DIRECCIONES =======================================
            this.Fila = origen.Fila;
            this.Columna = origen.Columna;
            camino = new List<Parcela>();
            foreach(Parcela p in jardinAux.Parcelas)
            {
                if(p.Visitada)
                {
                    p.Visitada = false;
                }
            }

            while((this.Fila != destino.Fila) || (this.Columna != destino.Columna))
            {
                if(PosibleIr(RobotDireccion.Arriba, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila - 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila - 1, this.Columna]);
                    }
                }

                if(PosibleIr(RobotDireccion.Derecha, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna + 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna + 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Izquierda, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila, this.Columna - 1].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila, this.Columna - 1]);
                    }
                }

                if(PosibleIr(RobotDireccion.Abajo, ref jardinAux))
                {
                    if(!jardinAux.Parcelas[this.Fila + 1, this.Columna].Visitada)
                    {
                        vecinos.Add(jardinAux.Parcelas[this.Fila + 1, this.Columna]);
                    }
                }
                
                // Si me he podido mover
                if(vecinos.Count > 0)
                {
                    //Ordeno la lista, escogemos el de menor coste y lo añadimos al camino.
                    query = vecinos.OrderBy(x => x.Valor);

                    this.Fila = query.ElementAt(0).Fila;
                    this.Columna = query.ElementAt(0).Columna;
                    jardinAux.Parcelas[this.Fila, this.Columna].Visitada = true;
                    camino.Add(jardinAux.Parcelas[query.ElementAt(0).Fila, query.ElementAt(0).Columna]);
                }
                else
                {
                    if(camino.Count > 0)
                    {
                        this.Fila = camino[camino.Count - 2].Fila;
                        this.Columna = camino[camino.Count - 2].Columna;
                        camino.RemoveAt(camino.Count - 1);
                    }
                }

                vecinos.Clear();

            }

            caminos.Add(camino);

            // ================================= FIN DE LOS BLOQUES DE DIRECCIONES =======================================

            Int32 valorMin = Int32.MaxValue;

            foreach(List<Parcela> lista in caminos)
            {
                if(lista.Count < valorMin)
                {
                    valorMin = lista.Count;
                    m_CaminoCopia.Clear();
                    m_CaminoCopia = lista;
                }
            }

            this.Columna = origen.Columna;
            this.Fila = origen.Fila;
        }
        
        /*
         * Metodo para cortar el cesped
         */
        public void Cortar(Parcela parcela)
        {
            parcela.Tag = "Cesped_Corto";
            parcela.Image = Cortacesped.Properties.Resources.Cesped_Corto;
            parcela.Visitada = true;
        }
        
        /*
         * función para mover el robot en el algoritmo de Amplitud
         */
        public Robot MoverAmplitud(ref Parcela parcela)
        {
            this.Location = new Point(parcela.Location.X, parcela.Location.Y);
            this.Columna = parcela.Columna;
            this.Fila = parcela.Fila;
            //this.Pasos++;
            return this;
        }
        
        /*
         * Funcion de mover para el algoritmo de profundidad
         */
        public Robot Mover(RobotDireccion direccion)
        {
            switch(direccion)
            {
                case RobotDireccion.Derecha:
                    this.Location = new Point(this.Location.X + Width, this.Location.Y);
                    this.Image = Cortacesped.Properties.Resources.Robot_Right;
                    this.Direccion = RobotDireccion.Derecha;
                    this.Columna++;
                    break;
                case RobotDireccion.Abajo:
                    this.Location = new Point(this.Location.X, this.Location.Y + Width);
                    this.Image = Cortacesped.Properties.Resources.Robot_Down;
                    this.Direccion = RobotDireccion.Abajo;
                    this.Fila++;
                    break;
                case RobotDireccion.Izquierda:
                    this.Location = new Point(this.Location.X - Width, this.Location.Y);
                    this.Image = Cortacesped.Properties.Resources.Robot_Left;
                    this.Direccion = RobotDireccion.Izquierda;
                    this.Columna--;
                    break;
                case RobotDireccion.Arriba:
                    this.Location = new Point(this.Location.X, this.Location.Y - Width);
                    this.Image = Cortacesped.Properties.Resources.Robot_Up;
                    this.Direccion = RobotDireccion.Arriba;
                    this.Fila--;
                    break;
            }
            return this;
        }

    }
}