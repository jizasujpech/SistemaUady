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
    public class DEmpleado
    {
        #region VARIABLES DE LA CLASE
        EEmpleado ObjEEmpleado;
        SqlConnection Meconecto;
        SqlCommand Comandosql;
        #endregion

        #region CONSTRUCTOR
        public DEmpleado(EEmpleado objEEmpleadoRecibido)
        {
            this.ObjEEmpleado = objEEmpleadoRecibido;
        }
        #endregion

        #region Obten Datos del Usuario/Get 
        //Se obtiene los datos del usuario por medio de objEacceso que se creo en el constructor
        public EEmpleado GetDatosEmpleado()
        {
            EEmpleado ObjEEmpleadoteDevuelto = new EEmpleado();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
                string query = "Select  * from [Empleado] LEFT JOIN Actor ON Actor.IdActor = Empleado.IdActor where ";//@ para parametros

                if (!string.IsNullOrEmpty(ObjEEmpleado.ClaveEmpleado))

                    query += "Empleado.ClaveEmpleado = @ClaveEmpleadoP";
                else
                {
                    string where = String.Empty;

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Nombre))
                        where = "Actor.Nombre = @NombreP ";

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Apellido1))
                    {
                        if (!String.IsNullOrEmpty(where))
                            where += "AND ";

                        where += "Actor.Apellido1 = @Apellido1P ";
                    }

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Apellido2))
                    {
                        if (!String.IsNullOrEmpty(where))
                            where += "AND ";

                        where += "Actor.Apellido2 = @Apellido2P ";
                    }

                    query += where;
                }

                Comandosql = new SqlCommand(query, Meconecto);


                DataSet DatasetLleno = new DataSet();

                // Assumes that connection is a valid SqlConnection object.

                SqlDataAdapter adapter = new SqlDataAdapter(query, Meconecto);

                if (!string.IsNullOrEmpty(ObjEEmpleado.ClaveEmpleado))
                    adapter.SelectCommand.Parameters.AddWithValue("@ClaveEmpleadoP", ObjEEmpleado.ClaveEmpleado);
                else
                {
                    if (!String.IsNullOrEmpty(ObjEEmpleado.Nombre))
                        adapter.SelectCommand.Parameters.AddWithValue("@NombreP", ObjEEmpleado.Nombre);

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Apellido1))
                        adapter.SelectCommand.Parameters.AddWithValue("@Apellido1P", ObjEEmpleado.Apellido1);

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Apellido2))
                        adapter.SelectCommand.Parameters.AddWithValue("@Apellido2P", ObjEEmpleado.Apellido2);
                }





                //  DataSet DSUsuario = new DataSet();// dataset de usuario
                adapter.Fill(DatasetLleno, "Empleado");

                if (DatasetLleno.Tables[0].Rows.Count > 0)
                {
                    DataRow DrLleno = DatasetLleno.Tables[0].Rows[0];
                    ObjEEmpleadoteDevuelto.IdEmpleado = Convert.ToInt32(DrLleno["IdEmpleado"]);
                    ObjEEmpleadoteDevuelto.Puesto = DrLleno["Puesto"].ToString();
                    ObjEEmpleadoteDevuelto.ClaveEmpleado = DrLleno["ClaveEmpleado"].ToString();
                    ObjEEmpleadoteDevuelto.Dependencia = DrLleno["Dependencia"].ToString();
                    //ObjEEmpleadoteDevuelto.IdTipo = Convert.ToInt32(DrLleno["IdTipo"]);
                    ObjEEmpleadoteDevuelto.Area = DrLleno["Area"].ToString();
                    ObjEEmpleadoteDevuelto.IdActor = Convert.ToInt32(DrLleno["IdActor"]);

                    ObjEEmpleadoteDevuelto.IdActor = Convert.ToInt32(DrLleno["IdActor"]);
                    ObjEEmpleadoteDevuelto.Nombre = DrLleno["Nombre"].ToString();
                    ObjEEmpleadoteDevuelto.Apellido1 = DrLleno["Apellido1"].ToString();
                    ObjEEmpleadoteDevuelto.Apellido2 = DrLleno["Apellido2"].ToString();
                    ObjEEmpleadoteDevuelto.Correo = DrLleno["Correo"].ToString();
                    ObjEEmpleadoteDevuelto.Telefono = Convert.ToInt64(DrLleno["Telefono"]);

                    ObjEEmpleadoteDevuelto.ObjTipo.IdTipo = Convert.ToInt32(DrLleno["IdTipo"]);
                }



                objConexionABD.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjEEmpleadoteDevuelto;
        }
        #endregion
        #region Obten Datos del Usuario/Get. DATATABLE 
        //Se obtiene los datos del usuario por medio de objEacceso que se creo en el constructor
        public DataTable GetDatosEmpleado_DataTable()
        {           
            DataTable dtResult = new DataTable();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;
                string query = "Select  * from [Empleado] LEFT JOIN Actor ON Actor.IdActor = Empleado.IdActor where ";//@ para parametros

                if (!string.IsNullOrEmpty(ObjEEmpleado.ClaveEmpleado))

                    query += "Empleado.ClaveEmpleado = @ClaveEmpleadoP";
                else
                {
                    string where = String.Empty;

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Nombre))
                        where = "Actor.Nombre = @NombreP ";
                     
                    if(!String.IsNullOrEmpty(ObjEEmpleado.Apellido1))
                    {
                        if (!String.IsNullOrEmpty(where))
                            where += "AND ";

                        where += "Actor.Apellido1 = @Apellido1P ";
                    }

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Apellido2))
                    {
                        if (!String.IsNullOrEmpty(where))
                            where += "AND ";

                        where += "Actor.Apellido2 = @Apellido2P ";
                    }

                    query += where;    
                }
                    

                Comandosql = new SqlCommand(query, Meconecto);           

                // Assumes that connection is a valid SqlConnection object.

                SqlDataAdapter adapter = new SqlDataAdapter(query, Meconecto);

                if (!string.IsNullOrEmpty(ObjEEmpleado.ClaveEmpleado))
                    adapter.SelectCommand.Parameters.AddWithValue("@ClaveEmpleadoP", ObjEEmpleado.ClaveEmpleado);
                else
                {
                    if (!String.IsNullOrEmpty(ObjEEmpleado.Nombre))
                        adapter.SelectCommand.Parameters.AddWithValue("@NombreP", ObjEEmpleado.Nombre);

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Apellido1))
                        adapter.SelectCommand.Parameters.AddWithValue("@Apellido1P", ObjEEmpleado.Apellido1);

                    if (!String.IsNullOrEmpty(ObjEEmpleado.Apellido2))
                        adapter.SelectCommand.Parameters.AddWithValue("@Apellido2P", ObjEEmpleado.Apellido2);
                }

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

        #region INSERTA DATOS EMPLEADO
        public EEmpleado AlmacenaDatosEmpleado()
        {
            int result = 0;
            EEmpleado objEEmpleadoDevuelto = new EEmpleado();
            try
            {
                ConexionesABD objConexionABD = new ConexionesABD();
                Meconecto = objConexionABD.Meconecto;


                DActor objDActor = new DActor(ObjEEmpleado);
                ObjEEmpleado.IdActor = objDActor.AlmacenaDatosActor();

                if (ObjEEmpleado.IdActor > 0)
                {
                    string query = "INSERT INTO  Empleado (ClaveEmpleado, Dependencia, Area, Puesto, IdActor) VALUES (@ClaveEmpleadoP, @DependenciaP, @AreaP, @PuestoP, @IdActorP);SELECT CAST(scope_identity() AS int)";  //para parametros y P para diferenciarlo
                    Comandosql = new SqlCommand(query, Meconecto);
                    Comandosql.Parameters.AddWithValue("@ClaveEmpleadoP", ObjEEmpleado.ClaveEmpleado);
                    Comandosql.Parameters.AddWithValue("@DependenciaP", ObjEEmpleado.Dependencia);
                    Comandosql.Parameters.AddWithValue("@AreaP", ObjEEmpleado.Area);
                    Comandosql.Parameters.AddWithValue("@PuestoP", ObjEEmpleado.Puesto);
                    Comandosql.Parameters.AddWithValue("@IdActorP", ObjEEmpleado.IdActor);
                    //Comandosql.Parameters.AddWithValue("@IdTipoP", ObjEEmpleado.IdTipo);
                    //Comandosql.Parameters.AddWithValue("@IdTipoP", ObjEEmpleado.objActor.ObjTipo.IdTipo);

                    result = (int)Comandosql.ExecuteScalar();

                    //command.Parameters.AddWithValue("@ContraseñaC", ObjAdminModelo.Contraseña);
                    // int result = command.ExecuteNonQuery();
                }

                objConexionABD.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            objEEmpleadoDevuelto.IdEmpleado = result;
            objEEmpleadoDevuelto.IdActor = ObjEEmpleado.IdActor;

            return objEEmpleadoDevuelto;
        }
        #endregion

        #region ACTUALIZAR DATOS DEL EMPLEADO
        public bool actualizaDatosEmpleado()
        {
            //EEstudiante objEEstudianteDevuelto = new EEstudiante();
            int result = 0;
            ConexionesABD objConexionABD = new ConexionesABD();

            try
            {
                Meconecto = objConexionABD.Meconecto;
                DActor objDActor = new DActor(ObjEEmpleado);

                objDActor.actualizaDatosActor();

                string query = "UPDATE Empleado SET ClaveEmpleado = @ClaveEmpleadoP, Dependencia = @DependenciaP, Area = @AreaP, Puesto = @PuestoP WHERE IdEmpleado = @IdEmpleadoP";
                Comandosql = new SqlCommand(query, Meconecto);
                Comandosql.Parameters.AddWithValue("@ClaveEmpleadoP", ObjEEmpleado.ClaveEmpleado);
                Comandosql.Parameters.AddWithValue("@DependenciaP", ObjEEmpleado.Dependencia);
                Comandosql.Parameters.AddWithValue("@AreaP", ObjEEmpleado.Area);
                Comandosql.Parameters.AddWithValue("@PuestoP", ObjEEmpleado.Puesto);
                Comandosql.Parameters.AddWithValue("@IdEmpleadoP", ObjEEmpleado.IdEmpleado);
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
