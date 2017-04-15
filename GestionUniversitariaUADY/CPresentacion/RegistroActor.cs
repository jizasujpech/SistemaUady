using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


using CNegocio;
using CEntidades;
namespace CPresentacion
{

    public partial class RegistroActor : Form
    {
        EActor  ObjEActor;
        EProblematica ObjEProblematica;
        EEstudiante ObjEEstudiante;
        EEmpleado ObjEEmpleado;
        EPadreDeFamilia ObjEPadreDeFamilia;
        EAcceso ObjEAcceso;
               
        //ETipo ObjTipo;
        public RegistroActor(EAcceso ObjAcceso)
        {

            InitializeComponent();
            this.ObjEAcceso = ObjAcceso;

            ObjEActor = new EActor();
            ObjEEstudiante = new EEstudiante();
            ObjEProblematica = new EProblematica();
            ObjEEmpleado = new EEmpleado();
            ObjEPadreDeFamilia = new EPadreDeFamilia();
        }

        #region EVENTO LOAD - Llenado Registro Actor
        private void RegistroActor_Load(object sender, EventArgs e)
        {
            ETipo ObjEtipo = new ETipo();
            NTipo ObjNTipo = new NTipo(ObjEtipo);
           
            cmbTipo.DisplayMember = "Descripcion";
            cmbTipo.ValueMember = "IdTipo";
            cmbTipo.DataSource = ObjNTipo.ConsultarLosTipos();


            NAcceso objNAcceso = new NAcceso(ObjEAcceso);
            EAcceso objEAccesoDatosFormulario = objNAcceso.GetDatosUsuario();
        //nombre completo *    lblNombreUsuario.Text = "Usuario: "+ objEAccesoDatosFormulario.Nombre + " " + objEAccesoDatosFormulario.Apellido1;
            lblNombreUsuario.Text = "Usuario: " + objEAccesoDatosFormulario.Nombre;
            txtClaveSeguimiento.Text = Convert.ToString(getIdSiguienteProblematica());
         }
        #endregion
        #region Llenado Obj Actor
        private void LlenaObjActor()
        {
           
            ObjEActor.Nombre = txtNombreR.Text;
            ObjEActor.Apellido1 = txtApellidoPR.Text;
            ObjEActor.Apellido2 = txtApellidoMR.Text;
            ObjEActor.Telefono = Convert.ToInt64(txtTelefono.Text);           
            ObjEActor.Correo = txtCorreoR.Text;

            switch(cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        if (ObjEEmpleado.IdActor > 0)
                            ObjEActor.IdActor = ObjEEmpleado.IdActor;
                        break;
                    }
                case 1:
                    {
                        if (ObjEEstudiante.IdActor > 0)
                            ObjEActor.IdActor = ObjEEstudiante.IdActor;
                        break;
                    }

            }

