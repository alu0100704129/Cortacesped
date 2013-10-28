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

        public Jardin(Jardin originalJardin)
        {
            m_Filas = originalJardin.Filas;
            m_Columnas = originalJardin.Columnas;

            m_Parcelas = new Parcela[m_Filas, m_Columnas];

            for(int fil = 0; fil < m_Filas; fil++)
            {
                for(int col = 0; col < m_Columnas; col++)
                {
                    Parcela p = new Parcela();
                    p.Fila = originalJardin.Parcelas[fil, col].Fila;
                    p.Columna = originalJardin.Parcelas[fil, col].Columna;
                    p.Tag = originalJardin.Parcelas[fil, col].Tag;
                    p.Image = originalJardin.Parcelas[fil, col].Image;
                    p.Name = originalJardin.Parcelas[fil, col].Name;
                    p.Size = originalJardin.Parcelas[fil, col].Size;
                    p.Location = originalJardin.Parcelas[fil, col].Location;
                    p.SizeMode = originalJardin.Parcelas[fil, col].SizeMode;
                    m_Parcelas[fil, col] = p;

                }
            }
        }
        
        public Jardin(Int32 filas, Int32 columnas)
        {
            if((filas > 4) && (filas < 101) && (columnas > 4) && (columnas < 101))
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
        
        public Jardin RestablecerJardin()
        {
            for(int fil = 0; fil < this.Filas; fil++)
            {
                for(int col = 0; col < this.Columnas; col++)
                {
                    if(this.Parcelas[fil, col].Tag.ToString() == "Cesped_Corto")
                    {
                        this.Parcelas[fil, col].Tag = "Cesped_Largo";
                        this.Parcelas[fil, col].Visitada = false;
                        this.Parcelas[fil, col].Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    }
                }
            }
            return this;
        }
        
    }
}
