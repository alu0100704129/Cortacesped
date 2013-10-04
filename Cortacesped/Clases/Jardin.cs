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
            if((filas > 6) && (filas < 15) && (columnas > 6) && (columnas < 15))
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

        public Boolean AddParcela(Parcela parcela)
        {
            Boolean flag = false;
            


            return flag;
        }





    }
}
