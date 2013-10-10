using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cortacesped.Clases
{
    public class Jardin
    {

        private Int32 m_Filas;
        private Int32 m_Columnas;
        private Parcela[,] m_Parcelas;
        
        public Jardin(Int32 filas, Int32 columnas)
        {
            if((filas > 4) && (filas < 201) && (columnas > 4) && (columnas < 201))
            {
                m_Filas = filas;
                m_Columnas = columnas;
            }
            else
            {
                m_Filas = 7;
                m_Columnas = 10;
            }

            m_Parcelas = new Parcela[m_Filas, m_Columnas];
                        
        }

        public Int32 Filas
        {
            get { return m_Filas; }
            set { m_Filas = value; }
        }

        public Int32 Columnas
        {
            get { return m_Columnas; }
            set { m_Columnas = value; }
        }

        public Parcela[,] Parcelas
        {
            get { return m_Parcelas; }
            set { m_Parcelas = value; }
        }

            
            
        




        

        private void ConstruirJardin()
        {



        }



    }
}
