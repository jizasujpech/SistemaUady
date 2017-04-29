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
    public class NEstudiante
    {
        EEstudiante objEEstudiante;
        #region CONSTRUCTOR
        public NEstudiante(EEstudiante objEEstudianteRecibido)
        {
            this.objEEstudiante = objEEstudianteRecibido;
        }
        #endregion

        #region GET DATOS ESTUDIANTE
        public EEstudiante getDatosEstudiante()
        {
            DEstudiante objDEstudiante = new DEstudiante(objEEstudiante);
            return objDEstudiante.GetDatosEstudiante();
        }
        #endregion
        #region GET DATOS ESTUDIANTE DATATABLE
        public DataTable getDatosEstudiante_DataTable()
        {
            DEstudiante objDEstudiante = new DEstudiante(objEEstudiante);
            return objDEstudiante.GetDatosEstudiante_DataTable();
        }
        #endregion

        #region ALMACENA DATOS ESTUDIANTE
        public EEstudiante almacenaDatosEstudiante()
        {
            DEstudiante objDEstudiante = new DEstudiante(objEEstudiante);
            return objDEstudiante.AlmacenaDatosEstudiante();
        }
        #endregion

        #region MODIFICA DATOS ESTUDIANTE
        public bool actualizaDatosEstudiante()
        {
            DEstudiante objDEstudiante = new DEstudiante(objEEstudiante);
            return objDEstudiante.actualizaDatosEstudiante();
        }
        #endregion

    }
}
