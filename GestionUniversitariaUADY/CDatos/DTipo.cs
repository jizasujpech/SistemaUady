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
    public class DTipo
    {

        SqlConnection Meconecto;  //=  new SqlConnection(ConfigurationManager.ConnectionStrings["ConectarASQL"].ConnectionString);
        SqlCommand Comandosql; //leer consultar eliminar insertar update en sql        //   SqlConnection ConexionASql;// para conectar
        ETipo ObjDTipo;
       
        public DTipo(ETipo ObjDTipoNew)
        {
            this.ObjDTipo = ObjDTipoNew;
            conectar();
        }

        void conectar()
        {
            try
            {
                Meconecto = new SqlConnection();
                Meconecto.ConnectionString = ConfigurationManager.ConnectionStrings["ConectarASQL"].ConnectionString;
                Meconecto.Open();
            }
            catch (Exception e)
            {
              throw e;
            }

        }

        public bool InsertaDato() //query es la sentencia sql que vas a ejecutar puede ir cualquier nombre
        {
            int result = 0;
            string query = "INSERT INTO  Tipo (Descripcion) VALUES (@DescripcionP)";//@ para parametros y P para diferenciarlo
            Comandosql = new SqlCommand(query, Meconecto);
            Comandosql.Parameters.AddWithValue("@DescripcionP", ObjDTipo.Descripcion);

            result = Comandosql.ExecuteNonQuery();

            //command.Parameters.AddWithValue("@ContraseñaC", ObjAdminModelo.Contraseña);
            // int result = command.ExecuteNonQuery();

            return result > 0;
        }
        public DataTable ConsultaTipos()
        {
            DataSet DataCampos = new DataSet();

            try
           {
                string query = "select IdTipo, Descripcion FroM Tipo ";
                SqlDataAdapter ElqueLlenaTabla = new SqlDataAdapter(query, Meconecto);

                ElqueLlenaTabla.Fill(DataCampos, "Tipo");

           }
            catch (Exception ex)
            {
              throw ex;

            }

            return DataCampos.Tables["Tipo"];
        }




    }
}
