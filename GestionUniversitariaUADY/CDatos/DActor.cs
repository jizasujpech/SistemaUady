using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CEntidades;
//using CDatos;
using System.Data.SqlClient;

namespace CDatos
{
    public class DActor
    {
        EActor ObjEActor;
        SqlConnection Meconecto;
        SqlCommand Comandosql;

        public DActor(EActor ObjEActorRecibido)// aqui decimos que la clase DActor siempre va a recibir datos de EActor por
        {                                      //medio de la variable de objEactorRecibido
            this.ObjEActor = ObjEActorRecibido;
        }
        #region ALMACENA DATOS DEL ACTOR
        public int AlmacenaDatosActor()
        {
            ConexionesABD objConexionABD = new ConexionesABD();
            Meconecto = objConexionABD.Meconecto;
            int result = 0;
            string query = "INSERT INTO  Actor (Nombre, Apellido1, Apellido2, Telefono, Correo, IdTipo) VALUES (@NombreP, @Apellido1P, @Apellido2P, @TelefonoP, @CorreoP, @IdTipoP);SELECT CAST(scope_identity() AS int)";//@ para parametros y P para diferenciarlo
            Comandosql = new SqlCommand(query, Meconecto);
            Comandosql.Parameters.AddWithValue("@NombreP", ObjEActor.Nombre);
            Comandosql.Parameters.AddWithValue("@Apellido1P", ObjEActor.Apellido1);
            Comandosql.Parameters.AddWithValue("@Apellido2P", ObjEActor.Apellido2);
            Comandosql.Parameters.AddWithValue("@TelefonoP", ObjEActor.Telefono);
            Comandosql.Parameters.AddWithValue("@CorreoP", ObjEActor.Correo);
            Comandosql.Parameters.AddWithValue("@IdTipoP", ObjEActor.ObjTipo.IdTipo);

            result = (int)Comandosql.ExecuteScalar();

            //command.Parameters.AddWithValue("@ContraseñaC", ObjAdminModelo.Contraseña);
            // int result = command.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region ACTUALIZAR DATOS DEL ACTOR
        public bool actualizaDatosActor()
        {
            //EEstudiante objEEstudianteDevuelto = new EEstudiante();
            int result = 0;
            ConexionesABD objConexionABD = new ConexionesABD();

            try
            {
                Meconecto = objConexionABD.Meconecto;

                string query = "UPDATE ACTOR SET Nombre = @NombreP, Apellido1 = @Apellido1P, Apellido2 = @Apellido2P, Telefono = @TelefonoP, Correo = @CorreoP WHERE IdActor = @IdActorP";
                Comandosql = new SqlCommand(query, Meconecto);
                Comandosql.Parameters.AddWithValue("@NombreP", ObjEActor.Nombre);
                Comandosql.Parameters.AddWithValue("@Apellido1P", ObjEActor.Apellido1);
                Comandosql.Parameters.AddWithValue("@Apellido2P", ObjEActor.Apellido2);
                Comandosql.Parameters.AddWithValue("@TelefonoP", ObjEActor.Telefono);
                Comandosql.Parameters.AddWithValue("@CorreoP", ObjEActor.Correo);
                Comandosql.Parameters.AddWithValue("@IdActorP", ObjEActor.IdActor);
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

    }
}
