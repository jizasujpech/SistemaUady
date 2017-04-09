using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
  public  class EEmpleado
    {
        public int IdEmpleado;
        public int IdActor;
        //public int IdTipo;
        public string ClaveEmpleado;
        public string Dependencia;
        public string Area;
        public string Puesto;
        public EActor objActor;

        public EEmpleado()
        {
            objActor = new EActor();
        }
    }
}
