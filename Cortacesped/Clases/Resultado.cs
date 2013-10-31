using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cortacesped.Clases
{
    /*
     * La clase Resultado se usará para ir cargando los valores
     * de las pruebas de los algoritmos. Estos valores serán
     * el alto y ancho del jardín, el numero de obstaculos, los
     * pasos que da el robot, el numero de parcelas para cortar,
     * el algoritmo empleado y el tiempo que tardó dicho algoritmo.
     */
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

        /*
         * Se sobreescribe la función Equals para poder comparar
         * los objetos Resultado en función de sus valores
         */
        public override bool Equals(object obj)
        {
            bool flag = true;
            if(obj is Resultado)
            {
                Resultado result = obj as Resultado;
                if(this.Algoritmo != result.Algoritmo)
                {
                    flag = false;
                }

                if(this.Alto != result.Alto)
                {
                    flag = false;
                }

                if(this.Ancho != result.Ancho)
                {
                    flag = false;
                }

                if(this.Obstaculos != result.Obstaculos)
                {
                    flag = false;
                }

                if(this.Parcelas != result.Parcelas)
                {
                    flag = false;
                }

                if(this.Pasos != result.Pasos)
                {
                    flag = false;
                }

                if(this.Tiempo != result.Tiempo)
                {
                    flag = false;
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        /*
         * Del mismo modo se sobreescribe la función GetHasCode
         */
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
