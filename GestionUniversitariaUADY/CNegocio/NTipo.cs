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
   public class NTipo
    {
        ETipo ObjNTipo;
        public NTipo(ETipo ObjTipo)
        {
            this.ObjNTipo = ObjTipo;
        }
         
        public bool InsertarBDTipo()
        {

            DTipo ObjDTipo = new DTipo(ObjNTipo);  //objEstudianteModelo se declara aca
            return ObjDTipo.InsertaDato();

        }


        public DataTable ConsultarLosTipos()
        {
            DTipo ObjDtipo = new DTipo(ObjNTipo);
            return ObjDtipo.ConsultaTipos();

        }



    }
}
