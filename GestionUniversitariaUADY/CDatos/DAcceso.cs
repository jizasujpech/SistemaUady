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
    public class DAcceso
    {
        SqlConnection Meconecto;  //=  new SqlConnection(ConfigurationManager.ConnectionStrings["ConectarASQL"].ConnectionString);
     //   SqlConnection ConexionASql;// para conectar
        SqlCommand Comandosql; //leer consultar eliminar insertar update en sql
        EAcceso ObjEAcceso ;
       #region CONSTRUCTOR //Abre conexion
        public DAcceso (EAcceso ObjDAccesoNew)
        {
            this.ObjEAcceso = ObjDAccesoNew;
           
            //   AbrirConexion();
        }
        #endregion

        #region Basura
        /*   #endregion
           #region Destructor //Aqui se cierra la conexion
           ~DAcceso()
           {
               CerrarConexion();
           }
           #endregion  

           void AbrirConexion()
           {
               try
               {
                   if (Meconecto.State == ConnectionState.Closed)
                       Meconecto.Open();
               }
               catch (Exception e)
               {
                   throw e;
               }

           }
           void CerrarConexion()
           {
               try
               {
                 //  ConexionASql = new SqlConnection();
                   if (Meconecto.State == ConnectionState.Open)
                       Meconecto.Close();
               }
               catch (Exception e)
               {
                   throw e;
               }


           } */
        #endregion

        #region Valida Usuario
        public bool ValidarUsuario()
        {
            ConexionesABD objConexionABD = new ConexionesABD();
            Meconecto = objConexionABD.Meconecto;

            int result = 0;
            string query = "Select  IdUsuario from [Usuario] where UsuarioS = @UsuarioC and Contraseña = @ContraseñaC";//@ para parametros
            Comandosql = new SqlCommand(query, Meconecto);
            Comandosql.Parameters.AddWithValue("@UsuarioC", ObjEAcceso.UsuarioS);
            Comandosql.Parameters.AddWithValue("@ContraseñaC", ObjEAcceso.Contraseña);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = Comandosql.ExecuteReader())
            {
                if (reader.Read())
                {

                    //TxtFarmerName.Text = (string)reader[0];
                    result = (int)reader["IdUsuario"];
                }

                reader.Close();
            }

            objConexionABD.CerrarConexion();
        
            return result > 0;
        }
        #endregion

        #region Obten Datos del Usuario/Get 
        //Se obtiene los datos del usuario por medio de objEacceso que se creo en el constructor
        public EAcceso GetDatosUsuarios()
        {
            ConexionesABD objConexionABD = new ConexionesABD();
            Meconecto = objConexionABD.Meconecto;
            string query = "Select  * from [Usuario] where ";//@ para parametros

            if (ObjEAcceso.IdUsuario > 0)

                query += "IdUsuario = @IdUsuarioP";
            else
                query += "UsuarioS = @UsuarioP";

                Comandosql = new SqlCommand(query, Meconecto); 
            
         
            DataSet DatasetLleno = new DataSet();

            // Assumes that connection is a valid SqlConnection object.
           
            SqlDataAdapter adapter = new SqlDataAdapter(query, Meconecto);

            if (ObjEAcceso.IdUsuario > 0)
                adapter.SelectCommand.Parameters.AddWithValue("@IdUsuarioP", ObjEAcceso.IdUsuario);
            else
                adapter.SelectCommand.Parameters.AddWithValue("@UsuarioP", ObjEAcceso.UsuarioS);


           

          //  DataSet DSUsuario = new DataSet();// dataset de usuario
            adapter.Fill(DatasetLleno, "Usuario");

            EAcceso ObjEAccesoDevuelto = new EAcceso();
            DataRow DrLleno = DatasetLleno.Tables[0].Rows[0];
            ObjEAccesoDevuelto.IdUsuario=Convert.ToInt32( DrLleno["IdUsuario"]);
            ObjEAccesoDevuelto.Nombre = DrLleno["Nombre"].ToString();
            ObjEAccesoDevuelto.Apellido1 = DrLleno["ApellidoP"].ToString();
            ObjEAccesoDevuelto.Apellido2 = DrLleno["ApellidoM"].ToString();
            ObjEAccesoDevuelto.UsuarioS = DrLleno["UsuarioS"].ToString();
            ObjEAccesoDevuelto.Contraseña = DrLleno["Contraseña"].ToString();


            return ObjEAccesoDevuelto;
        }
        #endregion

    }
}
