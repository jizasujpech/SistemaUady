using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
   public class EActor
    {
        public int IdActor;
        public string Nombre;
        public string Apellido1;
        public string Apellido2;
        //public int Telefono;
        public long Telefono;

        public string Correo;
    //  public EActor ObjEActor;
        public ETipo ObjTipo; 

        #region CONSTRUCTOR     
        public EActor()
        {
            IdActor = 0;
            ObjTipo = new ETipo();//aqui dejamos listo el obj listo para trabajar (como inicializarlo)
        }
        #endregion
    }
}
