using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNegocio;
using CEntidades;
using Reportes;

namespace CPresentacion
{
    public partial class FiltroDeSeguimiento : Form
    {
        EProblematica objEntidadProblematica;
        EActor objEntidadActor;
        EAcceso objEntidadAcceso;
        
        public FiltroDeSeguimiento(EAcceso objEntidadAccesoRecibido)
        {
            InitializeComponent();
            objEntidadProblematica = new EProblematica();
            objEntidadActor = new EActor();
            this.objEntidadAcceso = objEntidadAccesoRecibido;
        }
        #region BUSCAR PROBLEMATICAS
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validacionCamposBusqueda(txtClaveSeguimiento.Text, txtNombre.Text, txtApellido1.Text, txtApellido2.Text))
            {
                int.TryParse(txtClaveSeguimiento.Text, out objEntidadProblematica.ClaveDeSeguimiento);
                objEntidadProblematica.idActor = 0;
                objEntidadActor.Nombre = txtNombre.Text;
                objEntidadActor.Apellido1 = txtApellido1.Text;
                objEntidadActor.Apellido2 = txtApellido2.Text;

                buscarProblematicas();
            }
            else
                MessageBox.Show("No se encuentran los elementos suficientes para realizar la búsqueda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buscarProblematicas()
        {
           /* if (validacionCamposBusqueda(txtClaveSeguimiento.Text, txtNombre.Text, txtApellido1.Text, txtApellido2.Text))
            {
                int.TryParse(txtClaveSeguimiento.Text, out objEntidadProblematica.ClaveDeSeguimiento);
                objEntidadActor.Nombre = txtNombre.Text;
                objEntidadActor.Apellido1 = txtApellido1.Text;
                objEntidadActor.Apellido2 = txtApellido2.Text; */

                NProblematica objNegocioProblematica = new NProblematica(objEntidadProblematica, objEntidadActor);
                
                DataTable dtProblematica = objNegocioProblematica.getProblematicas_DataTable();
                deleteColumnasIniciales();               
                dtgvProblematicas.DataSource = dtProblematica;
                ocultarColumnas();

                if (dtProblematica.Rows.Count > 0)              
                    getDatosFromGrid(0);                
                else
                    MessageBox.Show("No se encontraron registros", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

           /* }
            else
                MessageBox.Show("No se encuentran los elementos suficientes para realizar la búsqueda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);*/
        }
        #endregion
        #region VALIDACION CAMPOS PARA LA BUSQUEDA
        private bool validacionCamposBusqueda(string claveDeSeguimiento, string nombre, string apellido1, string apellido2)
        {
            bool result = true;

            if (String.IsNullOrEmpty(claveDeSeguimiento) && (String.IsNullOrEmpty(nombre)) && (String.IsNullOrEmpty(apellido1)) && (String.IsNullOrEmpty(apellido2)))
                result = false;

            return result;
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
        #region GET DATOS FROM GRID
        private void getDatosFromGrid(int numFila)
        {
            txtClaveSeguimiento.Text = dtgvProblematicas.Rows[numFila].Cells["ClaveDeSeguimiento"].Value.ToString();
            txtNombre.Text = dtgvProblematicas.Rows[numFila].Cells["Nombre"].Value.ToString();
            txtApellido1.Text = dtgvProblematicas.Rows[numFila].Cells["Apellido1"].Value.ToString();
            txtApellido2.Text = dtgvProblematicas.Rows[numFila].Cells["Apellido2"].Value.ToString();

            objEntidadProblematica.ClaveDeSeguimiento = Convert.ToInt32(dtgvProblematicas.Rows[numFila].Cells["ClaveDeSeguimiento"].Value.ToString());
            objEntidadProblematica.idActor = Convert.ToInt32(dtgvProblematicas.Rows[numFila].Cells["idActor"].Value.ToString());   
        }
        #endregion
        #region EVENTO CLICK GRID VIEW
        private void dtgvProblematicas_Click(object sender, EventArgs e)
        {
            if(dtgvProblematicas.Rows.Count > 0)
            getDatosFromGrid(dtgvProblematicas.CurrentCell.RowIndex);
        }
        #endregion
        #region EVENTO DOBLE CLICK
        private void dtgvProblematicas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dtgvProblematicas.Rows.Count > 0)
            {               
                frmActualizarProblematica objActualizarProblematica = new frmActualizarProblematica(objEntidadAcceso, objEntidadProblematica);
                objActualizarProblematica.ShowDialog();

                if(dtgvProblematicas.Rows.Count > 1) //Para que vuelva a buscar por nombre.
                {
                    objEntidadProblematica.ClaveDeSeguimiento = 0;
                    objEntidadProblematica.idActor = 0;
                }
                    

                buscarProblematicas();
                //this.Hide();
            }
        }

        #endregion
        #region MENU PRINCIPAL
        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal objMenuPrincipal = new frmMenuPrincipal(objEntidadAcceso);
            this.Close();
            objMenuPrincipal.Show();
        }
        #endregion
        #region BOTON IMPRIMIR
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgvProblematicas.Rows.Count <= 0) return;
                        
            frmReporteProblematicaBasica objReporteProblematicaBasico = new frmReporteProblematicaBasica(objEntidadProblematica.ClaveDeSeguimiento);
            objReporteProblematicaBasico.ShowDialog();
        }
        #endregion
    }
}
