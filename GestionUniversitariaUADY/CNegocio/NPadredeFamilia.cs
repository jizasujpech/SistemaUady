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
   public class NPadredeFamilia
    {
        EPadreDeFamilia objEntidadPadreFamilia;
        #region CONSTRUCTOR
        public NPadredeFamilia(EPadreDeFamilia objEPadreFamiliaRecibido)
        {
            this.objEntidadPadreFamilia = objEPadreFamiliaRecibido;
        }
        #endregion

        #region GET DATOS PADRE DE FAMILIA
        public EPadreDeFamilia getDatosPadreFamilia()
        {
            DPadreDeFamilia objDPadreFamilia = new DPadreDeFamilia(objEntidadPadreFamilia);
            return objDPadreFamilia.GetDatosPadreFamilia();
        }
        #endregion
        #region GET DATOS PADRE DE FAMILIA DATATABLE
        public DataTable getDatosPadreFamilia_DataTable()
        {
            DPadreDeFamilia objDPadreFamilia = new DPadreDeFamilia(objEntidadPadreFamilia);
            return objDPadreFamilia.GetDatosPadreFamilia_DataTable();
        }
        #endregion

        #region ALMACENA DATOS PADRE DE FAMILIA
        public EPadreDeFamilia almacenaDatosPadreFamilia()
        {
            DPadreDeFamilia objDPadreFamilia = new DPadreDeFamilia(objEntidadPadreFamilia);
            return objDPadreFamilia.AlmacenaDatosPadreDeFamilia();
        }
        #endregion

        #region MODIFICA DATOS PADRE DE FAMILIA
        public bool actualizaDatosPadreFamilia()
        {
            DPadreDeFamilia objDPadreFamilia = new DPadreDeFamilia(objEntidadPadreFamilia);
            return objDPadreFamilia.actualizaDatosPadreFamilia();
        }
        #endregion
        #region EXISTE RELACION PADRE Y ESTUDIANTE
        public bool existeRelacionPadreXEstudiante()
        {
            DPadreDeFamilia objDPadreFamilia = new DPadreDeFamilia(objEntidadPadreFamilia);
            return objDPadreFamilia.existeRelacionPadreXEstudiante().Rows.Count > 0;
        }
        #endregion
    }
}
