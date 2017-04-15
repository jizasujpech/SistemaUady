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

namespace CPresentacion
{
    public partial class FiltroProblematica : Form
    {
        EEstudiante ObjEntidadEstudiante;
        EEmpleado ObjEntidadEmpleado;
        bool bObjetoRegistroLleno;

        public FiltroProblematica()
        {
            InitializeComponent();
            ObjEntidadEstudiante = new EEstudiante();
            ObjEntidadEmpleado = new EEmpleado();
            bObjetoRegistroLleno = false;
        }

        #region EVENTO LOAD
        private void FiltroProblematica_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportesUADYDataSet1.Tipo' Puede moverla o quitarla según sea necesario.
            this.tipoTableAdapter.Fill(this.reportesUADYDataSet1.Tipo);
        }
        #endregion
        #region EVENTO CLICK BOTON BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        #endregion
        #region FUNCION BUSCAR
        private void buscar()
        {
            if (validacionCamposBusqueda())
            {
                if (!String.IsNullOrEmpty(txtTipo1.Text))
                    buscarXClave();
                else
                    buscarXNombre();
            }
            else
                MessageBox.Show("No se encuentran los elementos suficientes para realizar la búsqueda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        #region BUSCAR POR NOMBRE
        private void buscarXNombre()
        {           

            switch (cmbTipo.SelectedIndex)
            { 
                case 0:
                    {
                        ObjEntidadEmpleado.Nombre = txtNombre.Text;
                        ObjEntidadEmpleado.Apellido1 = txtApellido1.Text;
                        ObjEntidadEmpleado.Apellido2 = txtApellido2.Text; 

                        llenaControlesEmpleado();
                        break;
                    }

                case 1:
                    {
                        ObjEntidadEstudiante.Nombre = txtNombre.Text;
                        ObjEntidadEstudiante.Apellido1 = txtApellido1.Text;
                        ObjEntidadEstudiante.Apellido2 = txtApellido2.Text; 

                        llenaControlesEstudiante();
                        break;
                    }
            }
        }
           
            #endregion        
        #region BUSCAR POR CLAVE O MATRICULA
        private void buscarXClave()
        {
            if (string.IsNullOrEmpty(txtTipo1.Text)) return;

            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        ObjEntidadEmpleado.ClaveEmpleado = txtTipo1.Text;
                        llenaControlesEmpleado();
                        break;
                    }
                case 1:
                    {
                        ObjEntidadEstudiante.Matricula = txtTipo1.Text;
                        llenaControlesEstudiante();
                        break;
                    }
            }
        }
        #endregion
        #region VALIDACION CAMPOS PARA LA BUSQUEDA
        private bool validacionCamposBusqueda()
        {
            bool result = true;

            if (String.IsNullOrEmpty(txtTipo1.Text) && (String.IsNullOrEmpty(txtNombre.Text)) && (String.IsNullOrEmpty(txtApellido1.Text)) && (String.IsNullOrEmpty(txtApellido2.Text)))
                result = false;

           return result;
        }
        #endregion
        #region LLENA CONTROLES DEL ESTUDIANTE
        private void llenaControlesEstudiante()
        {
            NEstudiante objNEstudiante = new NEstudiante(ObjEntidadEstudiante);
            ObjEntidadEstudiante = objNEstudiante.getDatosEstudiante();

            if (ObjEntidadEstudiante.IdEstudiante > 0)
            {
                txtTipo1.Text = ObjEntidadEstudiante.Matricula;
                txtTipo3.Text = ObjEntidadEstudiante.Licenciatura;
                txtTipo2.Text = ObjEntidadEstudiante.Escuela;
                txtTipo4.Text = ObjEntidadEstudiante.Semestre.ToString();

                txtNombre.Text = ObjEntidadEstudiante.Nombre;
                txtApellido1.Text = ObjEntidadEstudiante.Apellido1;
                txtApellido2.Text = ObjEntidadEstudiante.Apellido2;
                txtCorreo.Text = ObjEntidadEstudiante.Correo;
                txtTelefono.Text = ObjEntidadEstudiante.Telefono.ToString();
                btnModificar.Enabled = true;
                bObjetoRegistroLleno = true;
            }
            else
            {
                MessageBox.Show("El estudiante no se encuentra reistrado en el sistema");
                btnModificar.Enabled = false;
                bObjetoRegistroLleno = false;
                limpiarControles();
            }


        }
        #endregion
        #region LLENA CONTROLES DEL EMPLEADO
        private void llenaControlesEmpleado()
        {
            NEmpleado objNEmpleado = new NEmpleado(ObjEntidadEmpleado);
            //ObjEntidadEmpleado = objNEmpleado.getDatosEmpleado();

            llenaTablaConEmpleados();

            if (ObjEntidadEmpleado.IdEmpleado > 0)
            {
                txtTipo1.Text = ObjEntidadEmpleado.ClaveEmpleado;
                txtTipo2.Text = ObjEntidadEmpleado.Dependencia;
                txtTipo3.Text = ObjEntidadEmpleado.Area;
                txtTipo4.Text = ObjEntidadEmpleado.Puesto.ToString();

                txtNombre.Text = ObjEntidadEmpleado.Nombre;
                txtApellido1.Text = ObjEntidadEmpleado.Apellido1;
                txtApellido2.Text = ObjEntidadEmpleado.Apellido2;
                txtCorreo.Text = ObjEntidadEmpleado.Correo;
                txtTelefono.Text = ObjEntidadEmpleado.Telefono.ToString();
                btnModificar.Enabled = true;
                bObjetoRegistroLleno = true;
            }
            else
            {
                MessageBox.Show("El empleado no se encuentra reistrado en el sistema");
                btnModificar.Enabled = false;
                bObjetoRegistroLleno = false;
                limpiarControles();
            }


        }
        #endregion
        #region DELETE COLUMNAS INICIALES
        private void deleteColumnasIniciales()
        {
            if(dtgvActores.Columns.Contains("ColumnaClave"))
            dtgvActores.Columns.Remove("ColumnaClave");

            if (dtgvActores.Columns.Contains("ColumnaNombre"))
                dtgvActores.Columns.Remove("ColumnaNombre");

            if (dtgvActores.Columns.Contains("ColumnaApellido1"))
                dtgvActores.Columns.Remove("ColumnaApellido1");

            if (dtgvActores.Columns.Contains("ColumnaApellido2"))
                dtgvActores.Columns.Remove("ColumnaApellido2");

            if (dtgvActores.Columns.Contains("ColumnaDependencia"))
                dtgvActores.Columns.Remove("ColumnaDependencia");

            if (dtgvActores.Columns.Contains("ColumnaArea"))
                dtgvActores.Columns.Remove("ColumnaArea");

            if (dtgvActores.Columns.Contains("ColumnaPuesto"))
                dtgvActores.Columns.Remove("ColumnaPuesto");

            dtgvActores.Refresh();
        }
        #endregion
        #region OCULTA COLUMNAS ACTOR
        private void ocultaColumnasActor()
        {
            dtgvActores.Columns["Telefono"].Visible = false;
            dtgvActores.Columns["Correo"].Visible = false;
            dtgvActores.Columns["IdActor"].Visible = false;
            dtgvActores.Columns["IdActor1"].Visible = false;           
            dtgvActores.Columns["IdTipo"].Visible = false;


        }
        #endregion
        #region OCULTA COLUMNAS EMPLEADO
        private void ocultaColumnasEmpleado()
        {
            dtgvActores.Columns["IdEmpleado"].Visible = false;

        }
        #endregion
        #region ORDENA COLUMNAS EMPLEADO
        private void ordenaColumnasEmpleado()
        {
            dtgvActores.Columns["ClaveEmpleado"].DisplayIndex = 0;
            dtgvActores.Columns["ClaveEmpleado"].HeaderText = "Clave";

            dtgvActores.Columns["Nombre"].DisplayIndex = 1;

            dtgvActores.Columns["Apellido1"].DisplayIndex = 2;
            dtgvActores.Columns["Apellido1"].HeaderText = "Apellido P.";

            dtgvActores.Columns["Apellido2"].DisplayIndex = 3;
            dtgvActores.Columns["Apellido2"].HeaderText = "Apellido M.";

            dtgvActores.Columns["Dependencia"].DisplayIndex = 4;
            dtgvActores.Columns["Area"].DisplayIndex = 5;
            dtgvActores.Columns["Puesto"].DisplayIndex = 6;
        }
        #endregion
        #region LLENA TABLA CON EMPLEADOS
        private void llenaTablaConEmpleados()
        {
            NEmpleado objNEmpleado = new NEmpleado(ObjEntidadEmpleado);
            deleteColumnasIniciales();
            dtgvActores.DataSource = objNEmpleado.getDatosEmpleado_DataTable();
            ocultaColumnasActor();
            ocultaColumnasEmpleado();
            ordenaColumnasEmpleado();
        }
        #endregion
        #endregion

