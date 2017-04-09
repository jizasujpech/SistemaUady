using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CEntidades;
using CDatos;
using System.Data;


namespace CNegocio
{
    public class NAcceso
    {
        EAcceso  ObjEAcceso;
        #region CONSTRUCTOR
        public NAcceso (EAcceso ObjAcceso)
        {
            this.ObjEAcceso = ObjAcceso;
        }
        #endregion
        #region VALIDA USUARIO
        public bool ValidaUsuario()
        {
            DAcceso ObjDAcceso = new DAcceso(ObjEAcceso);
           // ObjDAcceso.GetDatosUsuarios();
             return ObjDAcceso.ValidarUsuario();
          
            //return true;
        }
        #endregion
        #region GET DATOS USUARIO
        public EAcceso GetDatosUsuario()
        {
            EAcceso objEAcceso = new EAcceso();
            DAcceso objDAcceso = new DAcceso(ObjEAcceso);
            objEAcceso = objDAcceso.GetDatosUsuarios();
            return objEAcceso;

        }
        #endregion


    }
}
