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
        EPadreDeFamilia objEntidadPadreFamilia;
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

        string nombreEstudianteBuscado;
        string apellidoPEstudianteBuscado;
        string apellidoMEstudianteBuscado;
        string telefonoEstudianteBuscado;
        string correoEstudianteBuscado;
        string matriculaEstudianteBuscado;
        string escuelaEstudianteBuscado;
        string licenciaturaEstudianteBuscado;
        string semestreEstudianteBuscado;

        int idActor;

        //bool bYaBusco;
        //bool bYaActualizo;
        bool bActorRegistrado;
        bool bEstudianteRegistrado;
        #region CONSTRUCTOR
        public FiltroProblematica(EAcceso objEntidadAccesoRecibido)
        {
            InitializeComponent();
            ObjEntidadEstudiante = new EEstudiante();
            ObjEntidadEmpleado = new EEmpleado();
            ObjEntidadActor = new EActor();
            objEntidadPadreFamilia = new EPadreDeFamilia();
            bActorRegistrado = false;
            bEstudianteRegistrado = true;
            this.objEntidadAcceso  = objEntidadAccesoRecibido;
        }
        #endregion

        #region EVENTO LOAD
        private void FiltroProblematica_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportesUADYDataSet1.Tipo' Puede moverla o quitarla según sea necesario.
            this.tipoTableAdapter.Fill(this.reportesUADYDataSet1.Tipo);

            tabcDatos.TabPages.Remove(tabP2);
            
        }
        #endregion
        #region EVENTO CLICK BOTON BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tabcDatos.SelectedIndex == 0)
                buscar(txtTipo1.Text, txtNombre.Text, txtApellido1.Text, txtApellido2.Text);
            else
                buscarEstudiante(txtMatriculaEstudiante.Text, txtNombreEstudiante.Text, txtApellido1Estudiante.Text, txtApellido2Estudiante.Text);
        }
        #endregion

        #region FUNCION BUSCAR
        private void buscar(string tipo1, string nombre, string apellido1, string apellido2)
        {
            if (validacionCamposBusqueda(tipo1, nombre, apellido1, apellido2))
            {
               if (!String.IsNullOrEmpty(tipo1) && (cmbTipo.SelectedIndex != 2)) //Cuando se trata de un padre de familia, nos aseguramos de que no se invoque a la busqueda por clave
                    buscarXClave(txtTipo1.Text);
                else
                    buscarXNombre(nombre, apellido1, apellido2);

                btnRegistrarSolicitud.Enabled = true;
            }
            else
                MessageBox.Show("No se encuentran los elementos suficientes para realizar la búsqueda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        #region BUSCAR ESTUDIANTE
        private void buscarEstudiante(string matricula, string nombre, string apellido1, string apellido2)
        {
            if(validacionCamposBusqueda(matricula, nombre, apellido1, apellido2))
            {
                if (!String.IsNullOrEmpty(matricula))
                    buscarXClave(matricula);
                else
                    buscarXNombre(nombre, apellido1, apellido2);
            }
            else
                MessageBox.Show("No se encuentran los elementos suficientes para realizar la búsqueda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        #endregion
        #region BUSCAR POR NOMBRE
        private void buscarXNombre(string nombre, string apellido1, string apellido2)
        {           

            switch (cmbTipo.SelectedIndex)
            { 
                case 0:
                    {
                        ObjEntidadEmpleado.ClaveEmpleado = String.Empty;
                        ObjEntidadEmpleado.Nombre = nombre;
                        ObjEntidadEmpleado.Apellido1 = apellido1;
                        ObjEntidadEmpleado.Apellido2 = apellido2; 

                        llenaControlesEmpleado();
                        break;
                    }

                case 1:
                    {
                        ObjEntidadEstudiante.Matricula = String.Empty;
                        ObjEntidadEstudiante.Nombre = nombre;
                        ObjEntidadEstudiante.Apellido1 = apellido1;
                        ObjEntidadEstudiante.Apellido2 = apellido2; 

                        llenaControlesEstudiante();
                        break;
                    }
                case 2:
                    {
                        if(tabcDatos.SelectedIndex == 0)
                        {
                            objEntidadPadreFamilia.Nombre = nombre;
                            objEntidadPadreFamilia.Apellido1 = apellido1;
                            objEntidadPadreFamilia.Apellido2 = apellido2;
                            llenaControlesPadreFamilia();
                        }
                        else
                        {
                            ObjEntidadEstudiante.Nombre = nombre;
                            ObjEntidadEstudiante.Apellido1 = apellido1;
                            ObjEntidadEstudiante.Apellido2 = apellido2;
                            llenaControlesEstudiante();
                        }
                        
                        break;
                    }

                 default:
                    {
                        ObjEntidadActor.Nombre = nombre;
                        ObjEntidadActor.Apellido1 = apellido1;
                        ObjEntidadActor.Apellido2 = apellido2;
                        llenaControlesOtros();
                        break;
                    }
            }
        }
           
            #endregion        
        #region BUSCAR POR CLAVE O MATRICULA
        private void buscarXClave(string claveABuscar)
        {

            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        ObjEntidadEmpleado.ClaveEmpleado = claveABuscar;
                        llenaControlesEmpleado();
                        break;
                    }
                case 1:
                case 2:  //Si llega con el case 2. Teoricamente solo pudo ser a través de la busqueda de la pestaña estudiante.
                    {
                        ObjEntidadEstudiante.Matricula = claveABuscar;
                        llenaControlesEstudiante();
                        break;
                    }
            }
        }
        #endregion
        #region VALIDACION CAMPOS PARA LA BUSQUEDA
        private bool validacionCamposBusqueda(string tipo1, string nombre, string apellido1, string apellido2)
        {
            bool result = true;

            if (String.IsNullOrEmpty(tipo1) && (String.IsNullOrEmpty(nombre)) && (String.IsNullOrEmpty(apellido1)) && (String.IsNullOrEmpty(apellido2)))
                result = false;

           return result;
        }
        #endregion
        #region LLENA CONTROLES DEL ESTUDIANTE
        private void llenaControlesEstudiante()
        {
            llenaTablaConEstudiantes();
            //return;

            if(tabcDatos.SelectedIndex == 0)
            {
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
                    bEstudianteRegistrado = false;
                    ObjEntidadEstudiante.IdEstudiante = 0;
                    //limpiarControles();
                }
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
                MessageBox.Show("El empleado no se encuentra registrado en el sistema");
                btnModificar.Enabled = false;
                bActorRegistrado = false;
                ObjEntidadEmpleado.IdEmpleado = 0;
                //limpiarControles();
            }


        }
        #endregion
        #region LLENA CONTROLES DEL PADRE DE FAMILIA
        private void llenaControlesPadreFamilia()
        {
            llenaTablaConPadreDeFamilia();

            if (dtgvActores.RowCount >= 1)
            {
                getDatosActorFromGrid(0);
                getDatosPadreFamiliaFromGrid(0);
                btnModificar.Enabled = true;
                bActorRegistrado = true;
                getDatosEncontrados();

                if (dtgvEstudiantes.RowCount >= 1)
                    btnModificarEstudiante.Enabled = true;
            }
            else
            {
                MessageBox.Show("El Padre de familia no se encuentra registrado en el sistema");
                btnModificar.Enabled = false;
                btnModificarEstudiante.Enabled = false;
                bActorRegistrado = false;
                objEntidadPadreFamilia.IdActor = 0;
                objEntidadPadreFamilia.IdPadre = 0;
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
                ObjEntidadActor.IdActor = 0;
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


            if (dtgvEstudiantes.Columns.Contains("ColumnaClaveEstudiante"))
                dtgvEstudiantes.Columns.Remove("ColumnaClaveEstudiante");

            if (dtgvEstudiantes.Columns.Contains("ColumnaNombreEstudiante"))
                dtgvEstudiantes.Columns.Remove("ColumnaNombreEstudiante");

            if (dtgvEstudiantes.Columns.Contains("ColumnaApellido1Estudiante"))
                dtgvEstudiantes.Columns.Remove("ColumnaApellido1Estudiante");

            if (dtgvEstudiantes.Columns.Contains("ColumnaApellido2Estudiante"))
                dtgvEstudiantes.Columns.Remove("ColumnaApellido2Estudiante");

            if (dtgvEstudiantes.Columns.Contains("ColumnaDependenciaEstudiante"))
                dtgvEstudiantes.Columns.Remove("ColumnaDependenciaEstudiante");

            if (dtgvEstudiantes.Columns.Contains("ColumnaAreaEstudiante"))
                dtgvEstudiantes.Columns.Remove("ColumnaAreaEstudiante");

            if (dtgvEstudiantes.Columns.Contains("ColumnaPuestoEstudiante"))
                dtgvEstudiantes.Columns.Remove("ColumnaPuestoEstudiante");

            dtgvEstudiantes.Refresh();
        }
        #endregion
        #region OCULTA COLUMNAS ACTOR
        private void ocultaColumnasActor()
        {
            if (dtgvActores.Columns.Contains("Telefono"))
                dtgvActores.Columns["Telefono"].Visible = false;

            if (dtgvActores.Columns.Contains("Correo"))
                dtgvActores.Columns["Correo"].Visible = false;

            if (dtgvActores.Columns.Contains("IdActor"))
                dtgvActores.Columns["IdActor"].Visible = false;

            if (dtgvActores.Columns.Contains("IdTipo"))
                dtgvActores.Columns["IdTipo"].Visible = false;

           if(cmbTipo.SelectedIndex == 2)  //Segundo pestaña. Únicamente padre de familia
            {
                dtgvEstudiantes.Columns["Telefono"].Visible = false;
                dtgvEstudiantes.Columns["Correo"].Visible = false;
                dtgvEstudiantes.Columns["IdActor"].Visible = false;
                dtgvEstudiantes.Columns["IdTipo"].Visible = false;
            }


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
        #region OCULTA COLUMNAS ESTUDIANTE
        private void ocultaColumnasEstudiante()
        {
            if(tabcDatos.SelectedIndex == 0)
            {
                dtgvActores.Columns["IdEstudiante"].Visible = false;
                dtgvActores.Columns["IdActor1"].Visible = false;
            }
            else
            {
                dtgvEstudiantes.Columns["IdEstudiante"].Visible = false;
                dtgvEstudiantes.Columns["IdActor1"].Visible = false;
            }

            
        }
        #endregion
        #region ORDENA COLUMNAS ESTUDIANTE
        private void ordenaColumnasEstudiante()
        {
            if(tabcDatos.SelectedIndex == 0)
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
            else
            {
                dtgvEstudiantes.Columns["Matricula"].DisplayIndex = 0;

                dtgvEstudiantes.Columns["Nombre"].DisplayIndex = 1;

                dtgvEstudiantes.Columns["Apellido1"].DisplayIndex = 2;
                dtgvEstudiantes.Columns["Apellido1"].HeaderText = "Apellido P.";

                dtgvEstudiantes.Columns["Apellido2"].DisplayIndex = 3;
                dtgvEstudiantes.Columns["Apellido2"].HeaderText = "Apellido M.";

                dtgvEstudiantes.Columns["Escuela"].DisplayIndex = 4;
                dtgvEstudiantes.Columns["Licenciatura"].DisplayIndex = 5;
                dtgvEstudiantes.Columns["Semestre"].DisplayIndex = 6;
            }
           
        }
        #endregion
        #region OCULTA COLUMNAS PADRE DE FAMILIA
        private void ocultaColumnasPadreFamilia()
        {
                dtgvActores.Columns["IdEstudiante"].Visible = false;
                dtgvActores.Columns["IdEstudiante1"].Visible = false;
                dtgvActores.Columns["IdPadre"].Visible = false;
                dtgvActores.Columns["IdActor1"].Visible = false;
                dtgvActores.Columns["IdActor2"].Visible = false;
                dtgvActores.Columns["IdActor3"].Visible = false;
                dtgvActores.Columns["IdTipo1"].Visible = false;
                dtgvActores.Columns["Escuela"].Visible = false;
                dtgvActores.Columns["Licenciatura"].Visible = false;
                dtgvActores.Columns["Semestre"].Visible = false;
                dtgvActores.Columns["Matricula"].Visible = false;

                dtgvActores.Columns["Nombre1"].Visible = false;
                dtgvActores.Columns["Apellido21"].Visible = false;
                dtgvActores.Columns["Apellido11"].Visible = false;
                dtgvActores.Columns["Telefono1"].Visible = false;
                dtgvActores.Columns["Correo1"].Visible = false;
           
          

            //Segunda pestaña
            dtgvEstudiantes.Columns["IdEstudiante"].Visible = false;
            dtgvEstudiantes.Columns["IdEstudiante1"].Visible = false;
            dtgvEstudiantes.Columns["IdPadre"].Visible = false;
            dtgvEstudiantes.Columns["IdActor1"].Visible = false;
            dtgvEstudiantes.Columns["IdActor2"].Visible = false;
            dtgvEstudiantes.Columns["IdActor3"].Visible = false;
            dtgvEstudiantes.Columns["IdTipo1"].Visible = false;

            dtgvEstudiantes.Columns["Nombre"].Visible = false;
            dtgvEstudiantes.Columns["Apellido2"].Visible = false;
            dtgvEstudiantes.Columns["Apellido1"].Visible = false;
            dtgvEstudiantes.Columns["Telefono"].Visible = false;
            dtgvEstudiantes.Columns["Correo"].Visible = false;
            dtgvEstudiantes.Columns["Telefono1"].Visible = false;
            dtgvEstudiantes.Columns["Correo1"].Visible = false;

        }
        #endregion
        #region ORDENA COLUMNAS PADRE DE FAMILIA
        private void ordenaColumnasPadreFamilia()
        {          
            dtgvActores.Columns["Nombre"].DisplayIndex = 0;

            dtgvActores.Columns["Apellido1"].DisplayIndex = 1;
            dtgvActores.Columns["Apellido1"].HeaderText = "Apellido P.";

            dtgvActores.Columns["Apellido2"].DisplayIndex = 2;
            dtgvActores.Columns["Apellido2"].HeaderText = "Apellido M.";

            dtgvActores.Columns["Parentesco"].DisplayIndex = 3;

            //Segunda Pestaña
            dtgvEstudiantes.Columns["Matricula"].DisplayIndex = 0;

            dtgvEstudiantes.Columns["Nombre1"].DisplayIndex = 1;
            dtgvEstudiantes.Columns["Nombre1"].HeaderText = "Nombre";

            dtgvEstudiantes.Columns["Apellido11"].DisplayIndex = 2;
            dtgvEstudiantes.Columns["Apellido11"].HeaderText = "Apellido P.";

            dtgvEstudiantes.Columns["Apellido21"].DisplayIndex = 3;
            dtgvEstudiantes.Columns["Apellido21"].HeaderText = "Apellido M.";

            dtgvEstudiantes.Columns["Escuela"].DisplayIndex = 4;
            dtgvEstudiantes.Columns["Licenciatura"].DisplayIndex = 5;
            dtgvEstudiantes.Columns["Semestre"].DisplayIndex = 6;
            dtgvEstudiantes.Columns["Parentesco"].DisplayIndex = 7;

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

            if (tabcDatos.SelectedIndex == 0)
            {
               
                dtgvActores.DataSource = objNegocioEstudiante.getDatosEstudiante_DataTable();
                //ocultaColumnasActor();
                //ocultaColumnasEstudiante();
                //ordenaColumnasEstudiante();
            }
            else
            {
                DataTable dtEstudiante = objNegocioEstudiante.getDatosEstudiante_DataTable();

                if (dtEstudiante.Rows.Count > 0)
                {
                    dtgvEstudiantes.DataSource = dtEstudiante;
                    //ocultaColumnasActor();
                    //ocultaColumnasEstudiante();
                    //ordenaColumnasEstudiante();


                    getDatosActorFromGrid(0);
                    getDatosPadreFamiliaFromGrid(0);
                    btnModificarEstudiante.Enabled = true;
                    bActorRegistrado = true;
                    getDatosEncontrados();
                }
                    
                else
                {
                    MessageBox.Show("El estudiante no se encuentra reistrado en el sistema");
                    btnModificarEstudiante.Enabled = false;
                    bActorRegistrado = false;
                    objEntidadPadreFamilia.IdEstudiante = 0;

                }

            }

            ocultaColumnasActor();
            ocultaColumnasEstudiante();
            ordenaColumnasEstudiante();

        }
        #endregion

        #region LLENA TABLA PADRE DE FAMILIA
        private void llenaTablaConPadreDeFamilia()
        {
            deleteColumnasIniciales();
            NPadredeFamilia objNegocioPadreFamilia = new NPadredeFamilia(objEntidadPadreFamilia);
            DataTable dttPadreFamilia = objNegocioPadreFamilia.getDatosPadreFamilia_DataTable();
            dtgvActores.DataSource = dttPadreFamilia; //DataGridView Principal
            dtgvEstudiantes.DataSource = dttPadreFamilia; //DataGridView Estudiante. Segunda pestaña de padres de familia.

            ocultaColumnasActor();
            ocultaColumnasPadreFamilia();
            ordenaColumnasPadreFamilia();


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
                        tabcDatos.TabPages.Remove(tabP2);
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

                        int licenciatura = 0;
                        if (!int.TryParse(lblTipo4.Text, out licenciatura))
                            txtTipo3.Text = "0";

                        tabcDatos.TabPages.Remove(tabP2);
                        break;
                    }
                case 2:
                    {
                        lblTipo1.Text = "Parentesco";
                        determinaVisibilidadEtiquetas(true, false, false, false);
                        determinaVisibilidadTextBox(true, false, false, false);
                        tabcDatos.TabPages.Add(tabP2);
                       
                        break;
                    }
                case 3:
                default:
                    {
                        determinaVisibilidadEtiquetas(false, false, false, false);
                        determinaVisibilidadTextBox(false, false, false, false);
                        tabcDatos.TabPages.Remove(tabP2);
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
                    buscar(txtTipo1.Text, txtNombre.Text, txtApellido1.Text, txtApellido2.Text);                   
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
                    case 2:
                    {
                        NPadredeFamilia objNegocioEstudiante = new NPadredeFamilia(objEntidadPadreFamilia);
                        if (objEntidadPadreFamilia.IdPadre > 0)
                        {
                            if (objNegocioEstudiante.actualizaDatosPadreFamilia())

                                getDatosEncontrados();
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
                case 2:
                    {
                        llenaObjPadreFamilia();
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

        #region LLENA OBJETO PADRE DE FAMILIA
        private void llenaObjPadreFamilia()
        {
            objEntidadPadreFamilia.Nombre = txtNombre.Text;
            objEntidadPadreFamilia.Apellido1 = txtApellido1.Text;
            objEntidadPadreFamilia.Apellido2 = txtApellido2.Text;
            long.TryParse(txtTelefono.Text, out objEntidadPadreFamilia.Telefono);
            //objEntidadPadreFamilia.Telefono = Convert.ToInt64(txtTelefono.Text);
            objEntidadPadreFamilia.Correo = txtCorreo.Text;
            objEntidadPadreFamilia.Parentesco = txtTipo1.Text;

            objEntidadPadreFamilia.objEntidadEstudiante.Nombre = txtNombreEstudiante.Text;
            objEntidadPadreFamilia.objEntidadEstudiante.Apellido1 = txtApellido1Estudiante.Text;
            objEntidadPadreFamilia.objEntidadEstudiante.Apellido2 = txtApellido2Estudiante.Text;
            long.TryParse(txtTelefonoEstudiante.Text, out objEntidadPadreFamilia.objEntidadEstudiante.Telefono);
            objEntidadPadreFamilia.objEntidadEstudiante.Correo = txtCorreoEstudiante.Text;
            objEntidadPadreFamilia.objEntidadEstudiante.Matricula = txtMatriculaEstudiante.Text;
            objEntidadPadreFamilia.objEntidadEstudiante.Escuela = txtEscuelaEstudiante.Text;
            objEntidadPadreFamilia.objEntidadEstudiante.Licenciatura = txtLicenciaturaEstudiante.Text;
            int.TryParse(txtSemestreEstudiante.Text, out objEntidadPadreFamilia.objEntidadEstudiante.Semestre);
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
            else if (bEstudianteRegistrado && bDebeModificarEstudiante())
                btnModificarEstudiante.PerformClick();
            else if (!bActorRegistrado || (cmbTipo.SelectedIndex == 2 && (!bExisteRelacionPadreXEstudiante() || bEstudianteRegistrado == false)))   //Se le da de alta al usuario, si es un usuario que no se encuentra registrado 
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
                    case 2:
                        {
                            getDatosPadreFamiliaFromGrid(dtgvActores.CurrentCell.RowIndex);
                            break;
                        }                 
                }
                getDatosEncontrados();
            }
        }

        //Segunda pestaña
        private void dtgvEstudiantes_Click(object sender, EventArgs e)
        {
            getDatosActorFromGrid(dtgvEstudiantes.CurrentCell.RowIndex);
            getDatosPadreFamiliaFromGrid(dtgvEstudiantes.CurrentCell.RowIndex);
            btnModificarEstudiante.Enabled = true;
        }
        #region GET DATOS ACTOR FROM GRID
        private void getDatosActorFromGrid(int numFila)
        {
            if (dtgvActores.RowCount > 0 /*dtgvActores.Columns.Contains("IdActor") */)
            {

            
            idActor = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdActor"].Value.ToString());

            //if (dtgvActores.Columns.Contains("Nombre"))
            txtNombre.Text = dtgvActores.Rows[numFila].Cells["Nombre"].Value.ToString();

            //if (dtgvActores.Columns.Contains("Apellido1"))
            txtApellido1.Text = dtgvActores.Rows[numFila].Cells["Apellido1"].Value.ToString();

            //if (dtgvActores.Columns.Contains("Apellido2"))
            txtApellido2.Text = dtgvActores.Rows[numFila].Cells["Apellido2"].Value.ToString();

            //if (dtgvActores.Columns.Contains("Telefono"))
            txtTelefono.Text = dtgvActores.Rows[numFila].Cells["Telefono"].Value.ToString();

            //if (dtgvActores.Columns.Contains("Correo"))
            txtCorreo.Text = dtgvActores.Rows[numFila].Cells["Correo"].Value.ToString();
           }
            
           

            if(cmbTipo.SelectedIndex  == 2)
            {
                //idActor = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdActor"].Value.ToString());
                if (dtgvEstudiantes.Columns.Contains("Nombre1"))
                    txtNombreEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Nombre1"].Value.ToString();
                else
                    txtNombreEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Nombre"].Value.ToString();

                if (dtgvEstudiantes.Columns.Contains("Apellido11"))
                    txtApellido1Estudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Apellido11"].Value.ToString();
                else
                txtApellido1Estudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Apellido1"].Value.ToString();

                if (dtgvEstudiantes.Columns.Contains("Apellido21"))
                    txtApellido2Estudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Apellido21"].Value.ToString();
                else
                txtApellido2Estudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Apellido2"].Value.ToString();

                if (dtgvEstudiantes.Columns.Contains("Telefono1"))
                    txtTelefonoEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Telefono1"].Value.ToString();
                else
                txtTelefonoEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Telefono"].Value.ToString();

                if (dtgvEstudiantes.Columns.Contains("Correo1"))
                    txtCorreoEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Correo1"].Value.ToString();
                else
                txtCorreoEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Correo"].Value.ToString();
            }

            

            // txtNombre.Text = dtgvActores.CurrentRow.Cells["Nombre"].Value.ToString();

            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        ObjEntidadEmpleado.Nombre = dtgvEstudiantes.Rows[numFila].Cells["Nombre1"].Value.ToString();
                        ObjEntidadEmpleado.Apellido1 = dtgvEstudiantes.Rows[numFila].Cells["Apellido11"].Value.ToString();
                        ObjEntidadEmpleado.Apellido2 = dtgvEstudiantes.Rows[numFila].Cells["Apellido21"].Value.ToString();
                        ObjEntidadEmpleado.Correo = dtgvEstudiantes.Rows[numFila].Cells["Correo1"].Value.ToString();
                        ObjEntidadEmpleado.Telefono = Convert.ToInt64(dtgvEstudiantes.Rows[numFila].Cells["Telefono1"].Value.ToString());
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
                case 2:
                    {
                        if (dtgvActores.RowCount > 0 /*dtgvActores.Columns.Contains("Nombre")*/)
                        {
                            objEntidadPadreFamilia.Nombre = dtgvActores.Rows[numFila].Cells["Nombre"].Value.ToString();

                            //if (dtgvActores.Columns.Contains("Apellido1"))
                            objEntidadPadreFamilia.Apellido1 = dtgvActores.Rows[numFila].Cells["Apellido1"].Value.ToString();

                            //if (dtgvActores.Columns.Contains("Apellido2"))
                            objEntidadPadreFamilia.Apellido2 = dtgvActores.Rows[numFila].Cells["Apellido2"].Value.ToString();

                            //if (dtgvActores.Columns.Contains("Correo"))
                            objEntidadPadreFamilia.Correo = dtgvActores.Rows[numFila].Cells["Correo"].Value.ToString();

                            //if (dtgvActores.Columns.Contains("Telefono"))
                            objEntidadPadreFamilia.Telefono = Convert.ToInt64(dtgvActores.Rows[numFila].Cells["Telefono"].Value.ToString());
                        }


                        if (dtgvEstudiantes.Columns.Contains("Nombre1"))
                            objEntidadPadreFamilia.objEntidadEstudiante.Nombre = dtgvEstudiantes.Rows[numFila].Cells["Nombre1"].Value.ToString();
                        else
                            objEntidadPadreFamilia.objEntidadEstudiante.Nombre = dtgvEstudiantes.Rows[numFila].Cells["Nombre"].Value.ToString();

                        if (dtgvEstudiantes.Columns.Contains("Apellido11"))
                            objEntidadPadreFamilia.objEntidadEstudiante.Apellido1 = dtgvEstudiantes.Rows[numFila].Cells["Apellido11"].Value.ToString();
                        else
                            objEntidadPadreFamilia.objEntidadEstudiante.Apellido1 = dtgvEstudiantes.Rows[numFila].Cells["Apellido1"].Value.ToString();


                        if (dtgvEstudiantes.Columns.Contains("Apellido21"))
                            objEntidadPadreFamilia.objEntidadEstudiante.Apellido2 = dtgvEstudiantes.Rows[numFila].Cells["Apellido21"].Value.ToString();
                        else
                            objEntidadPadreFamilia.objEntidadEstudiante.Apellido2 = dtgvEstudiantes.Rows[numFila].Cells["Apellido2"].Value.ToString();

                        if (dtgvEstudiantes.Columns.Contains("Correo1"))
                            objEntidadPadreFamilia.objEntidadEstudiante.Correo = dtgvEstudiantes.Rows[numFila].Cells["Correo1"].Value.ToString();
                        else
                            objEntidadPadreFamilia.objEntidadEstudiante.Correo = dtgvEstudiantes.Rows[numFila].Cells["Correo"].Value.ToString();

                        if (dtgvEstudiantes.Columns.Contains("Telefono1"))
                            objEntidadPadreFamilia.objEntidadEstudiante.Telefono = Convert.ToInt64(dtgvEstudiantes.Rows[numFila].Cells["Telefono1"].Value.ToString());
                        else
                            objEntidadPadreFamilia.objEntidadEstudiante.Telefono = Convert.ToInt64(dtgvEstudiantes.Rows[numFila].Cells["Telefono"].Value.ToString());

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

            string semestre = dtgvActores.Rows[numFila].Cells["Semestre"].Value.ToString();


            if (!int.TryParse(semestre, out ObjEntidadEstudiante.Semestre))  //Si el estudiante, no tiene semestre en la BD. Por default le asignamos 0 al objeto
                ObjEntidadEstudiante.Semestre = 0;

            //ObjEntidadEstudiante.Semestre = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["Semestre"].Value.ToString());
        }
        #endregion
        #region GET DATOS PADRE DE FAMILIA FROM GRID
        private void getDatosPadreFamiliaFromGrid(int numFila)
        {
            if (dtgvActores.RowCount > 0 /*dtgvActores.Columns.Contains("IdActor")*/)
            {
                objEntidadPadreFamilia.IdActor = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdActor"].Value.ToString());

                //if (dtgvActores.Columns.Contains("IdPadre"))
                objEntidadPadreFamilia.IdPadre = Convert.ToInt32(dtgvActores.Rows[numFila].Cells["IdPadre"].Value.ToString());



                //if (dtgvActores.Columns.Contains("Parentesco"))
                objEntidadPadreFamilia.Parentesco = dtgvActores.Rows[numFila].Cells["Parentesco"].Value.ToString();

                //if (dtgvActores.Columns.Contains("Parentesco"))
                txtTipo1.Text = dtgvActores.Rows[numFila].Cells["Parentesco"].Value.ToString();
            }


            //Segunda pestaña

            //if (dtgvActores.Columns.Contains("IdActor1"))
            objEntidadPadreFamilia.objEntidadEstudiante.IdActor = Convert.ToInt32(dtgvEstudiantes.Rows[numFila].Cells["IdActor1"].Value.ToString());

            //if (dtgvActores.Columns.Contains("IdEstudiante"))
            objEntidadPadreFamilia.objEntidadEstudiante.IdEstudiante = Convert.ToInt32(dtgvEstudiantes.Rows[numFila].Cells["IdEstudiante"].Value.ToString());        

            if (dtgvEstudiantes.Columns.Contains("IdEstudiante"))
                objEntidadPadreFamilia.IdEstudiante = Convert.ToInt32(dtgvEstudiantes.Rows[numFila].Cells["IdEstudiante"].Value.ToString());

            if (dtgvEstudiantes.Columns.Contains("IdActor1"))
                ObjEntidadEstudiante.IdActor = Convert.ToInt32(dtgvEstudiantes.Rows[numFila].Cells["IdActor1"].Value.ToString());
            else
                ObjEntidadEstudiante.IdActor = Convert.ToInt32(dtgvEstudiantes.Rows[numFila].Cells["IdActor"].Value.ToString());

            //En teoria ninguno de estos necesita una validacion. Independientemente de la pestaña donde se realiza la busqueda, estas columnas siempre deben de existir
            ObjEntidadEstudiante.IdEstudiante = Convert.ToInt32(dtgvEstudiantes.Rows[numFila].Cells["IdEstudiante"].Value.ToString());
            objEntidadPadreFamilia.objEntidadEstudiante.Matricula = dtgvEstudiantes.Rows[numFila].Cells["Matricula"].Value.ToString();
            objEntidadPadreFamilia.objEntidadEstudiante.Escuela = dtgvEstudiantes.Rows[numFila].Cells["Escuela"].Value.ToString();
            objEntidadPadreFamilia.objEntidadEstudiante.Licenciatura = dtgvEstudiantes.Rows[numFila].Cells["Licenciatura"].Value.ToString();
            int.TryParse(dtgvEstudiantes.Rows[numFila].Cells["Semestre"].Value.ToString(), out objEntidadPadreFamilia.objEntidadEstudiante.Semestre);

            txtMatriculaEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Matricula"].Value.ToString();
            txtEscuelaEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Escuela"].Value.ToString();
            txtLicenciaturaEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Licenciatura"].Value.ToString();
            txtSemestreEstudiante.Text = dtgvEstudiantes.Rows[numFila].Cells["Semestre"].Value.ToString();
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
            else if(correoBuscado != null && txtCorreo.Text != correoBuscado)
                result = true;
            else if(telefonoBuscado != null && telefonoBuscado != "0" && txtTelefono.Text != telefonoBuscado)
                result = true;
            else if(tipo1Buscado != null && txtTipo1.Text != tipo1Buscado)               
                result = true;
            else if(tipo2Buscado != null && txtTipo2.Text != tipo2Buscado)                
                result = true;
            else if(tipo3Buscado != null && txtTipo3.Text != tipo3Buscado)                  
                   result = true;
            else if(tipo4Buscado != null && txtTipo4.Text != tipo4Buscado)                
                  result = true;

           // if (result == false && cmbTipo.SelectedIndex == 2)
           //     result = bDebeModificarEstudiante();

            return result;
        }
        #region DETERMINAR SI ES NECESARIO MODIFICAR - PESTAÑA ESTUDIANTE
        private bool bDebeModificarEstudiante()
        {
            bool result = false;

            if (txtNombreEstudiante.Text != nombreEstudianteBuscado)
                result = true;
            else if (txtApellido1Estudiante.Text != apellidoPEstudianteBuscado)
                result = true;
            else if (txtApellido2Estudiante.Text != apellidoMEstudianteBuscado)
                result = true;
            else if (correoEstudianteBuscado != null && txtCorreoEstudiante.Text != correoEstudianteBuscado)
                result = true;
            else if (telefonoEstudianteBuscado != null && txtTelefonoEstudiante.Text != telefonoEstudianteBuscado)
                result = true;
            else if (matriculaEstudianteBuscado != null && txtMatriculaEstudiante.Text != matriculaEstudianteBuscado)
                result = true;
            else if (escuelaEstudianteBuscado != null && txtEscuelaEstudiante.Text != escuelaEstudianteBuscado)
                result = true;
            else if (licenciaturaEstudianteBuscado != null && txtLicenciaturaEstudiante.Text != licenciaturaEstudianteBuscado)
                result = true;
            else if (semestreEstudianteBuscado != null && semestreEstudianteBuscado != "0" && txtSemestreEstudiante.Text != semestreEstudianteBuscado)
                result = true;

            return result;
        }
        #endregion
        #endregion
        #region GET DATOS ENCONTRADOS
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
                case 2:
                    {
                        nombreBuscado = objEntidadPadreFamilia.Nombre;
                        apellidoPBuscado = objEntidadPadreFamilia.Apellido1;
                        apellidoMBuscado = objEntidadPadreFamilia.Apellido2;
                        correoBuscado = objEntidadPadreFamilia.Correo;
                        telefonoBuscado = Convert.ToString(objEntidadPadreFamilia.Telefono);
                        tipo1Buscado = objEntidadPadreFamilia.Parentesco;

                        nombreEstudianteBuscado = objEntidadPadreFamilia.objEntidadEstudiante.Nombre;
                        apellidoPEstudianteBuscado = objEntidadPadreFamilia.objEntidadEstudiante.Apellido1;
                        apellidoMEstudianteBuscado = objEntidadPadreFamilia.objEntidadEstudiante.Apellido2;
                        correoEstudianteBuscado = objEntidadPadreFamilia.objEntidadEstudiante.Correo;
                        telefonoEstudianteBuscado = Convert.ToString(objEntidadPadreFamilia.objEntidadEstudiante.Telefono);
                        matriculaEstudianteBuscado = objEntidadPadreFamilia.objEntidadEstudiante.Matricula;
                        escuelaEstudianteBuscado = objEntidadPadreFamilia.objEntidadEstudiante.Escuela;
                        licenciaturaEstudianteBuscado = objEntidadPadreFamilia.objEntidadEstudiante.Licenciatura;
                        semestreEstudianteBuscado = Convert.ToString(objEntidadPadreFamilia.objEntidadEstudiante.Semestre);

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
                case 2:
                    {
                        NPadredeFamilia objNegocioPadreFamilia = new NPadredeFamilia(objEntidadPadreFamilia);
                        EPadreDeFamilia objEPadreFamiliaAlmacenado = new EPadreDeFamilia();
                        objEPadreFamiliaAlmacenado = objNegocioPadreFamilia.almacenaDatosPadreFamilia();
                        idActor = objEPadreFamiliaAlmacenado.IdActor;
                        result = true;
                        MessageBox.Show("Padre de familia agregado correctamente");
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
        #region EVENTO CLICK BOTON LIMPIAR
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        #endregion
        #region CODIGO PARA LA PESTAÑA ESTUDIANTE
        private void btnModificarEstudiante_Click(object sender, EventArgs e)
        {
            modificarEstudiante();
        }
        #region MODIFICAR ESTUDIANTE
        private void modificarEstudiante()
        {

            DialogResult dialogResult = MessageBox.Show("¿Estás seguro que deseas modificar los datos del estudiante?", "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (bDebeModificarEstudiante())
                {
                    LlenaObjPestañaEstudiante();
                    NEstudiante objNegocioEstudiante = new NEstudiante(ObjEntidadEstudiante);
                    if (ObjEntidadEstudiante.IdEstudiante > 0)
                    {
                        if (objNegocioEstudiante.actualizaDatosEstudiante())
                            getDatosEncontradosEstudiante();                         
                       

                    }
                    buscar(txtTipo1.Text, txtNombre.Text, txtApellido1.Text, txtApellido2.Text);
                }




                MessageBox.Show("Datos actualizados correctamente");
            }      
           
        }
        #endregion
        #region LLENA OBJETO PESTAÑA ESTUDIANTE
        private void LlenaObjPestañaEstudiante()
        {
            ObjEntidadEstudiante.Nombre = txtNombreEstudiante.Text;
            ObjEntidadEstudiante.Apellido1 = txtApellido1Estudiante.Text;
            ObjEntidadEstudiante.Apellido2 = txtApellido2Estudiante.Text;

            int telefonoEstudiante = 0;
            int.TryParse(txtTelefonoEstudiante.Text, out telefonoEstudiante);
            ObjEntidadEstudiante.Telefono = Convert.ToInt64(telefonoEstudiante);

            ObjEntidadEstudiante.Correo = txtCorreoEstudiante.Text;
            ObjEntidadEstudiante.Matricula = txtMatriculaEstudiante.Text;
            ObjEntidadEstudiante.Escuela = txtEscuelaEstudiante.Text;
            ObjEntidadEstudiante.Licenciatura = txtLicenciaturaEstudiante.Text;

            int semestreEstudiante = 0;
            int.TryParse(txtSemestreEstudiante.Text, out semestreEstudiante);
            ObjEntidadEstudiante.Semestre = Convert.ToInt32(semestreEstudiante);

        }
        #endregion
 
        #region GET DATOS ENCONTRADOS ESTUDIANTE
        private void getDatosEncontradosEstudiante()
        {
            nombreEstudianteBuscado = ObjEntidadEstudiante.Nombre;
            apellidoPEstudianteBuscado = ObjEntidadEstudiante.Apellido1;
            apellidoMEstudianteBuscado = ObjEntidadEstudiante.Apellido2;
            correoEstudianteBuscado = ObjEntidadEstudiante.Correo;
            telefonoEstudianteBuscado = Convert.ToString(ObjEntidadEstudiante.Telefono);
            matriculaEstudianteBuscado = ObjEntidadEstudiante.Matricula;
            escuelaEstudianteBuscado = ObjEntidadEstudiante.Escuela;
            licenciaturaEstudianteBuscado = ObjEntidadEstudiante.Licenciatura;
            semestreEstudianteBuscado = Convert.ToString(ObjEntidadEstudiante.Semestre);
        }
        #endregion

        #endregion
        #region CAMBIAR ENTRE PESTAÑAS
        private void tabcDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabcDatos.SelectedIndex == 0)
                getDatosEncontrados();
            else
                getDatosEncontradosEstudiante();
        }
        #endregion
        #region VERIFICAR SI EXISTE RELACION ENTRE PADRE Y ESTUDIANTE
        private bool bExisteRelacionPadreXEstudiante()
        {
            bool result = false;
            NPadredeFamilia objNegocioPadreFamilia = new NPadredeFamilia(objEntidadPadreFamilia);
            result = objNegocioPadreFamilia.existeRelacionPadreXEstudiante();
            return result;
        }
        #endregion
    }
}
