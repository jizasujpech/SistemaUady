using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CEntidades;
using CDatos;

namespace CNegocio
{
   public class NProblematica
    {
        EProblematica ObjEProblematica;
        public NProblematica (EProblematica ObjEProblematicaRecibido)// aqui decimos que la clase NActor siempre va a recibir datos de EActor por
        {                                      //medio de la variable de objEactorRecibido
            this.ObjEProblematica = ObjEProblematicaRecibido;
        }
        #region INSERTAR PROBLEMATICA
        public bool AlmacenaDatosProblematica()
        {
            DProblematica ObjDProblematica = new DProblematica(ObjEProblematica);
            return ObjDProblematica.AlmacenaDatosProblematica();

        }
        #endregion
        #region GET ID SIGUIENTE PROBLEMATICA
        public int getIDSiguienteProblematica()
        {
            DProblematica ObjDProblematica = new DProblematica(ObjEProblematica);
            return ObjDProblematica.getIDSiguienteProblematica();
        }
        #endregion
    }
}
