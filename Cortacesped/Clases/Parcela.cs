using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cortacesped.Clases
{
    /*
     * La clase Parcela será la que represente cada una de las parcelas del jardín.
     * Esta clase hereda del Control PictureBox que es un control de formularios de
     * WindowsForm, el cual incorpora toda la funcionalidad de un cuadro de imagen.
     * A la clase Parcela, además de los atributos y funciones que hereda, se le añaden
     * sus valores de fila y columna para conocer su posición en terminos de una matriz
     * Además, posee los atributos visitado y valor, este ultimo para calcular las distancias.
     */
    public class Parcela : PictureBox
    {

        private Int32 m_Fila;
        private Int32 m_Columna;
        private Boolean m_Visitado;
        private Int32 m_Valor;

        // Constructor
        public Parcela()
        {
            m_Valor = Int32.MaxValue;
        }

        public Int32 Fila
        {
            get { return m_Fila; }
            set { m_Fila = value; }
        }

        public Int32 Columna
        {
            get { return m_Columna; }
            set { m_Columna = value; }
        }

        public Boolean Visitada
        {
            get { return m_Visitado; }
            set { m_Visitado = value; }
        }

        public Int32 Valor
        {
            get { return m_Valor; }
            set { m_Valor = value; }
        }

        /*
         * Se sobreescribe la función Equals para comparar
         * objetos de la clase Parcela según su posición (Fila, Columna)
         * devolviendo true si estos valores son iguales.
         */
        public override bool Equals(object obj)
        {
            Boolean flag = false;
            Parcela parcela;
            if(obj is Parcela)
            {
                parcela = obj as Parcela;
                if((this.Location.X == parcela.Location.X) && (this.Location.Y == parcela.Location.Y))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /*
         * Al sobreescribir la función Equals, hay que sobreescribir
         * también la función GetHashCode().
         */
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
