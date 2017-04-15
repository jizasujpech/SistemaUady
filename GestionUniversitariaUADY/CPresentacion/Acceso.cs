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
    public partial class Acceso : Form
    {
        public Acceso()
        {
            InitializeComponent();
        }

             private void btnAccesar_Click(object sender, EventArgs e)
        {
            if (ValidaAcceso ())
            {
                EAcceso ObjDAcceso = new EAcceso();
                ObjDAcceso.UsuarioS = txtUsuario.Text;
                ObjDAcceso.Contraseña = txtContraseña.Text;
              //ObjDAcceso.Idusuario = Convert.ToInt32 (txtUsuario.Text);
                NAcceso ObjNAcceso = new NAcceso(ObjDAcceso);

                if (ObjNAcceso.ValidaUsuario())

                {
                    MessageBox.Show("USUARIO VALIDO");

                    FiltroProblematica objFiltroProblematica = new FiltroProblematica();
                    objFiltroProblematica.Show();


                   /* RegistroActor sevaaregistro = new RegistroActor(ObjDAcceso);
                    sevaaregistro.Show();*/
                    this.Hide();


                }
                else
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTOS");


            }
            else
                MessageBox.Show("El campo de la contraseña o usuario esta vacios");
        }

        private bool ValidaAcceso() //metodo para validar que no deje en blanco  usuario contraseña
        {
            if (txtUsuario.Text == String.Empty || txtContraseña.Text == String.Empty)
                return false;

            return true;
        }


        private void Acceso_Load(object sender, EventArgs e)
        {

        }
        #region EVENTOS ENTER
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)            
                txtContraseña.Focus();           

        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                btnAccesar.PerformClick();
        }
        #endregion




    }
}
