using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class frmReporteProblematicaBasica : Form
    {
        int cveProblematica;

        public frmReporteProblematicaBasica(int cveProblematicaRecibido)
        {
            InitializeComponent();
            this.cveProblematica = cveProblematicaRecibido;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1, cveProblematica);
            this.rptvProblematicaBasico.RefreshReport();
        }
    }
}
