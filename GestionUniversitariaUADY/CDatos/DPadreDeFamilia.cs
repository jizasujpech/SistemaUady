using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidades;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CDatos
{
    public class DPadreDeFamilia
    {
        #region VARIABLES DE LA CLASE
        EPadreDeFamilia ObjEPadreFamilia;
        SqlConnection Meconecto;
        SqlCommand Comandosql;
        #endregion

        #region CONSTRUCTOR
        public DPadreDeFamilia(EPadreDeFamilia objEPadreFamiliaRecibido)
        {
            this.ObjEPadreFamilia = objEPadreFamiliaRecibido;
        }
        #endregion

        #region Obten Datos del PadreDeFamilia/Get 
        //Se obtiene los datos del usuario por medio de objEacceso que se creo en el constructor
        public EPadreDeFamilia GetDatosPadreFamilia()
        {
            EPadreDeFamilia ObjEPadreFamiliaDevuelto = new EPadreDeFamilia();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
                string query = getSelect();

                Comandosql = new SqlCommand(query, Meconecto);


                DataSet DatasetLleno = new DataSet();

                // Assumes that connection is a valid SqlConnection object.

                SqlDataAdapter adapter = new SqlDataAdapter(query, Meconecto);


                if (!String.IsNullOrEmpty(ObjEPadreFamilia.Nombre))
                    adapter.SelectCommand.Parameters.AddWithValue("@NombreP", "%" + ObjEPadreFamilia.Nombre + "%");

                if (!String.IsNullOrEmpty(ObjEPadreFamilia.Apellido1))
                    adapter.SelectCommand.Parameters.AddWithValue("@Apellido1P", ObjEPadreFamilia.Apellido1);

                if (!String.IsNullOrEmpty(ObjEPadreFamilia.Apellido2))
                    adapter.SelectCommand.Parameters.AddWithValue("@Apellido2P", ObjEPadreFamilia.Apellido2);






                //  DataSet DSUsuario = new DataSet();// dataset de usuario
                adapter.Fill(DatasetLleno, "PadreDeFamilia");

                if (DatasetLleno.Tables[0].Rows.Count > 0)
                {
                    DataRow DrLleno = DatasetLleno.Tables[0].Rows[0];
                    ObjEPadreFamiliaDevuelto.IdEstudiante = Convert.ToInt32(DrLleno["IdEstudiante"]);
                    ObjEPadreFamiliaDevuelto.objEntidadEstudiante.Licenciatura = DrLleno["Licenciatura"].ToString();
                    ObjEPadreFamiliaDevuelto.objEntidadEstudiante.Matricula = DrLleno["Matricula"].ToString();
                    ObjEPadreFamiliaDevuelto.objEntidadEstudiante.Semestre = Convert.ToInt32(DrLleno["Semestre"]);
                    //ObjEEstudiannteDevuelto.IdTipo = Convert.ToInt32(DrLleno["IdTipo"]);
                    ObjEPadreFamiliaDevuelto.objEntidadEstudiante.Escuela = DrLleno["Escuela"].ToString();
                    ObjEPadreFamiliaDevuelto.IdActor = Convert.ToInt32(DrLleno["IdActor"]);

                    ObjEPadreFamiliaDevuelto.IdActor = Convert.ToInt32(DrLleno["IdActor"]);
                    ObjEPadreFamiliaDevuelto.Nombre = DrLleno["Nombre"].ToString();
                    ObjEPadreFamiliaDevuelto.Apellido1 = DrLleno["Apellido1"].ToString();
                    ObjEPadreFamiliaDevuelto.Apellido2 = DrLleno["Apellido2"].ToString();
                    ObjEPadreFamiliaDevuelto.Correo = DrLleno["Correo"].ToString();
                    ObjEPadreFamiliaDevuelto.Telefono = Convert.ToInt64(DrLleno["Telefono"]);

                    ObjEPadreFamiliaDevuelto.ObjTipo.IdTipo = Convert.ToInt32(DrLleno["IdTipo"]);
                }



                objConexionABD.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjEPadreFamiliaDevuelto;
        }
        #endregion
        #region Obten Datos del PadreDeFamilia/Get. DATATABLE 
        //Se obtiene los datos del usuario por medio de objEacceso que se creo en el constructor
        public DataTable GetDatosPadreFamilia_DataTable()
        {
            DataTable dtResult = new DataTable();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
                string query = getSelect();

                Comandosql = new SqlCommand(query, Meconecto);

                // Assumes that connection is a valid SqlConnection object.

                SqlDataAdapter adapter = new SqlDataAdapter(query, Meconecto);

                     if (!String.IsNullOrEmpty(ObjEPadreFamilia.Nombre))
                        adapter.SelectCommand.Parameters.AddWithValue("@NombreP", "%" + ObjEPadreFamilia.Nombre + "%");

                    if (!String.IsNullOrEmpty(ObjEPadreFamilia.Apellido1))
                        adapter.SelectCommand.Parameters.AddWithValue("@Apellido1P", ObjEPadreFamilia.Apellido1);

                    if (!String.IsNullOrEmpty(ObjEPadreFamilia.Apellido2))
                        adapter.SelectCommand.Parameters.AddWithValue("@Apellido2P", ObjEPadreFamilia.Apellido2);
               


                adapter.Fill(dtResult);
                objConexionABD.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtResult;
        }
        #endregion
        #region GET SELECT
        private string getSelect()
        {
            string result = string.Empty;

            result = @"Select  * from [PadreDeFamilia] 
                     LEFT JOIN Estudiante ON PadreDeFamilia.IdEstudiante = Estudiante.IdEstudiante
                     LEFT JOIN Actor as actor1 ON actor1.IdActor = PadreDeFamilia.IdActor 
                     LEFT JOIN Actor as actor2 ON actor2.IdActor = Estudiante.IdEstudiante where ";//@ para parametros

            string where = String.Empty;

                if (!String.IsNullOrEmpty(ObjEPadreFamilia.Nombre))
                    where = "actor1.Nombre LIKE @NombreP ";

                if (!String.IsNullOrEmpty(ObjEPadreFamilia.Apellido1))
                {
                    if (!String.IsNullOrEmpty(where))
                        where += "AND ";

                    where += "actor1.Apellido1 = @Apellido1P ";
                }

                if (!String.IsNullOrEmpty(ObjEPadreFamilia.Apellido2))
                {
                    if (!String.IsNullOrEmpty(where))
                        where += "AND ";

                    where += "actor1.Apellido2 = @Apellido2P ";
                }

                result += where;

            return result;
        }
        #endregion
        #region EXISTE RELACION PADRE Y ESTUDIANTE
        //Se obtiene los datos del usuario por medio de objEacceso que se creo en el constructor
        public DataTable existeRelacionPadreXEstudiante()
        {
            DataTable dtResult = new DataTable();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
                string query = "SELECT IdPadre FROM PadreDeFamilia WHERE IdActor = @IdActorP AND IdEstudiante = @IdEstudianteP";

                Comandosql = new SqlCommand(query, Meconecto);

                // Assumes that connection is a valid SqlConnection object.

                SqlDataAdapter adapter = new SqlDataAdapter(query, Meconecto);
                adapter.SelectCommand.Parameters.AddWithValue("@IdActorP", ObjEPadreFamilia.IdActor);
                adapter.SelectCommand.Parameters.AddWithValue("@IdEstudianteP", ObjEPadreFamilia.IdEstudiante);



                adapter.Fill(dtResult);
                objConexionABD.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtResult;
        }
        #endregion

        #region INSERTA DATOS PADRE DE FAMILIA
        public EPadreDeFamilia AlmacenaDatosPadreDeFamilia()
        {
            int result = 0;
            EPadreDeFamilia objEPadreFamiliaDevuelto = new EPadreDeFamilia();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;


                DEstudiante objDatosEstudiante = new DEstudiante(ObjEPadreFamilia.objEntidadEstudiante);

                
                defineOperacionEstudiante();

                if (ObjEPadreFamilia.IdActor == 0)
                {
                    DActor objDActor = new DActor(ObjEPadreFamilia);
                    ObjEPadreFamilia.IdActor = objDActor.AlmacenaDatosActor();
                }
                    

                if (ObjEPadreFamilia.IdActor > 0)
                {
                    string query = "INSERT INTO  PadreDeFamilia (IdActor, IdEstudiante, parentesco) VALUES (@IdActorP, @IdEstudianteP, @IdParentesco);SELECT CAST(scope_identity() AS int)";  //para parametros y P para diferenciarlo
                    Comandosql = new SqlCommand(query, Meconecto);
                    Comandosql.Parameters.AddWithValue("@IdActorP", ObjEPadreFamilia.IdActor);
                    Comandosql.Parameters.AddWithValue("@IdEstudianteP", ObjEPadreFamilia.IdEstudiante);
                    Comandosql.Parameters.AddWithValue("@IdParentesco", ObjEPadreFamilia.Parentesco);
                    result = (int)Comandosql.ExecuteScalar();
                }

                objConexionABD.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            objEPadreFamiliaDevuelto.IdPadre = result;
            objEPadreFamiliaDevuelto.IdActor = ObjEPadreFamilia.IdActor;
            objEPadreFamiliaDevuelto.IdEstudiante = ObjEPadreFamilia.IdEstudiante;

            return objEPadreFamiliaDevuelto;
        }
        #endregion

        #region ACTUALIZAR DATOS DEL PADRE DE FAMILIA
        public bool actualizaDatosPadreFamilia()
        {
            //EEstudiante objEEstudianteDevuelto = new EEstudiante();
            int result = 0;
            ConexionesABD objConexionABD = new ConexionesABD();

            try
            {
                Meconecto = objConexionABD.Meconecto;

                defineOperacionEstudiante();

                DActor objDActor = new DActor(ObjEPadreFamilia);
                objDActor.actualizaDatosActor();

                string query = "UPDATE PadreDeFamilia SET Parentesco = @ParentescoP WHERE IdPadre = @IdPadreP ";  //para parametros y P para diferenciarlo
                Comandosql = new SqlCommand(query, Meconecto);
                Comandosql.Parameters.AddWithValue("@ParentescoP", ObjEPadreFamilia.Parentesco);
                Comandosql.Parameters.AddWithValue("@IdPadreP", ObjEPadreFamilia.IdPadre);
                result = Comandosql.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConexionABD.CerrarConexion();
            }

            return result > 0;
        }
        #endregion

        #region DEFINE OPERACION ESTUDIANTE
        private void defineOperacionEstudiante()
        {
            DEstudiante objDatosEstudiante = new DEstudiante(ObjEPadreFamilia.objEntidadEstudiante);

            if (ObjEPadreFamilia.IdEstudiante > 0)
                objDatosEstudiante.actualizaDatosEstudiante();
            else
                ObjEPadreFamilia.IdEstudiante = objDatosEstudiante.AlmacenaDatosEstudiante().IdEstudiante;
        }
        #endregion
    }
}
