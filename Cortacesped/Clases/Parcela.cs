using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cortacesped.Clases
{
    public class Parcela : PictureBox
    {

        private Int32 m_Fila;
        private Int32 m_Columna;
        private Boolean m_Visitado;
        private Int32 m_Valor;

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

    }
}