            LlenadoObjTipo();

         }
        #endregion
        #region Llenado Obj Problematica
        private void LlenaObjProblematica()
        {
            
          
      
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            
            ObjEProblematica.Fecha = dateTimePicker1.Value;
            ObjEProblematica.Situacion = txtSituacion.Text;
            ObjEProblematica.ActoresInvolucrados = txtActoresInvolucrados.Text;
            ObjEProblematica.Procedimiento = txtProcedimientos.Text;
            ObjEProblematica.ResponsableDeSolucion = txtResponsableDeSolucion.Text;
            ObjEProblematica.Comentarios = txtComentarios.Text;
            ObjEProblematica.Tema = txtTema.Text;
            ObjEProblematica.Seguimiento = txtSeguimiento.Text;
            ObjEProblematica.Evaluacion = txtEvaluacion.Text;
            ObjEProblematica.Conclusion = txtConclusion.Text;
            ObjEProblematica.Satisfaccion = txtSatisfaccion.Text;
            ObjEProblematica.Atendio = "admin";
            ObjEProblematica.Semaforo = getSemaforo();

        }
        #endregion
        #region Llenado Obj Estudiante
        private void LlenaObjEstudiante()
        {
           
            ObjEEstudiante.Matricula = txtTipo1.Text;
            ObjEEstudiante.Escuela = txtTipo2.Text;
            ObjEEstudiante.Licenciatura = txtTipo3.Text;
            ObjEEstudiante.Semestre = Convert.ToInt32(txtTipo4.Text);
            //ObjEEstudiante.IdTipo = ObjEActor.ObjTipo.IdTipo;
         }
        #endregion
        #region Llenado Obj Empleado
        private void LlenaObjEmpleado()
        {
            ObjEEmpleado.Nombre = txtNombreR.Text;
            ObjEEmpleado.Apellido1 = txtApellidoPR.Text;
            ObjEEmpleado.Apellido2 = txtApellidoMR.Text;
            ObjEEmpleado.Telefono = Convert.ToInt64(txtTelefono.Text);
            ObjEEmpleado.Correo = txtCorreoR.Text;


            ObjEEmpleado.ClaveEmpleado = txtTipo1.Text;
            ObjEEmpleado.Dependencia = txtTipo2.Text;
            ObjEEmpleado.Area = txtTipo3.Text;
            ObjEEmpleado.Puesto = txtTipo4.Text;
            //ObjEEmpleado.IdTipo = ObjEActor.ObjTipo.IdTipo;
        }
        #endregion
        #region Llenado Obj Padre de Familia
        private void LlenadoObjPadreDeFamilia()
        {      
            //ObjEPadreDeFamilia.           
        }
        #endregion
        #region Llenado Obj Tipo
        private void LlenadoObjTipo()
        {
            ObjEActor.ObjTipo.IdTipo = cmbTipo.SelectedIndex;
            ObjEActor.ObjTipo.Descripcion = cmbTipo.Text;
        }
        #endregion
        #region VALIDACIONES
        private bool CampoVacioR() //metodo para validar que no deje en blanco  usuario contraseña
        {


            if (txtNombreR.Text == String.Empty)
            {
                MessageBox.Show("Nombre vacio");
                txtNombreR.Focus();
                return false;

            }

            if (txtApellidoPR.Text == String.Empty)
            {
                MessageBox.Show("Apellido P vacio");
                txtApellidoPR.Focus();
                return false;

            }
            return true;
        }

        private bool CampoVacioEstudiante()
        {
            if (txtTipo1.Text == String.Empty)
            {
                MessageBox.Show("Matricula esta Vacio");
                txtTipo1.Focus();
                return false;
            }
            if (txtTipo2.Text == String.Empty)
            {
                MessageBox.Show("Escuela esta Vacio");
                txtTipo2.Focus();
                return false;
            }
            if (txtTipo3.Text == String.Empty)
            {
                MessageBox.Show("Licenciatura esta Vacio");
                txtTipo3.Focus();
                return false;
            }
            if (txtTipo4.Text == String.Empty)
            {
                MessageBox.Show("Semestre esta Vacio");
                txtTipo4.Focus();
                return false;
            }
            return true;

        }
        private bool ValidacionPrincipal()
        {
            bool result = false;
            if (CampoVacioR())
            {
                int indice = cmbTipo.SelectedIndex;
                switch (indice)
                {
                    case 0:

                        result = CampoVacioEstudiante();
                        break;


                }

            }
            return result;
        }
        #endregion


        #region BOTON REGISTRAR
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
           

            ValidacionPrincipal();
            llenaObjetosRegistro();

