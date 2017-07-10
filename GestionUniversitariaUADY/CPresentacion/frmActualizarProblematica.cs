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
    public partial class frmActualizarProblematica : Form
    {
        EProblematica objEntidadProblematica;
        EAcceso objEntidadAcceso;

        string situacionActual;
        DateTime fechaActual;
        string actoresIvolucradosActuales;
        string procedimientoActual;
        string responsableDeSolucionActual;
        string seguimientoActual;
        string conclusionActual;
        string evaluacionActual;
        string comentariosActuales;
        string satisfaccionActual;
        string temaActual;
        string semaforoActual;

             
        #region CONSTRUCTOR
        public frmActualizarProblematica(EAcceso objEntidadAccesoRecibido, EProblematica objEntidadProblematicaRecibido)
        {
            InitializeComponent();
            objEntidadProblematica = new EProblematica();
            this.objEntidadProblematica = objEntidadProblematicaRecibido;
            this.objEntidadAcceso = objEntidadAccesoRecibido;
            realizaConsultaProblematica();
            fillControles();
            fillDatosOriginales();       
        }
        #endregion
        #region LLENA CONTROLES CON LA PROBLEMATICA
        private void realizaConsultaProblematica()
        {
            NProblematica objNegocioProblematica = new NProblematica(objEntidadProblematica);
            objEntidadProblematica = objNegocioProblematica.getProblematica();
        }
        private void fillControles()
        {
           

            txtClaveSeguimiento.Text = Convert.ToString(objEntidadProblematica.ClaveDeSeguimiento);
            txtSituacion.Text = objEntidadProblematica.Situacion;
            dateTimePicker1.Value = objEntidadProblematica.Fecha;
            txtActoresInvolucrados.Text = objEntidadProblematica.ActoresInvolucrados;
            txtProcedimientos.Text= objEntidadProblematica.Procedimiento ;
            txtResponsableDeSolucion.Text= objEntidadProblematica.ResponsableDeSolucion ;
            txtSeguimiento.Text = objEntidadProblematica.Seguimiento;
            txtConclusion.Text =  objEntidadProblematica.Conclusion  ;
            txtEvaluacion.Text =  objEntidadProblematica.Evaluacion ;
            txtComentarios.Text = objEntidadProblematica.Comentarios ;
            txtSatisfaccion.Text = objEntidadProblematica.Satisfaccion ;
            txtTema.Text = objEntidadProblematica.Tema ;
            string semaforo = objEntidadProblematica.Semaforo;

            if (semaforo == "Amarillo")
                rbnAmarillo.Checked = true;
            else if (semaforo == "Rojo")
                rbnRojo.Checked = true;

            //objEntidadProblematica.Atendio;

        }
        #endregion
        #region DATOS ANTES DE LA MODIFICACION
        private void fillDatosOriginales()
        {
           
            situacionActual = objEntidadProblematica.Situacion;
            fechaActual = objEntidadProblematica.Fecha;
            actoresIvolucradosActuales = objEntidadProblematica.ActoresInvolucrados;
            procedimientoActual = objEntidadProblematica.Procedimiento;
            responsableDeSolucionActual = objEntidadProblematica.ResponsableDeSolucion;
            seguimientoActual = objEntidadProblematica.Seguimiento;
            conclusionActual = objEntidadProblematica.Conclusion;
            evaluacionActual = objEntidadProblematica.Evaluacion;
            comentariosActuales = objEntidadProblematica.Comentarios;
            satisfaccionActual = objEntidadProblematica.Satisfaccion;
            temaActual = objEntidadProblematica.Tema;
            semaforoActual = objEntidadProblematica.Semaforo;
        }
        #endregion
        #region LLENA OBJETO A PARTIR DE LOS CONTROLES
        private void fillObjetoProblematica()
        {
            objEntidadProblematica.Situacion = txtSituacion.Text;
            objEntidadProblematica.Fecha = dateTimePicker1.Value;
            objEntidadProblematica.ActoresInvolucrados = txtActoresInvolucrados.Text;
            objEntidadProblematica.Procedimiento = txtProcedimientos.Text;
            objEntidadProblematica.ResponsableDeSolucion = txtResponsableDeSolucion.Text;
            objEntidadProblematica.Seguimiento = txtSeguimiento.Text;
            objEntidadProblematica.Conclusion = txtConclusion.Text;
            objEntidadProblematica.Evaluacion = txtEvaluacion.Text;
            objEntidadProblematica.Comentarios = txtComentarios.Text;
            objEntidadProblematica.Satisfaccion = txtSatisfaccion.Text;
            objEntidadProblematica.Tema = txtTema.Text;

            string semaforo = "Verde";
            if (rbnAmarillo.Checked == true)
                semaforo = "Amarillo";
            else if (rbnRojo.Checked == true)
                semaforo = "Rojo";

            objEntidadProblematica.Semaforo = semaforo;
        }
        #endregion
        #region ACTUALIZAR PROBLEMATICA
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarProblematica();
        }

        private void actualizarProblematica()
        {
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro que deseas modificar los datos?", "Confirmar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                fillObjetoProblematica();

                if(bDebeModificar())
                {
                    NProblematica objNegocioProblematica = new NProblematica(objEntidadProblematica);
                    objNegocioProblematica.actualizaDatosProblematica();
                }
                
                   MessageBox.Show("Datos actualizados correctamente");
                   this.Close();
            }
               


        }
        #endregion
        #region DETERMINA SI DEBE MODIFICAR
        private bool bDebeModificar()
        {
            bool result = false;

            if (objEntidadProblematica.Situacion != situacionActual)
                result = true;
            else if(fechaActual != objEntidadProblematica.Fecha)
                result = true;
            else if(objEntidadProblematica.ActoresInvolucrados != actoresIvolucradosActuales)
                result = true;
            else if(objEntidadProblematica.Procedimiento != procedimientoActual)
                result = true;
            else if (objEntidadProblematica.ResponsableDeSolucion != responsableDeSolucionActual)
                result = true;
            else if(objEntidadProblematica.Seguimiento != seguimientoActual)
                result = true;
            else if(objEntidadProblematica.Conclusion != conclusionActual)
                result = true;
            else if(objEntidadProblematica.Evaluacion != evaluacionActual)
                result = true;
            else if(objEntidadProblematica.Comentarios != comentariosActuales)
                result = true;
            else if(objEntidadProblematica.Satisfaccion != satisfaccionActual)
                result = true;
            else if(objEntidadProblematica.Tema != temaActual)
                result = true;
            else if(objEntidadProblematica.Semaforo != semaforoActual)
                result = true;

            return result;
        }

        #endregion
        #region CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        private void cancelar()
        {
            //FiltroDeSeguimiento objFiltroSeguimiento = new FiltroDeSeguimiento(objEntidadAcceso);
            //objFiltroSeguimiento.Show();
            this.Close();
        }
        #endregion
        #region LIMPIAR CONTROLES
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void limpiarControles()
        {
            txtActoresInvolucrados.Clear();           
            txtComentarios.Clear();
            txtConclusion.Clear();          
            txtEvaluacion.Clear();         
            txtProcedimientos.Clear();
            txtResponsableDeSolucion.Clear();
            txtSatisfaccion.Clear();
            txtSeguimiento.Clear();
            txtSituacion.Clear();           
            txtTema.Clear();       
            rbnVerde.Checked = true;
        }

        #endregion
        #region CAMBIAR PROBLEMATICA
        private void btnCambiarProblematica_Click(object sender, EventArgs e)
        {
            elegirOtraProblematica();
        }
        private void elegirOtraProblematica()
        {
            int claveSeguimiento = objEntidadProblematica.ClaveDeSeguimiento;
            objEntidadProblematica.ClaveDeSeguimiento = 0;
            frmProblematicas objFrmProblematicas = new frmProblematicas(ref objEntidadProblematica);
            objFrmProblematicas.ShowDialog();

            if (objEntidadProblematica.ClaveDeSeguimiento == 0)
                objEntidadProblematica.ClaveDeSeguimiento = claveSeguimiento;

            if (objEntidadProblematica.ClaveDeSeguimiento != claveSeguimiento)               
            {
                fillControles();
                fillDatosOriginales();
                //fillObjetoProblematica();

            }
               

            txtSeguimiento.Text = objEntidadProblematica.Seguimiento;
        }
        #endregion
    }
}
