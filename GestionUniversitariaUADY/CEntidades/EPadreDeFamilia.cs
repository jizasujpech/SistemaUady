﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EPadreDeFamilia:EActor
    {
        public int IdPadre;
        public int IdEstudiante;
        public string Parentesco;
        public EEstudiante objEntidadEstudiante;
        //public int IdTipo;
        //public string NombreP;
        //public string ApellidoPP;
        //public string ApellidoMP;
        //public string Correo;
        //public int Telefono;

        public EPadreDeFamilia()
        {
            objEntidadEstudiante = new EEstudiante();
        }
     }
}
