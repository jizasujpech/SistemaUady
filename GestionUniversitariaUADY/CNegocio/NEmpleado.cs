using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CEntidades;
using CDatos;
namespace CNegocio
{
    public class NEmpleado
    {
        EEmpleado objEEmpleado;
        #region CONSTRUCTOR
        public NEmpleado(EEmpleado objEEmpleadoRecibido)
        {
            this.objEEmpleado = objEEmpleadoRecibido;
        }
        #endregion

        #region GET DATOS EMPLEADO
        public EEmpleado getDatosEmpleado()
        {
            DEmpleado objDEmpleado = new DEmpleado(objEEmpleado);
            return objDEmpleado.GetDatosEmpleado();
        }
        #endregion
        #region GET DATOS EMPLEADO DATATABLE
        public DataTable getDatosEmpleado_DataTable()
        {
            DEmpleado objDEmpleado = new DEmpleado(objEEmpleado);
            return objDEmpleado.GetDatosEmpleado_DataTable();
        }
        #endregion

        #region ALMACENA DATOS EMPLEADO
        public EEmpleado almacenaDatosEmpleado()
        {
            DEmpleado objDEmpleado = new DEmpleado(objEEmpleado);
            return objDEmpleado.AlmacenaDatosEmpleado();
        }
        #endregion

        #region MODIFICA DATOS EMPLEADO
        public bool actualizaDatosEmpleado()
        {
            DEmpleado objDEmpleado = new DEmpleado(objEEmpleado);
            return objDEmpleado.actualizaDatosEmpleado();
        }
        #endregion
    }
}
