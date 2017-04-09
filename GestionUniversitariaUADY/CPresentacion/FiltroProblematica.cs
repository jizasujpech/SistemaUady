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
        public FiltroProblematica()
        {
            InitializeComponent();
        }

        #region EVENTO LOAD
        private void FiltroProblematica_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportesUADYDataSet1.Tipo' Puede moverla o quitarla según sea necesario.
            this.tipoTableAdapter.Fill(this.reportesUADYDataSet1.Tipo);
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
