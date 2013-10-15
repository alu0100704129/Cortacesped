using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cortacesped.Clases
{
    class Configuracion
    {
        private Int32 m_Alto;
        private Int32 m_Ancho;
        private Boolean m_DimensionAuto;
        private Int32 m_PorcentajeObstaculos;
        private Boolean m_AutoObstaculos;

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

        public Int32 PorcentajeObstaculos
        {
            get { return m_PorcentajeObstaculos; }
            set { m_PorcentajeObstaculos = value; }
        }

        public Boolean AutoDimensiones
        {
            get { return m_DimensionAuto; }
            set { m_DimensionAuto = value; }
        }

        public Boolean AltoObstaculos
        {
            get { return m_AutoObstaculos; }
            set { m_AutoObstaculos = value; }
        }

    }
}
