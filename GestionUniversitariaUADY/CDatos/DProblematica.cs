using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CEntidades;
using System.Data.SqlClient;

namespace CDatos
{
   public class DProblematica
    {
        EProblematica ObjEProblematica;
        SqlConnection Meconecto;
        SqlCommand Comandosql;

        public DProblematica(EProblematica ObjEProblematicaRecibido)// aqui decimos que la clase DActor siempre va a recibir datos de EActor por
        {                                      //medio de la variable de objEactorRecibido
            this.ObjEProblematica = ObjEProblematicaRecibido;
        }
        #region INSERT PROBLEMATICA
        public bool AlmacenaDatosProblematica()
        {
            ConexionesABD objConexionABD = new ConexionesABD();
            Meconecto = objConexionABD.Meconecto;
            int result = 0;
            string query = "INSERT INTO  Problematica (IdUsuario, Fecha, Situacion, ActoresInvolucrados, Procedimiento, ResponsableDeSolucion, Seguimiento, Conclusion, Evaluacion, Comentarios, Satisfaccion, Tema, Atendio, Semaforo, IdActor ) VALUES (@IdUsuarioP, @FechaP, @SituacionP, @ActoresInvolucradosP, @ProcedimientoP, @ResponsableDeSolucionP, @SeguimientoP, @ConclusionP, @EvaluacionP, @ComentariosP, @SatisfaccionP, @TemaP, @AtendioP, @Semaforo, @IdActor)";//@ para parametros y P para diferenciarlo
            Comandosql = new SqlCommand(query, Meconecto);
            Comandosql.Parameters.AddWithValue("@FechaP", ObjEProblematica.Fecha);
            Comandosql.Parameters.AddWithValue("@SituacionP", ObjEProblematica.Situacion);
            Comandosql.Parameters.AddWithValue("@ActoresInvolucradosP", ObjEProblematica.ActoresInvolucrados);
            Comandosql.Parameters.AddWithValue("@ProcedimientoP", ObjEProblematica.Procedimiento);
            Comandosql.Parameters.AddWithValue("@ResponsableDeSolucionP", ObjEProblematica.ResponsableDeSolucion);
            Comandosql.Parameters.AddWithValue("@SeguimientoP", ObjEProblematica.Seguimiento);
            Comandosql.Parameters.AddWithValue("@ConclusionP", ObjEProblematica.Conclusion);
            Comandosql.Parameters.AddWithValue("@EvaluacionP", ObjEProblematica.Evaluacion);
            Comandosql.Parameters.AddWithValue("@ComentariosP", ObjEProblematica.Comentarios);
            Comandosql.Parameters.AddWithValue("@SatisfaccionP", ObjEProblematica.Satisfaccion);
            Comandosql.Parameters.AddWithValue("@TemaP", ObjEProblematica.Tema);
            Comandosql.Parameters.AddWithValue("@AtendioP", ObjEProblematica.Atendio);
            Comandosql.Parameters.AddWithValue("@Semaforo", ObjEProblematica.Semaforo);
            Comandosql.Parameters.AddWithValue("@IdActor", ObjEProblematica.idActor);

            if (ObjEProblematica.ObjEAcceso.IdUsuario > 0)
                Comandosql.Parameters.AddWithValue("@IdUsuarioP", ObjEProblematica.ObjEAcceso.IdUsuario);
            else
            {
                DAcceso ObjDAcceso = new DAcceso(ObjEProblematica.ObjEAcceso);
                int IdUsuario = ObjDAcceso.GetDatosUsuarios().IdUsuario;
                Comandosql.Parameters.AddWithValue("@IdUsuarioP",IdUsuario);
            }
            result = Comandosql.ExecuteNonQuery();

            //command.Parameters.AddWithValue("@ContraseñaC", ObjAdminModelo.Contraseña);
            // int result = command.ExecuteNonQuery();

            return result > 0;
        }
        #endregion
        #region GET ID SIGUIENTE PROBLEMATICA
        public int getIDSiguienteProblematica()
        {
            int result = 0;

            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
                string query = "SELECT MAX(ClaveDeSeguimiento) Clave FROM Problematica";
                Comandosql = new SqlCommand(query, Meconecto);


                using (SqlDataReader reader = Comandosql.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        //TxtFarmerName.Text = (string)reader[0];
                        if (!reader["Clave"].Equals(System.DBNull.Value))
                        {
                            result = (int)reader["Clave"];
                            result++;
                        }
                        else
                            result = 1001;
                        
                    }

                    reader.Close();
                }

                objConexionABD.CerrarConexion();

            }
            catch(Exception e)
            {
                throw e;
            }


            return result;
        }
        #endregion


    }
}
 
