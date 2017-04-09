using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EProblematica
    {
        public int ClaveDeSeguimiento;
        public int idActor;
        public DateTime Fecha;
        public string Situacion;
        public string ActoresInvolucrados;
        public string Procedimiento;
        public string ResponsableDeSolucion;
        public string Seguimiento;
        public string Conclusion;
        public string Evaluacion;
        public string Comentarios;
        public string Satisfaccion;
        public string Tema;
        public string Atendio;
        public string Semaforo;
        public EAcceso ObjEAcceso;
     //   public DateTime fechita;

        #region CONSTRUCTOR     
        public EProblematica()
        {
            ClaveDeSeguimiento = 0;
           // ObjProblematica = new EProblematica();//aqui dejamos listo el obj listo para trabajar (como inicializarlo)
        }
        #endregion
    }
}
