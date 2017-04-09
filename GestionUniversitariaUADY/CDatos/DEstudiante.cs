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
    public class DEstudiante
    {
        #region VARIABLES DE LA CLASE
        EEstudiante ObjEEstudiante;
        SqlConnection Meconecto;
        SqlCommand Comandosql;
        #endregion

        #region CONSTRUCTOR
        public DEstudiante(EEstudiante objEEstudianteRecibido)
        {
            this.ObjEEstudiante = objEEstudianteRecibido;
        }
        #endregion

        #region Obten Datos del Usuario/Get 
        //Se obtiene los datos del usuario por medio de objEacceso que se creo en el constructor
        public EEstudiante GetDatosEstudiante()
        {
            EEstudiante ObjEEstudiannteDevuelto = new EEstudiante();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
                string query = "Select  * from [Estudiante] LEFT JOIN Actor ON Actor.IdActor = Estudiante.IdActor where ";//@ para parametros

                if (!string.IsNullOrEmpty(ObjEEstudiante.Matricula))

                    query += "Estudiante.Matricula = @MatriculaP";
                else
                    query += "Actor.Nombre = @NombreP AND Actor.Apellido1 = @Apellido1P AND Actor.Apellido2 = @Apellido2P ";

                Comandosql = new SqlCommand(query, Meconecto);


                DataSet DatasetLleno = new DataSet();

                // Assumes that connection is a valid SqlConnection object.

                SqlDataAdapter adapter = new SqlDataAdapter(query, Meconecto);

                if (!string.IsNullOrEmpty(ObjEEstudiante.Matricula))
                    adapter.SelectCommand.Parameters.AddWithValue("@MatriculaP", ObjEEstudiante.Matricula);
                else
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@NombreP", ObjEEstudiante.objActor.Nombre);
                    adapter.SelectCommand.Parameters.AddWithValue("@Apellido1P", ObjEEstudiante.objActor.Apellido1);
                    adapter.SelectCommand.Parameters.AddWithValue("@Apellido2P", ObjEEstudiante.objActor.Apellido2);
                }





                //  DataSet DSUsuario = new DataSet();// dataset de usuario
                adapter.Fill(DatasetLleno, "Estudiante");               

                if (DatasetLleno.Tables[0].Rows.Count > 0)                
                {
                    DataRow DrLleno = DatasetLleno.Tables[0].Rows[0];
                    ObjEEstudiannteDevuelto.IdEstudiante = Convert.ToInt32(DrLleno["IdEstudiante"]);
                    ObjEEstudiannteDevuelto.Licenciatura = DrLleno["Licenciatura"].ToString();
                    ObjEEstudiannteDevuelto.Matricula = DrLleno["Matricula"].ToString();
                    ObjEEstudiannteDevuelto.Semestre = Convert.ToInt32(DrLleno["Semestre"]);
                    //ObjEEstudiannteDevuelto.IdTipo = Convert.ToInt32(DrLleno["IdTipo"]);
                    ObjEEstudiannteDevuelto.Escuela = DrLleno["Escuela"].ToString();
                    ObjEEstudiannteDevuelto.IdActor = Convert.ToInt32(DrLleno["IdActor"]);

                    ObjEEstudiannteDevuelto.objActor.IdActor = Convert.ToInt32(DrLleno["IdActor"]);
                    ObjEEstudiannteDevuelto.objActor.Nombre = DrLleno["Nombre"].ToString();
                    ObjEEstudiannteDevuelto.objActor.Apellido1 = DrLleno["Apellido1"].ToString();
                    ObjEEstudiannteDevuelto.objActor.Apellido2 = DrLleno["Apellido2"].ToString();
                    ObjEEstudiannteDevuelto.objActor.Correo = DrLleno["Correo"].ToString();
                    ObjEEstudiannteDevuelto.objActor.Telefono = Convert.ToInt64(DrLleno["Telefono"]);

                    ObjEEstudiannteDevuelto.objActor.ObjTipo.IdTipo = Convert.ToInt32(DrLleno["IdTipo"]);
                }
                   


                objConexionABD.CerrarConexion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
         
             return ObjEEstudiannteDevuelto; 
        }
        #endregion

        #region INSERTA DATOS ESTUDIANTE
        public EEstudiante AlmacenaDatosEstudiante()
        {
            int result = 0;
            EEstudiante objEEstudianteDevuelto = new EEstudiante();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
               

                DActor objDActor = new DActor(ObjEEstudiante.objActor);
                ObjEEstudiante.IdActor = objDActor.AlmacenaDatosActor();

                if(ObjEEstudiante.IdActor > 0)
                {
                    string query = "INSERT INTO  Estudiante (Matricula, Escuela, Licenciatura, Semestre, IdActor) VALUES (@MatriculaP, @EscuelaP, @LicenciaturaP, @SemestreP, @IdActorP);SELECT CAST(scope_identity() AS int)";  //para parametros y P para diferenciarlo
                    Comandosql = new SqlCommand(query, Meconecto);
                    Comandosql.Parameters.AddWithValue("@MatriculaP", ObjEEstudiante.Matricula);
                    Comandosql.Parameters.AddWithValue("@EscuelaP", ObjEEstudiante.Escuela);
                    Comandosql.Parameters.AddWithValue("@LicenciaturaP", ObjEEstudiante.Licenciatura);
                    Comandosql.Parameters.AddWithValue("@SemestreP", ObjEEstudiante.Semestre);
                    Comandosql.Parameters.AddWithValue("@IdActorP", ObjEEstudiante.IdActor);
                    //Comandosql.Parameters.AddWithValue("@IdTipoP", ObjEEstudiante.IdTipo);
                    //Comandosql.Parameters.AddWithValue("@IdTipoP", ObjEEstudiante.objActor.ObjTipo.IdTipo);

                    result = (int)Comandosql.ExecuteScalar();

                    //command.Parameters.AddWithValue("@ContraseñaC", ObjAdminModelo.Contraseña);
                    // int result = command.ExecuteNonQuery();
                }

                objConexionABD.CerrarConexion();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            objEEstudianteDevuelto.IdEstudiante = result;
            objEEstudianteDevuelto.IdActor = ObjEEstudiante.IdActor;
            objEEstudianteDevuelto.objActor.IdActor = ObjEEstudiante.IdActor;

            return objEEstudianteDevuelto;
        }
        #endregion

        #region ACTUALIZAR DATOS DEL ESTUDIANTE
        public bool actualizaDatosEstudiante()
        {
            //EEstudiante objEEstudianteDevuelto = new EEstudiante();
            int result = 0;
            ConexionesABD objConexionABD = new ConexionesABD();            

            try
            {
                Meconecto = objConexionABD.Meconecto;
                DActor objDActor = new DActor(ObjEEstudiante.objActor);

                objDActor.actualizaDatosActor();

                string query = "UPDATE Estudiante SET Matricula = @MatriculaP, Escuela = @EscuelaP, Licenciatura = @LicenciaturaP, Semestre = @SemestreP WHERE IdEstudiante = @IdEstudianteP ";  //para parametros y P para diferenciarlo
                Comandosql = new SqlCommand(query, Meconecto);
                Comandosql.Parameters.AddWithValue("@MatriculaP", ObjEEstudiante.Matricula);
                Comandosql.Parameters.AddWithValue("@EscuelaP", ObjEEstudiante.Escuela);
                Comandosql.Parameters.AddWithValue("@LicenciaturaP", ObjEEstudiante.Licenciatura);
                Comandosql.Parameters.AddWithValue("@SemestreP", ObjEEstudiante.Semestre);
                Comandosql.Parameters.AddWithValue("@IdEstudianteP", ObjEEstudiante.IdEstudiante);
                result = Comandosql.ExecuteNonQuery();


            }
            catch(Exception ex)
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


    }
}
