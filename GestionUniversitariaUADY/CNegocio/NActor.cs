using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CEntidades;
using CDatos;

namespace CNegocio
{
   public class NActor
    {
        EActor ObjEActor;
        public NActor(EActor ObjEActorRecibido)// aqui decimos que la clase NActor siempre va a recibir datos de EActor por
        {                                      //medio de la variable de objEactorRecibido
            this.ObjEActor = ObjEActorRecibido;
        }
        public int AlmacenaDatosActor ()
        {
            DActor ObjDActor = new DActor(ObjEActor);
            return ObjDActor.AlmacenaDatosActor();
            
        }
    }
}
