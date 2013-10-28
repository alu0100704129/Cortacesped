using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using ExcelApp = Microsoft.Office.Interop.Excel;
using Cortacesped.Clases;
using System.Reflection;

namespace Cortacesped
{
    public partial class FormConfig : Form
    {

        private Jardin jardin;
        private Robot m_Robot;
        private String m_Algoritmo;
        private Resultado resultado;
        private BindingList<Resultado> resultados;

        public FormConfig()
        {
            InitializeComponent();
            m_Algoritmo = "Profundidad";
            this.lbVelocidad.Text = this.tbVelocidad.Value.ToString() + "/ms";
            
            resultados = new BindingList<Resultado>();
            this.dgvResultados.DataSource = resultados;
        }

        private void ckAutoDimension_CheckedChanged(object sender, EventArgs e)
        {
            if(this.ckAutoDimension.Checked)
            {
                this.numericAlto.Enabled = false;
                this.numericAncho.Enabled = false;
            }
            else
            {
                this.numericAlto.Enabled = true;
                this.numericAncho.Enabled = true;
            }
        }

        private void ckManualObstaculos_CheckedChanged(object sender, EventArgs e)
        {
            if(this.ckManualObstaculos.Checked)
            {
                this.numericOstaculos.Enabled = false;
            }
            else
            {
                this.numericOstaculos.Enabled = true;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            InitializeJardin();
        }

        private void btnRepetir_Click(object sender, EventArgs e)
        {
            if(jardin != null)
            {
                RestablecerJardin();
                resultado = new Resultado();
                resultado.Algoritmo = m_Algoritmo;
                resultado.Alto = jardin.Filas;
                resultado.Ancho = jardin.Columnas;
                                
                FormJardin f = new FormJardin(ref jardin, ref m_Robot, m_Algoritmo, this.tbVelocidad.Value, ref resultado);
                this.Visible = false;
                f.ShowDialog(this);
                this.Visible = true;
                this.Text = "Configuración del jardin - " + m_Robot.Pasos.ToString() + " pasos.";

                resultado.Obstaculos = 0;
                foreach(Parcela p in jardin.Parcelas)
                {
                    if(p.Tag.ToString().Contains("Arbol"))
                    {
                        resultado.Obstaculos++;
                    }
                }

                resultado.Parcelas = (jardin.Filas * jardin.Columnas) - resultado.Obstaculos;
                resultado.Pasos += m_Robot.Pasos;

                resultados.Add(resultado);
                                
            }
        }

        private void RestablecerJardin()
        {
            for(int fil = 0; fil < jardin.Filas; fil++)
            {
                for(int col = 0; col < jardin.Columnas; col++)
                {
                    if(jardin.Parcelas[fil, col].Tag.ToString().Contains("Cesped"))
                    {
                        jardin.Parcelas[fil, col].Tag = "Cesped_Largo";
                        jardin.Parcelas[fil, col].Visitada = false;
                        jardin.Parcelas[fil, col].Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    }
                }
            }
            m_Robot.Fila = m_Robot.Origen.Fila;
            m_Robot.Columna = m_Robot.Origen.Columna;
            m_Robot.Pasos = 0;
            m_Robot.Location = new Point(m_Robot.Origen.Location.X, m_Robot.Origen.Location.Y);
            m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;
            
        }

        private void InitializeJardin()
        {
            Int32 fil, col;
            Random rnd;
            if(this.ckAutoDimension.Checked)
            {
                rnd = new Random(DateTime.Now.Millisecond);
                fil = rnd.Next(Int32.Parse(this.numericAlto.Minimum.ToString()), 
                    Int32.Parse((this.numericAlto.Maximum+1).ToString()));
                col = rnd.Next(Int32.Parse(this.numericAncho.Minimum.ToString()),
                    Int32.Parse((this.numericAncho.Maximum + 1).ToString()));
            }
            else
            {
                fil = Int32.Parse(this.numericAlto.Value.ToString());
                col = Int32.Parse(this.numericAncho.Value.ToString());
            }
            
            ConstruirJardin(fil, col, this.ckManualObstaculos.Checked);

            resultado = new Resultado();

            resultado.Algoritmo = m_Algoritmo;
            resultado.Alto = jardin.Filas;
            resultado.Ancho = jardin.Columnas;
            
            FormJardin f = new FormJardin(ref jardin, ref m_Robot, m_Algoritmo, this.tbVelocidad.Value, ref resultado);
            this.Visible = false;
            f.ShowDialog(this);
            
            this.Visible = true;
            this.Text = "Configuración del jardin - " + m_Robot.Pasos.ToString() + " pasos.";
            
            
            resultado.Obstaculos = 0;
            foreach(Parcela p in jardin.Parcelas)
            {
                if(p.Tag.ToString().Contains("Arbol"))
                {
                    resultado.Obstaculos++;
                }
            }
            resultado.Parcelas = (jardin.Filas * jardin.Columnas) - resultado.Obstaculos;
            resultado.Pasos += m_Robot.Pasos;
            resultados.Add(resultado);

            //this.dataGridView1.DataSource = resultados;
            //this.dataGridView1.Refresh();
            //this.Refresh();



        }

        private void ConstruirJardin(Int32 filas, Int32 columnas, Boolean obstaculosManual)
        {
            Int32 posX, posY, dimension;
            jardin = new Jardin(filas, columnas);
            Random rnd = new Random(DateTime.Now.Millisecond);
            Int32 tamJardin = filas * columnas;
            Decimal factor = (Decimal.Parse(this.numericOstaculos.Value.ToString()) / 100) * tamJardin;
            Int32 total = (Int32)factor;
            Int32 altoObjeto = ((Screen.PrimaryScreen.Bounds.Height-80) / filas);
            Int32 anchoObjeto = ((Screen.PrimaryScreen.Bounds.Width-40) / columnas);

            if(altoObjeto > anchoObjeto)
            {
                dimension = anchoObjeto;
            }
            else
            {
                dimension = altoObjeto;
            }      

            for(Int32 fil = 0; fil < jardin.Filas; fil++)
            {
                for(Int32 col = 0; col < jardin.Columnas; col++)
                {
                    // Creamos un NUEVO control que es un objeto de tipo Parcela que hereda de PictureBox
                    Parcela parcela = new Parcela();
                    
                    // Le asignamos las propiadades básicas al control teniendo en cuenta que es un PictureBox
                    parcela.Fila = fil;
                    parcela.Columna = col;
                    parcela.Name = "m_Parcelaf" + fil.ToString() + "c" + col.ToString();
                    parcela.Size = new Size(dimension, dimension);
                    parcela.Location = new Point(col * parcela.Size.Width, fil * parcela.Size.Height);
                    parcela.Tag = "Cesped_Largo";
                    parcela.Image = Cortacesped.Properties.Resources.Cesped_Largo;
                    parcela.SizeMode = PictureBoxSizeMode.StretchImage;
                    jardin.Parcelas[fil, col] = parcela;
                }
            }
            //jardin.Parcelas[0, 0].Tag = "Cesped_Corto";
            //jardin.Parcelas[0, 0].Image = Cortacesped.Properties.Resources.Cesped_Corto;
            //jardin.Parcelas[0, 0].Visitada = true;

            m_Robot = new Robot();
            m_Robot.Fila = 0;
            m_Robot.Columna = 0;
            m_Robot.Origen = jardin.Parcelas[0, 0];
            m_Robot.Destino = jardin.Parcelas[0, 0];
            m_Robot.Pasos = 0;
            m_Robot.Name = "Id_Robot";
            m_Robot.Tag = "Robot";
            m_Robot.Size = new Size(dimension, dimension);
            m_Robot.Location = new Point(0, 0);
            m_Robot.Image = Cortacesped.Properties.Resources.Robot_Right;
            m_Robot.SizeMode = PictureBoxSizeMode.StretchImage;
            m_Robot.Direccion = Robot.RobotDireccion.Derecha;
            
            // Si los obstáculos se calculan de forma automática
            if(!obstaculosManual)
            {
                while(total > 0)
                {
                    posX = rnd.Next(0, columnas);
                    posY = rnd.Next(0, filas);
                    if(jardin.Parcelas[posY, posX].Tag.ToString() == "Cesped_Largo")
                    {
                        jardin.Parcelas[posY, posX].Tag = "Arbol";
                        jardin.Parcelas[posY, posX].Image = Cortacesped.Properties.Resources.Arbol;
                        total -= 1;
                    }
                }
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb == null)
            {
                return;
            }
            else
            {
                m_Algoritmo = rb.Text;
                if(m_Algoritmo.Contains("Profundidad"))
                {
                    m_Algoritmo = "Profundidad";
                }
                else if(m_Algoritmo.Contains("Amplitud"))
                {
                    m_Algoritmo = "Amplitud";
                }
                else if(m_Algoritmo.Contains("Camino"))
                {
                    m_Algoritmo = "Camino";
                }
            }
        }

        private void tbVelocidad_Scroll(object sender, EventArgs e)
        {
            this.lbVelocidad.Text = this.tbVelocidad.Value.ToString() + "/ms";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            
            // Cambiar la referencia cultural antes de ejecutar el proceso
            //CultureInfo CurrentCI = Thread.CurrentThread.CurrentCulture;
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //ExcelApp.Application excel = new ExcelApp.Application();
            //ExcelApp.Workbook wrkBooks = excel.Workbooks.Add(Type.Missing);
            //excel.DisplayAlerts = false;


            Microsoft.Office.Interop.Excel.Application aplicacion;

            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();



            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

            hoja_trabajo.Application.ActiveWindow.DisplayGridlines = false;


            for(int i = 1; i < this.dgvResultados.Columns.Count + 1; i++)
            {
                hoja_trabajo.Cells[1, i] = this.dgvResultados.Columns[i - 1].HeaderText;
            }


            //Recorremos el DataGridView rellenando la hoja de trabajo
            for(int i = 0; i < this.dgvResultados.Rows.Count; i++)
            {
                for(int j = 0; j < this.dgvResultados.Columns.Count; j++)
                {
                    if(this.dgvResultados.Rows[i].Cells[j].Value != null)
                    {
                        hoja_trabajo.Cells[i + 2, j + 1] = this.dgvResultados.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            hoja_trabajo.Columns.AutoFit();
            
            ExcelApp.Range cabeceraRange, datosRange;
            cabeceraRange = hoja_trabajo.get_Range("A1", "G1");
            cabeceraRange.Font.Bold = true;
            cabeceraRange.Cells.HorizontalAlignment = HorizontalAlignment.Center;
            cabeceraRange.Cells.VerticalAlignment = HorizontalAlignment.Center;
            
            datosRange = hoja_trabajo.get_Range("B2", "G" + (this.dgvResultados.Rows.Count + 1).ToString());
            
            datosRange.Cells.HorizontalAlignment = HorizontalAlignment.Center;
            datosRange.Cells.VerticalAlignment = HorizontalAlignment.Center;

            //* Añadir un grafico al Excel.
            //Add a Chart for the selected data.

            ExcelApp.ChartObjects oChart;
                
            //wrkBooks = (ExcelApp._Workbook)ws.Parent;
            oChart = (ExcelApp.ChartObjects)hoja_trabajo.ChartObjects(Type.Missing);
            ExcelApp.ChartObject myChart = oChart.Add(320, 20, 400, 300);
            ExcelApp.Chart chartPage = myChart.Chart;

            ExcelApp.Range chartRange = hoja_trabajo.get_Range("A1", "G" + (this.dgvResultados.Rows.Count + 1).ToString());
            chartPage.SetSourceData(chartRange, Type.Missing);
            chartPage.ChartType = ExcelApp.XlChartType.xlCylinderColClustered;

            chartPage.Perspective = 0;
            chartPage.Rotation = 0;

            chartPage.PlotBy = ExcelApp.XlRowCol.xlColumns;
            

            aplicacion.Visible = true;
            aplicacion.UserControl = true;
            
            aplicacion = null;

            

            /*
            ExcelApp.Range oRange;
            oRange = ws.get_Range("A2", "A3");
            oRange.Font.Size = 22;
            oRange.Font.Shadow = true;
            */
            
            //ws.Cells[2, 1] = "Prueba 1.";
            //ws.Cells[3, 1] = "Prueba 2";

                        

            




        }

                
    }
}
