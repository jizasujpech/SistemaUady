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

namespace CPresentacion
{
    public partial class frmMenuPrincipal : Form
    {
        EAcceso objEntidadAcceso;
        public frmMenuPrincipal(EAcceso objEntidadAccesoRecibido)
        {
            InitializeComponent();
            this.objEntidadAcceso = objEntidadAccesoRecibido;
        }
        #region ALTA PROBLEMATICA
        private void btnAltaProblematica_Click(object sender, EventArgs e)
        {
            altaProblematica();
        }
        private void altaProblematica()
        {
            FiltroProblematica objFiltroProblematica = new FiltroProblematica(objEntidadAcceso);
            objFiltroProblematica.Show();
            this.Hide();
        }
        #endregion

        #region SEGUIMIENTO PROBLEMATICA
        

        private void btnSeguimientoProblematica_Click(object sender, EventArgs e)
        {
            seguimientoProblematica();
        }
        private void seguimientoProblematica()
        {

            FiltroDeSeguimiento objFiltroSeguimiento = new FiltroDeSeguimiento(objEntidadAcceso);
            objFiltroSeguimiento.Show();
            this.Hide();
        }
        #endregion
        #region SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion 
    }
}
