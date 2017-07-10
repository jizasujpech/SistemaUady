using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CEntidades;
using CNegocio;

namespace CPresentacion
{
    public partial class frmProblematicas : Form
    {
        EProblematica objEntidadProblematica;        
        #region CONSTRUCTOR
        public frmProblematicas(ref EProblematica objEntidadProblematicaRecibido)
        {
            InitializeComponent();
            this.objEntidadProblematica = objEntidadProblematicaRecibido;
                      NProblematica objNegocioProblematica = new NProblematica(objEntidadProblematicaRecibido);
            dtgvProblematicas.DataSource = objNegocioProblematica.getProblematicas_DataTable();
            deleteColumnasIniciales();
            ocultarColumnas();
        }
        #endregion
        #region GET DATOS FROM GRID
        private void dtgvProblematicas_DoubleClick(object sender, EventArgs e)
        {
            if (dtgvProblematicas.Rows.Count > 0)
            {
                getDatosFromGrid(dtgvProblematicas.CurrentCell.RowIndex);               
                this.Close();
            }
        }

        private void getDatosFromGrid(int numFila)
        {
            objEntidadProblematica.ClaveDeSeguimiento = Convert.ToInt32(dtgvProblematicas.Rows[numFila].Cells["ClaveDeSeguimiento"].Value.ToString());
            objEntidadProblematica.idActor = Convert.ToInt32(dtgvProblematicas.Rows[numFila].Cells["idActor"].Value.ToString());
            objEntidadProblematica.Seguimiento = dtgvProblematicas.Rows[numFila].Cells["Seguimiento"].Value.ToString();

            objEntidadProblematica.Situacion = dtgvProblematicas.Rows[numFila].Cells["Situacion"].Value.ToString();
            objEntidadProblematica.Fecha = Convert.ToDateTime(dtgvProblematicas.Rows[numFila].Cells["Fecha"].Value.ToString());
            objEntidadProblematica.Conclusion = dtgvProblematicas.Rows[numFila].Cells["conclusion"].Value.ToString();
            objEntidadProblematica.Comentarios = dtgvProblematicas.Rows[numFila].Cells["Comentarios"].Value.ToString();
            objEntidadProblematica.Tema = dtgvProblematicas.Rows[numFila].Cells["Tema"].Value.ToString();
            objEntidadProblematica.Semaforo = dtgvProblematicas.Rows[numFila].Cells["Semaforo"].Value.ToString();

            objEntidadProblematica.ObjEAcceso.IdUsuario =Convert.ToInt32(dtgvProblematicas.Rows[numFila].Cells["IdUsuario"].Value.ToString());
            objEntidadProblematica.ActoresInvolucrados = dtgvProblematicas.Rows[numFila].Cells["ActoresInvolucrados"].Value.ToString();
            objEntidadProblematica.Procedimiento = dtgvProblematicas.Rows[numFila].Cells["Procedimiento"].Value.ToString();
            objEntidadProblematica.ResponsableDeSolucion = dtgvProblematicas.Rows[numFila].Cells["ResponsableDeSolucion"].Value.ToString();
            objEntidadProblematica.Evaluacion = dtgvProblematicas.Rows[numFila].Cells["Evaluacion"].Value.ToString();
            objEntidadProblematica.Satisfaccion = dtgvProblematicas.Rows[numFila].Cells["Satisfaccion"].Value.ToString();
            objEntidadProblematica.Atendio = dtgvProblematicas.Rows[numFila].Cells["Atendio"].Value.ToString();
        }

        #endregion
        #region CERRAR
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region DELETE COLUMNAS INICIALES
        private void deleteColumnasIniciales()
        {
            if (dtgvProblematicas.Columns.Contains("ColumnaClave"))
                dtgvProblematicas.Columns.Remove("ColumnaClave");

            if (dtgvProblematicas.Columns.Contains("ColumnaTema"))
                dtgvProblematicas.Columns.Remove("ColumnaTema");

            if (dtgvProblematicas.Columns.Contains("ColumnaFecha"))
                dtgvProblematicas.Columns.Remove("ColumnaFecha");

            if (dtgvProblematicas.Columns.Contains("ColumnaSituacion"))
                dtgvProblematicas.Columns.Remove("ColumnaSituacion");

            if (dtgvProblematicas.Columns.Contains("ColumnaSeguimiento"))
                dtgvProblematicas.Columns.Remove("ColumnaSeguimiento");

            if (dtgvProblematicas.Columns.Contains("ColumnaComentarios"))
                dtgvProblematicas.Columns.Remove("ColumnaComentarios");

            if (dtgvProblematicas.Columns.Contains("ColumnaSemaforo"))
                dtgvProblematicas.Columns.Remove("ColumnaSemaforo");


        }
        #endregion
        #region OCULTAR COLUMNAS BUSQUEDA
        private void ocultarColumnas()
        {
            //Tabla problematica
            dtgvProblematicas.Columns["IdUsuario"].Visible = false;
            dtgvProblematicas.Columns["IdActor"].Visible = false;
            dtgvProblematicas.Columns["ActoresInvolucrados"].Visible = false;
            dtgvProblematicas.Columns["Procedimiento"].Visible = false;
            dtgvProblematicas.Columns["ResponsableDeSolucion"].Visible = false;
            dtgvProblematicas.Columns["Evaluacion"].Visible = false;
            dtgvProblematicas.Columns["Satisfaccion"].Visible = false;
            dtgvProblematicas.Columns["Atendio"].Visible = false;

            //Tabla actor
            dtgvProblematicas.Columns["IdActor1"].Visible = false;
            dtgvProblematicas.Columns["Nombre"].Visible = false;
            dtgvProblematicas.Columns["Apellido1"].Visible = false;
            dtgvProblematicas.Columns["Apellido2"].Visible = false;
            dtgvProblematicas.Columns["telefono"].Visible = false;
            dtgvProblematicas.Columns["Correo"].Visible = false;
            dtgvProblematicas.Columns["idTipo"].Visible = false; 
        }
        #endregion


    }
}
