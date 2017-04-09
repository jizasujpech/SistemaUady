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

 public   class ConexionesABD
    {
       public SqlConnection Meconecto = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectarASQL"].ConnectionString);
        //   SqlConnection ConexionASql;// para conectar
        //SqlCommand Comandosql; //leer consultar eliminar insertar update en sql
       #region CONSTRUCTOR //Abre conexion
        public ConexionesABD()

        {
              AbrirConexion();
        }
        #endregion
        #region Destructor //Aqui se cierra la conexion
        ~ConexionesABD()
        {
          //  CerrarConexion();
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
       public void CerrarConexion()
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


        }






    }
}