            switch(cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        NEmpleado objNEmpleado = new NEmpleado(ObjEEmpleado);                     
                       
                        if (ObjEEmpleado.IdEmpleado > 0)
                        {
                            objNEmpleado.actualizaDatosEmpleado();
                            ObjEProblematica.idActor = ObjEEmpleado.IdActor;
                        }                          
                        else
                        {
                            EEmpleado objEEmpleadoAlmacenado = new EEmpleado();
                            objEEmpleadoAlmacenado = objNEmpleado.almacenaDatosEmpleado();
                            ObjEProblematica.idActor = objEEmpleadoAlmacenado.IdActor;
                        }
                       
                        break;
                    }
                case 1:
                    {
                        NEstudiante objNEstudiante = new NEstudiante(ObjEEstudiante);
                        if (ObjEEstudiante.IdEstudiante > 0)
                        { 
                        objNEstudiante.actualizaDatosEstudiante();
                        ObjEProblematica.idActor = ObjEEstudiante.IdActor;
                        }
                        else
                        {
                            EEstudiante objEEstudianteAlmacenado = new EEstudiante();
                            objEEstudianteAlmacenado = objNEstudiante.almacenaDatosEstudiante();
                            ObjEProblematica.idActor = objEEstudianteAlmacenado.IdActor;
                        }                       
                        break; 
                    }
                    case 3:
                    {
                        NActor ObjNActor = new NActor(ObjEActor);
                        ObjEProblematica.idActor = ObjNActor.AlmacenaDatosActor();                        
                        break;
                    }
            }


         


            NProblematica ObjNProblematica = new NProblematica(ObjEProblematica);
            ObjEProblematica.ObjEAcceso = ObjEAcceso; 

            if (ObjEProblematica.idActor > 0)         
              MessageBox.Show("Usuario Guardado");             
            else
                MessageBox.Show("Ocurrio un error");

         
            if (ObjNProblematica.AlmacenaDatosProblematica())
                MessageBox.Show("Problematica Guardado");
            else
                MessageBox.Show("Ocurrio un error Problematica");
          
            limpiarControles();
            txtClaveSeguimiento.Text = Convert.ToString(getIdSiguienteProblematica());
            txtNombreR.Focus();



        }
        #endregion
        #region EVENTO- INDEX CHANGE
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
          switch(cmbTipo.SelectedIndex)
            {
                case 0:
                 {
                        lblTipo1.Text = "Clave";
                        lblTipo2.Text = "Dependencia";
                        lblTipo.Text = "Area";
                        lblTipo4.Text = "Puesto";
                        determinaVisibilidadEtiquetas(true, true, true, true);
                        determinaVisibilidadTextBox(true, true, true, true);
                        break;
                 }
                case 1:
                    {
                        lblTipo1.Text = "Matricula";
                        lblTipo2.Text = "Escuela";
                        lblTipo.Text = "Licenciatura";
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
        private  void determinaVisibilidadEtiquetas(bool L1, bool L2, bool L3, bool L4)
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
                lblTipo.Visible = true;
            else
                lblTipo.Visible = false;

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
        #region GET SEMAFORO
        private string getSemaforo()
        {
            string result = "Verde";

            if (rbnAmarillo.Checked == true)
                result = "Amarillo";
            else if (rbnRojo.Checked == true)
                result = "Rojo";

            return result;
        }
        #endregion

        #region LIMPIAR CONTROLES
        private void limpiarControles()
        {
            txtActoresInvolucrados.Clear();
            txtApellidoMR.Clear();
            txtApellidoPR.Clear();
            //txtClaveSeguimiento.Clear();
            txtComentarios.Clear();
            txtConclusion.Clear();
            txtCorreoR.Clear();
            txtEvaluacion.Clear();
            txtNombreR.Clear();
            txtProcedimientos.Clear();
            txtResponsableDeSolucion.Clear();
            txtSatisfaccion.Clear();
            txtSeguimiento.Clear();
            txtSituacion.Clear();
            txtTelefono.Clear();
            txtTema.Clear();
            txtTipo1.Clear();
            txtTipo2.Clear();
            txtTipo3.Clear();
            txtTipo4.Clear();

            cmbTipo.SelectedIndex = 0;
            rbnVerde.Checked = true;
            

        }
        #endregion
        #region GET ID SIGUIENTE PROBLEMATICA
        private int getIdSiguienteProblematica()
        {
            EProblematica ObjEProblematica = new EProblematica();
            NProblematica objProblematica = new NProblematica(ObjEProblematica);
           return objProblematica.getIDSiguienteProblematica();
        }
        #endregion

        #region EVENTO VALIDATED APELLIDOM
        private void txtApellidoMR_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApellidoMR.Text)) return;
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        ObjEEmpleado.Nombre = txtNombreR.Text;
                        ObjEEmpleado.Apellido1 = txtApellidoPR.Text;
                        ObjEEmpleado.Apellido2 = txtApellidoMR.Text;

                        llenaControlesEmpleado();
                        break;
                    }

                case 1:
                    {
                        ObjEEstudiante.Nombre = txtNombreR.Text;
                        ObjEEstudiante.Apellido1 = txtApellidoPR.Text;
                        ObjEEstudiante.Apellido2 = txtApellidoMR.Text;

                        llenaControlesEstudiante();
                        break;
                    }
            }
           
        }
        #endregion
        #region EVENTO VALIDATED Clave - Matricula
        private void txtTipo1_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipo1.Text)) return;

            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    {
                        ObjEEmpleado.ClaveEmpleado = txtTipo1.Text;
                        llenaControlesEmpleado();
                        break;
                    }
                case 1:
                    {
                        ObjEEstudiante.Matricula = txtTipo1.Text;
                        llenaControlesEstudiante();
                        break;
                    }
            }
        }
        #endregion
        #region LLENA CONTROLES DEL ESTUDIANTE
        private void llenaControlesEstudiante()
        {
            NEstudiante objNEstudiante = new NEstudiante(ObjEEstudiante);
            ObjEEstudiante = objNEstudiante.getDatosEstudiante();

            if(ObjEEstudiante.IdEstudiante > 0)
            {
                txtTipo1.Text = ObjEEstudiante.Matricula;
                txtTipo3.Text = ObjEEstudiante.Licenciatura;
                txtTipo2.Text = ObjEEstudiante.Escuela;
                txtTipo4.Text = ObjEEstudiante.Semestre.ToString();

                txtNombreR.Text = ObjEEstudiante.Nombre;
                txtApellidoPR.Text = ObjEEstudiante.Apellido1;
                txtApellidoMR.Text = ObjEEstudiante.Apellido2;
                txtCorreoR.Text = ObjEEstudiante.Correo;
                txtTelefono.Text = ObjEEstudiante.Telefono.ToString();
            }
         
        }
        #endregion
        #region LLENA CONTROLES DEL EMPLEADO
        private void llenaControlesEmpleado()
        {
            NEmpleado objNEmpleado = new NEmpleado(ObjEEmpleado);
            ObjEEmpleado = objNEmpleado.getDatosEmpleado();

            if (ObjEEmpleado.IdEmpleado > 0)
            {
                txtTipo1.Text = ObjEEmpleado.ClaveEmpleado;
                txtTipo2.Text = ObjEEmpleado.Dependencia;
                txtTipo3.Text = ObjEEmpleado.Area;             
                txtTipo4.Text = ObjEEmpleado.Puesto.ToString();

                txtNombreR.Text = ObjEEmpleado.Nombre;
                txtApellidoPR.Text = ObjEEmpleado.Apellido1;
                txtApellidoMR.Text = ObjEEmpleado.Apellido2;
                txtCorreoR.Text = ObjEEmpleado.Correo;
                txtTelefono.Text = ObjEEmpleado.Telefono.ToString();
            }

        }
        #endregion
        #region BOTON LIMPIAR
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }
        #endregion
        #region LLENA LOS OBJETOS PARA EL REGISTRO
        private void llenaObjetosRegistro()
        {
            LlenaObjActor();
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

            LlenaObjProblematica();
        }
        #endregion


    }
}