        #region EVENTO INDEX CHANGED COMBOBOX
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        lblTipo1.Text = "Clave";
                        lblTipo2.Text = "Dependencia";
                        lblTipo3.Text = "Area";
                        lblTipo4.Text = "Puesto";
                        determinaVisibilidadEtiquetas(true, true, true, true);
                        determinaVisibilidadTextBox(true, true, true, true);
                        break;
                    }
                case 1:
                    {
                        lblTipo1.Text = "Matricula";
                        lblTipo2.Text = "Escuela";
                        lblTipo3.Text = "Licenciatura";
                        lblTipo4.Text = "Semestre";
                        determinaVisibilidadEtiquetas(true, true, true, true);
                        determinaVisibilidadTextBox(true, true, true, true);
                        break;
                    }
                case 2:
                    {
                        lblTipo1.Text = "Parentesco";
                        determinaVisibilidadEtiquetas(true, false, false, false);
                        determinaVisibilidadTextBox(true, false, false, false);
                        break;
                    }
                case 3:
                default:
                    {
                        determinaVisibilidadEtiquetas(false, false, false, false);
                        determinaVisibilidadTextBox(false, false, false, false);
                        break;
                    }
            }
        }
        #endregion
        #region DETERMINA VISIBILIDAD
        private void determinaVisibilidadEtiquetas(bool L1, bool L2, bool L3, bool L4)
        {
            if (L1)
                lblTipo1.Visible = true;
            else
                lblTipo1.Visible = false;

            if (L2)
                lblTipo2.Visible = true;
            else
                lblTipo2.Visible = false;

            if (L3)
                lblTipo3.Visible = true;
            else
                lblTipo3.Visible = false;

            if (L4)
                lblTipo4.Visible = true;
            else
                lblTipo4.Visible = false;

        }


        private void determinaVisibilidadTextBox(bool T1, bool T2, bool T3, bool T4)
        {
            if (T1)
                txtTipo1.Visible = true;
            else
                txtTipo1.Visible = false;

            if (T2)
                txtTipo2.Visible = true;
            else
                txtTipo2.Visible = false;

            if (T3)
                txtTipo3.Visible = true;
            else
                txtTipo3.Visible = false;

            if (T4)
                txtTipo4.Visible = true;
            else
                txtTipo4.Visible = false;

        }

        #endregion
        #region EVENTO CLICK BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro que deseas modificar los datos?", "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                modificar();

        }
        #endregion
        #region FUNCION MODIFICAR 
        private void modificar()
        {
            llenaObjetosRegistro();
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        NEmpleado objNEmpleado = new NEmpleado(ObjEntidadEmpleado);

                        if (ObjEntidadEmpleado.IdEmpleado > 0)
                        {
                            if (objNEmpleado.actualizaDatosEmpleado())
                            {
                                MessageBox.Show("Datos actualizados correctamente");
                                bObjetoRegistroLleno = true;
                                // limpiarControles();
                            }
                               
                        }

                        break;
                    }
                case 1:
                    {
                        NEstudiante objNegocioEstudiante = new NEstudiante(ObjEntidadEstudiante);
                        if (ObjEntidadEstudiante.IdEstudiante > 0)
                        {
                            if (objNegocioEstudiante.actualizaDatosEstudiante())
                            {
                                MessageBox.Show("Datos actualizados correctamente");
                                bObjetoRegistroLleno = true;
                                // limpiarControles();
                            }
                                
                        }

                        break;
                    }
            }
        }

        #endregion
        #region LLENA LOS OBJETOS PARA EL REGISTRO
        private void llenaObjetosRegistro()
        {          
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        LlenaObjEmpleado();
                        break;
                    }
                case 1:
                    {

                        LlenaObjEstudiante();
                        break;
                    }
            }

            
        }
        #region Llenado Obj Estudiante
        private void LlenaObjEstudiante()
        {
            ObjEntidadEstudiante.Nombre = txtNombre.Text;
            ObjEntidadEstudiante.Apellido1 = txtApellido1.Text;
            ObjEntidadEstudiante.Apellido2 = txtApellido2.Text;
            ObjEntidadEstudiante.Telefono = Convert.ToInt64(txtTelefono.Text);
            ObjEntidadEstudiante.Correo = txtCorreo.Text;
            ObjEntidadEstudiante.Matricula = txtTipo1.Text;
            ObjEntidadEstudiante.Escuela = txtTipo2.Text;
            ObjEntidadEstudiante.Licenciatura = txtTipo3.Text;
            ObjEntidadEstudiante.Semestre = Convert.ToInt32(txtTipo4.Text);
           
        }
        #endregion
        #region Llenado Obj Empleado
        private void LlenaObjEmpleado()
        {
            ObjEntidadEmpleado.Nombre = txtNombre.Text;
            ObjEntidadEmpleado.Apellido1 = txtApellido1.Text;
            ObjEntidadEmpleado.Apellido2 = txtApellido2.Text;
            ObjEntidadEmpleado.Telefono = Convert.ToInt64(txtTelefono.Text);
            ObjEntidadEmpleado.Correo = txtCorreo.Text;
            ObjEntidadEmpleado.ClaveEmpleado = txtTipo1.Text;
            ObjEntidadEmpleado.Dependencia = txtTipo2.Text;
            ObjEntidadEmpleado.Area = txtTipo3.Text;
            ObjEntidadEmpleado.Puesto = txtTipo4.Text;
           
        }
        #endregion
        #endregion
        #region LIMPIAR CONTROLES
        private void limpiarControles()
        {           
            txtApellido1.Clear();
            txtApellido2.Clear();           
            txtCorreo.Clear();           
            txtNombre.Clear();           
            txtTelefono.Clear();           
            txtTipo1.Clear();
            txtTipo2.Clear();
            txtTipo3.Clear();
            txtTipo4.Clear();
            cmbTipo.SelectedIndex = 0;      
        }
        #endregion
        #region EVENTO CLICK BOTON REGISTRAR
        private void btnRegistrarSolicitud_Click(object sender, EventArgs e)
        {
            if (bObjetoRegistroLleno == false)
                llenaObjetosRegistro();

            callRegistrar();
        }
        #endregion
        #region LLAMAR A REGISTRAR
        private void callRegistrar()
        {
            
        }
        #endregion
        #region EVENTO CLICK GRID VIEW
        private void dtgvActores_Click(object sender, EventArgs e)
        {

            if (dtgvActores.CurrentRow != null)
            {
                getDatosActorFromGrid();
                switch(cmbTipo.SelectedIndex)
                {
                    case 0:
                        {
                            getDatosEmpleadoFromGrid();
                            break;
                        }
                    case 1:
                        {
                            break;
                        }
                }
            }
        }
        #region GET DATOS ACTOR FROM GRID
        private void getDatosActorFromGrid()
        {
            txtNombre.Text = dtgvActores.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido1.Text = dtgvActores.CurrentRow.Cells["Apellido1"].Value.ToString();
            txtApellido2.Text = dtgvActores.CurrentRow.Cells["Apellido2"].Value.ToString();
            txtTelefono.Text = dtgvActores.CurrentRow.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = dtgvActores.CurrentRow.Cells["Correo"].Value.ToString();
        }
        #endregion
        #region GET DATOS EMPLEADO FROM GRID
        private void getDatosEmpleadoFromGrid()
        {
            txtTipo1.Text = dtgvActores.CurrentRow.Cells["ClaveEmpleado"].Value.ToString();

            txtTipo2.Text = dtgvActores.CurrentRow.Cells["Dependencia"].Value.ToString();
            txtTipo3.Text = dtgvActores.CurrentRow.Cells["Puesto"].Value.ToString();
            txtTipo4.Text = dtgvActores.CurrentRow.Cells["Area"].Value.ToString();
        }
        #endregion
        #endregion


    }
}
