using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cortacesped.Clases
{
    public class Resultado
    {
        private Int32 m_Alto;
        private Int32 m_Ancho;
        private Int32 m_Parcelas;
        private Int32 m_Obstaculos;
        private Int32 m_Pasos;
        private Int32 m_Tiempo;
        private String m_Algoritmo;


        public String Algoritmo
        {
            get { return m_Algoritmo; }
            set { m_Algoritmo = value; }
        }

        public Int32 Pasos
        {
            get { return m_Pasos; }
            set { m_Pasos = value; }
        }

        public Int32 Tiempo
        {
            get { return m_Tiempo; }
            set { m_Tiempo = value; }
        }

        public Int32 Obstaculos
        {
            get { return m_Obstaculos; }
            set { m_Obstaculos = value; }
        }

        public Int32 Parcelas
        {
            get { return m_Parcelas; }
            set { m_Parcelas = value; }
        }

        public Int32 Alto
        {
            get { return m_Alto; }
            set { m_Alto = value; }
        }

        public Int32 Ancho
        {
            get { return m_Ancho; }
            set { m_Ancho = value; }
        }

        

        

        

        
        

    }
}
