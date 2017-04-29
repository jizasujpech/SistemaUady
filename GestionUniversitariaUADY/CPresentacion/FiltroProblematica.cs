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
        EActor ObjEntidadActor;        
        EAcceso objEntidadAcceso;

        string nombreBuscado;
        string apellidoPBuscado;
        string apellidoMBuscado;
        string telefonoBuscado;
        string correoBuscado;
        string tipo1Buscado;
        string tipo2Buscado;
        string tipo3Buscado;
        string tipo4Buscado;

        int idActor;

        //bool bYaBusco;
        //bool bYaActualizo;
        bool bActorRegistrado;

        public FiltroProblematica(EAcceso objEntidadAccesoRecibido)
        {
            InitializeComponent();
            ObjEntidadEstudiante = new EEstudiante();
            ObjEntidadEmpleado = new EEmpleado();
            ObjEntidadActor = new EActor();
            bActorRegistrado = false;
            this.objEntidadAcceso  = objEntidadAccesoRecibido;
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

                btnRegistrarSolicitud.Enabled = true;
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
                        ObjEntidadEmpleado.ClaveEmpleado = String.Empty;
                        ObjEntidadEmpleado.Nombre = txtNombre.Text;
                        ObjEntidadEmpleado.Apellido1 = txtApellido1.Text;
                        ObjEntidadEmpleado.Apellido2 = txtApellido2.Text; 

                        llenaControlesEmpleado();
                        break;
                    }

                case 1:
                    {
                        ObjEntidadEstudiante.Matricula = String.Empty;
                        ObjEntidadEstudiante.Nombre = txtNombre.Text;
                        ObjEntidadEstudiante.Apellido1 = txtApellido1.Text;
                        ObjEntidadEstudiante.Apellido2 = txtApellido2.Text; 

                        llenaControlesEstudiante();
                        break;
                    }

                 default:
                    {
                        ObjEntidadActor.Nombre = txtNombre.Text;
                        ObjEntidadActor.Apellido1 = txtApellido1.Text;
                        ObjEntidadActor.Apellido2 = txtApellido2.Text;
                        llenaControlesOtros();
                        break;
                    }
            }
        }
           
            #endregion        
        #region BUSCAR POR CLAVE O MATRICULA
        private void buscarXClave()
        {

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
            llenaTablaConEstudiantes();


            if (dtgvActores.RowCount >= 1)
            {
                getDatosActorFromGrid(0);
                getDatosEstudianteFromGrid(0);
                btnModificar.Enabled = true;
                bActorRegistrado = true;
                getDatosEncontrados();
            }
            else
            {
                MessageBox.Show("El estudiante no se encuentra reistrado en el sistema");
                btnModificar.Enabled = false;
                bActorRegistrado = false;
                //limpiarControles();
            }
        }
        #endregion
        #region LLENA CONTROLES DEL EMPLEADO
        private void llenaControlesEmpleado()
        {          
            llenaTablaConEmpleados();

            if ( dtgvActores.RowCount >= 1)
            {
                getDatosActorFromGrid(0);
                getDatosEmpleadoFromGrid(0);
                btnModificar.Enabled = true;
                bActorRegistrado = true;
                getDatosEncontrados();
            }
            else
            {
                MessageBox.Show("El empleado no se encuentra reistrado en el sistema");
                btnModificar.Enabled = false;
                bActorRegistrado = false;
                //limpiarControles();
            }


        }
        #endregion
        #region LLENA CONTROLES DEL USUARIO "OTRO"
        private void llenaControlesOtros()
        {
            llenaTablaConOtros();

            if (dtgvActores.RowCount >= 1)
            {
                getDatosActorFromGrid(0);
                btnModificar.Enabled = true;
                bActorRegistrado = true;
                getDatosEncontrados();
            }
            else
            {
                MessageBox.Show("El usuario no se encuentra registrado en el sistema");
                btnModificar.Enabled = false;
               bActorRegistrado = false;
                //limpiarControles();
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
            dtgvActores.Columns["IdTipo"].Visible = false;


        }
        #endregion
        #region OCULTA COLUMNAS EMPLEADO
        private void ocultaColumnasEmpleado()
        {
            dtgvActores.Columns["IdEmpleado"].Visible = false;
            dtgvActores.Columns["IdActor1"].Visible = false;

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
        #region LLENA TABLA CON ESTUDIANTES
        private void llenaTablaConEstudiantes()
        {
            NEstudiante objNegocioEstudiante = new NEstudiante(ObjEntidadEstudiante);
            deleteColumnasIniciales();
            dtgvActores.DataSource = objNegocioEstudiante.getDatosEstudiante_DataTable();
            ocultaColumnasActor();
            ocultaColumnasEstudiante();
            ordenaColumnasEstudiante();
        }
        #endregion

        #region LLENA TABLA OTROS
        private void llenaTablaConOtros()
        {
            deleteColumnasIniciales();
            NActor objNegocioActor = new NActor(ObjEntidadActor);
            dtgvActores.DataSource = objNegocioActor.getDatosActor_DataTable();
            ocultaColumnasActor();

        }
        #endregion
        #region OCULTA COLUMNAS ESTUDIANTE
        private void ocultaColumnasEstudiante()
        {
            dtgvActores.Columns["IdEstudiante"].Visible = false;
            dtgvActores.Columns["IdActor1"].Visible = false;
        }
        #endregion
        #region ORDENA COLUMNAS ESTUDIANTE
        private void ordenaColumnasEstudiante()
        {
            dtgvActores.Columns["Matricula"].DisplayIndex = 0;            

            dtgvActores.Columns["Nombre"].DisplayIndex = 1;

            dtgvActores.Columns["Apellido1"].DisplayIndex = 2;
            dtgvActores.Columns["Apellido1"].HeaderText = "Apellido P.";

            dtgvActores.Columns["Apellido2"].DisplayIndex = 3;
            dtgvActores.Columns["Apellido2"].HeaderText = "Apellido M.";

            dtgvActores.Columns["Escuela"].DisplayIndex = 4;
            dtgvActores.Columns["Licenciatura"].DisplayIndex = 5;
            dtgvActores.Columns["Semestre"].DisplayIndex = 6;
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

                        int licenciatura = 1;
                        if (!int.TryParse(txtTipo3.Text, out licenciatura))
                            txtTipo3.Text = "1";

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

            btnRegistrarSolicitud.Enabled = false;
            btnModificar.Enabled = false;
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
            {
                if(bDebeModificar())
                {
                    modificar();
                    buscar();
                }           
                    



                MessageBox.Show("Datos actualizados correctamente");
            }
                

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
                               // MessageBox.Show("Datos actualizados correctamente");                               
                                getDatosEncontrados();
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
                               // MessageBox.Show("Datos actualizados correctamente");                                                    
                                getDatosEncontrados();
                                // limpiarControles();
                            }
                                
                        }

                        break;
                    }
                default:
                    {
                        ObjEntidadActor.IdActor = Convert.ToInt32(dtgvActores.Rows[dtgvActores.CurrentCell.RowIndex].Cells["IdActor"].Value.ToString());

                        NActor objNegocioActor = new NActor(ObjEntidadActor);
                        if(ObjEntidadActor.IdActor > 0)
                        {
                            if(objNegocioActor.actualizaDatosActor())
                            {
                                //MessageBox.Show("Datos actualizados correctamente");                              
                                getDatosEncontrados();                              
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
                default:
                    {
                        llenaObjActor();
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
        #region LLENADO OBJETO ACTOR
        private void llenaObjActor()
        {
            ObjEntidadActor.Nombre = txtNombre.Text;
            ObjEntidadActor.Apellido1 = txtApellido1.Text;
            ObjEntidadActor.Apellido2 = txtApellido2.Text;
            ObjEntidadActor.Telefono = Convert.ToInt64(txtTelefono.Text);
            ObjEntidadActor.Correo = txtCorreo.Text;
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
            callRegistrar();
        }
        #endregion
        #region LLAMAR A REGISTRAR
        private void callRegistrar()
        {
            if (bActorRegistrado && bDebeModificar())   //Modificamos el actor si es necesario
                btnModificar.PerformClick();
            else if (!bActorRegistrado)   //Se le da de alta al usuario, si es un usuario que no se encuentra registrado 
            {
                llenaObjetosRegistro();
                insertDatosActor();
            }
               

            RegistroActor objRegistroActor;
            objRegistroActor = new RegistroActor(objEntidadAcceso, idActor);                    
            objRegistroActor.Show();
            this.Hide();
        }
        #endregion
        #region EVENTO CLICK GRID VIEW
        private void dtgvActores_Click(object sender, EventArgs e)
        {

            if (dtgvActores.CurrentRow != null)
            {
                getDatosActorFromGrid(dtgvActores.CurrentCell.RowIndex);
                switch(cmbTipo.SelectedIndex)
                {
                    case 0:
                        {
                            getDatosEmpleadoFromGrid(dtgvActores.CurrentCell.RowIndex);
                            break;
                        }
                    case 1:
                        {
                            getDatosEstudianteFromGrid(dtgvActores.CurrentCell.RowIndex);
                            break;
                        }                   
                }
                getDatosEncontrados();
            }
        }
        #region GET DATOS ACTOR FROM GRID
        private void getDatosActorFromGrid(int numFila)
        {

            idActor = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdActor"].Value.ToString());
            txtNombre.Text = dtgvActores.Rows[numFila].Cells["Nombre"].Value.ToString();
            txtApellido1.Text = dtgvActores.Rows[numFila].Cells["Apellido1"].Value.ToString();
            txtApellido2.Text = dtgvActores.Rows[numFila].Cells["Apellido2"].Value.ToString();
            txtTelefono.Text = dtgvActores.Rows[numFila].Cells["Telefono"].Value.ToString();
            txtCorreo.Text = dtgvActores.Rows[numFila].Cells["Correo"].Value.ToString();

            

            // txtNombre.Text = dtgvActores.CurrentRow.Cells["Nombre"].Value.ToString();

            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        ObjEntidadEmpleado.Nombre = dtgvActores.Rows[numFila].Cells["Nombre"].Value.ToString();
                        ObjEntidadEmpleado.Apellido1 = dtgvActores.Rows[numFila].Cells["Apellido1"].Value.ToString();
                        ObjEntidadEmpleado.Apellido2 = dtgvActores.Rows[numFila].Cells["Apellido2"].Value.ToString();
                        ObjEntidadEmpleado.Correo = dtgvActores.Rows[numFila].Cells["Correo"].Value.ToString();
                        ObjEntidadEmpleado.Telefono = Convert.ToInt64(dtgvActores.Rows[numFila].Cells["Telefono"].Value.ToString());
                        break;
                    }
                case 1:
                    {
                        ObjEntidadEstudiante.Nombre = dtgvActores.Rows[numFila].Cells["Nombre"].Value.ToString(); 
                        ObjEntidadEstudiante.Apellido1 = dtgvActores.Rows[numFila].Cells["Apellido1"].Value.ToString(); 
                        ObjEntidadEstudiante.Apellido2 = dtgvActores.Rows[numFila].Cells["Apellido2"].Value.ToString();
                        ObjEntidadEstudiante.Correo = dtgvActores.Rows[numFila].Cells["Correo"].Value.ToString(); 
                        ObjEntidadEstudiante.Telefono = Convert.ToInt64(dtgvActores.Rows[numFila].Cells["Telefono"].Value.ToString());
                        break;
                    }
                default:
                    {
                        ObjEntidadActor.Nombre = dtgvActores.Rows[numFila].Cells["Nombre"].Value.ToString();
                        ObjEntidadActor.Apellido1 = dtgvActores.Rows[numFila].Cells["Apellido1"].Value.ToString();
                        ObjEntidadActor.Apellido2 = dtgvActores.Rows[numFila].Cells["Apellido2"].Value.ToString();
                        ObjEntidadActor.Correo = dtgvActores.Rows[numFila].Cells["Correo"].Value.ToString();
                        ObjEntidadActor.Telefono = Convert.ToInt64(dtgvActores.Rows[numFila].Cells["Telefono"].Value.ToString());
                        break;
                    }
            }
           


        }
        #endregion
        #region GET DATOS EMPLEADO FROM GRID
        private void getDatosEmpleadoFromGrid(int numFila)
        {
            txtTipo1.Text = dtgvActores.Rows[numFila].Cells["ClaveEmpleado"].Value.ToString();
            txtTipo2.Text = dtgvActores.Rows[numFila].Cells["Dependencia"].Value.ToString();
            txtTipo3.Text = dtgvActores.Rows[numFila].Cells["Puesto"].Value.ToString();
            txtTipo4.Text = dtgvActores.Rows[numFila].Cells["Area"].Value.ToString();
            ObjEntidadEmpleado.IdActor = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdActor"].Value.ToString());
            ObjEntidadEmpleado.IdEmpleado = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdEmpleado"].Value.ToString());
            ObjEntidadEmpleado.ClaveEmpleado = dtgvActores.Rows[numFila].Cells["ClaveEmpleado"].Value.ToString();
            ObjEntidadEmpleado.Dependencia = dtgvActores.Rows[numFila].Cells["Dependencia"].Value.ToString();
            ObjEntidadEmpleado.Puesto = dtgvActores.Rows[numFila].Cells["Puesto"].Value.ToString();
            ObjEntidadEmpleado.Area = dtgvActores.Rows[numFila].Cells["Area"].Value.ToString();
        }
        #endregion
        #region GET DATOS ESTUDIANTE FROM GRID
        private void getDatosEstudianteFromGrid(int numFila)
        {
            txtTipo1.Text = dtgvActores.Rows[numFila].Cells["Matricula"].Value.ToString();
            txtTipo2.Text = dtgvActores.Rows[numFila].Cells["Escuela"].Value.ToString();
            txtTipo3.Text = dtgvActores.Rows[numFila].Cells["Licenciatura"].Value.ToString();
            txtTipo4.Text = dtgvActores.Rows[numFila].Cells["Semestre"].Value.ToString();

            ObjEntidadEstudiante.IdActor = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdActor"].Value.ToString());
            ObjEntidadEstudiante.IdEstudiante = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdEstudiante"].Value.ToString());
            ObjEntidadEstudiante.Matricula = dtgvActores.Rows[numFila].Cells["Matricula"].Value.ToString();
            ObjEntidadEstudiante.Escuela = dtgvActores.Rows[numFila].Cells["Escuela"].Value.ToString();
            ObjEntidadEstudiante.Licenciatura = dtgvActores.Rows[numFila].Cells["Licenciatura"].Value.ToString();
            ObjEntidadEstudiante.Semestre = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["Semestre"].Value.ToString());
        }
        #endregion
        #endregion
        #region DETERMINAR SI ES NECESARIO MODIFICAR
        private bool bDebeModificar()
        {
            bool result = false;

            if (txtNombre.Text != nombreBuscado)
                result = true;
            else if (txtApellido1.Text != apellidoPBuscado)
                result = true;
            else if (txtApellido2.Text != apellidoMBuscado)
                result = true;
            else if(txtCorreo.Text != correoBuscado)
                result = true;
            else if(txtTelefono.Text != telefonoBuscado)
                result = true;
            else if(txtTipo1.Text != tipo1Buscado)
                result = true;
            else if(txtTipo2.Text != tipo2Buscado)
                result = true;
            else if(txtTipo3.Text != tipo3Buscado)
                     result = true;
            else if(txtTipo4.Text != tipo4Buscado)
                result = true;

            return result;
        }
        #endregion
        #region GET DATOS BUSCADOS
        private void getDatosEncontrados()
        {
            switch(cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        nombreBuscado = ObjEntidadEmpleado.Nombre;
                        apellidoPBuscado = ObjEntidadEmpleado.Apellido1;
                        apellidoMBuscado = ObjEntidadEmpleado.Apellido2;
                        correoBuscado = ObjEntidadEmpleado.Correo;
                        telefonoBuscado = Convert.ToString(ObjEntidadEmpleado.Telefono);
                        tipo1Buscado = ObjEntidadEmpleado.ClaveEmpleado;
                        tipo2Buscado = ObjEntidadEmpleado.Dependencia;
                        tipo3Buscado = ObjEntidadEmpleado.Puesto;
                        tipo4Buscado = ObjEntidadEmpleado.Area;

                        break;
                    }
                case 1:
                    {
                        nombreBuscado = ObjEntidadEstudiante.Nombre;
                        apellidoPBuscado = ObjEntidadEstudiante.Apellido1;
                        apellidoMBuscado = ObjEntidadEstudiante.Apellido2;
                        correoBuscado = ObjEntidadEstudiante.Correo;
                        telefonoBuscado = Convert.ToString(ObjEntidadEstudiante.Telefono);
                        tipo1Buscado = ObjEntidadEstudiante.Matricula;
                        tipo2Buscado = ObjEntidadEstudiante.Escuela;
                        tipo3Buscado = ObjEntidadEstudiante.Licenciatura; 
                        tipo4Buscado = Convert.ToString(ObjEntidadEstudiante.Semestre);
                        break;
                    }
                default:
                    {
                        nombreBuscado = ObjEntidadActor.Nombre;
                        apellidoPBuscado = ObjEntidadActor.Apellido1;
                        apellidoMBuscado = ObjEntidadActor.Apellido2;
                        correoBuscado = ObjEntidadActor.Correo;
                        telefonoBuscado = Convert.ToString(ObjEntidadActor.Telefono);
                        break;
                    }

            }
        }
        #endregion
        #region ALTA DE DATOS DE LOS ACTORES
        private bool insertDatosActor()
        {
            bool result = false;
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        NEmpleado objNEmpleado = new NEmpleado(ObjEntidadEmpleado);                       
                        EEmpleado objEEmpleadoAlmacenado = new EEmpleado();
                        objEEmpleadoAlmacenado = objNEmpleado.almacenaDatosEmpleado();
                        idActor = objEEmpleadoAlmacenado.IdActor;
                        result = true;
                        MessageBox.Show("Empleado registrado correctamente");
                        break;
                    }
                case 1:
                    {
                        NEstudiante objNEstudiante = new NEstudiante(ObjEntidadEstudiante);                        
                        EEstudiante objEEstudianteAlmacenado = new EEstudiante();
                        objEEstudianteAlmacenado = objNEstudiante.almacenaDatosEstudiante();
                        idActor = objEEstudianteAlmacenado.IdActor;
                        result = true;
                        MessageBox.Show("Estudiante registrado correctamente");
                        break;
                    }
                case 3:
                    {
                        NActor ObjNActor = new NActor(ObjEntidadActor);
                        idActor   = ObjNActor.AlmacenaDatosActor();
                        result = true;
                        MessageBox.Show("Usuario registrado correctamente");
                        break;
                    }
            }             

            return result;

        }
        #endregion
    }
}
