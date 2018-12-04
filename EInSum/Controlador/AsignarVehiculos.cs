using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class AsignarVehiculos
    {
        public static int InsertarAsignarVehiculo(CAsignarVehiculos objetoAsignarVehiculos)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@OrganizacionAsignarVehiculoID", SqlDbType.Int, 0, objetoAsignarVehiculos.OrganizacionAsignarVehiculoID),
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, objetoAsignarVehiculos.OrganizacionID),
                    DBHelper.MakeParam("@OrganizacionBeneficiarioID", SqlDbType.Int, 0, objetoAsignarVehiculos.OrganizacionBeneficiarioID),
                    DBHelper.MakeParam("@Placa", SqlDbType.VarChar, 0, objetoAsignarVehiculos.Placa),
                    DBHelper.MakeParam("@TipoVehiculoID", SqlDbType.Int, 0,objetoAsignarVehiculos.TipoVehiculoID ),
                    DBHelper.MakeParam("@SerialCarroceria", SqlDbType.VarChar, 0, objetoAsignarVehiculos.SerialCarroceria),
                    DBHelper.MakeParam("@Puestos", SqlDbType.Int, 0, objetoAsignarVehiculos.Puestos),
                    DBHelper.MakeParam("@AñoVehiculo", SqlDbType.Int, 0, objetoAsignarVehiculos.AñoVehiculo),
                    DBHelper.MakeParam("@TipoPrestacionServicioVehiculoID", SqlDbType.Int, 0, objetoAsignarVehiculos.TipoPrestacionServicioVehiculoID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoAsignarVehiculos.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@SerialMotor", SqlDbType.VarChar, 0, objetoAsignarVehiculos.SerialMotor),
                    DBHelper.MakeParam("@ColorID", SqlDbType.Int, 0, objetoAsignarVehiculos.ColorID),
                    DBHelper.MakeParam("@Ruta", SqlDbType.VarChar, 0, objetoAsignarVehiculos.Ruta),
                    DBHelper.MakeParam("@ModeloVehiculoID", SqlDbType.Int, 0, objetoAsignarVehiculos.ModeloVehiculoID)
                };

                //Se comentó debido a que no esta bien probado
                //EstablecerEstadoOrganizacion(objetoAsignarVehiculos.OrganizacionID, objetoAsignarVehiculos.CodigoEstado);
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_AsignarVehiculos_Insertar]", dbParams));
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataSet ObtenerVehiculosAsignadosBeneficiario(int organizacionAsignarVehiculoID, int organizacionBeneficiarioID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@OrganizacionAsignarVehiculoID", SqlDbType.Int, 0, organizacionAsignarVehiculoID),
                    DBHelper.MakeParam("@OrganizacionBeneficiarioID", SqlDbType.Int, 0, organizacionBeneficiarioID)
                };
            return DBHelper.ExecuteDataSet("usp_AsignarVehiculos_ObtenerVehiculosAsignadosBeneficiario", dbParams);
        }
        public static DataSet ObtenerVehiculosAsignadosOrganizacion(int organizacionID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, organizacionID)

                };
            return DBHelper.ExecuteDataSet("usp_AsignarVehiculos_ObtenerVehiculosAsignadosOrganizacion", dbParams);
        }
        public static int EliminarVehiculoAsignado(int organizacionAsignarVehiculoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@OrganizacionAsignarVehiculoID", SqlDbType.Int, 0, organizacionAsignarVehiculoID)
                };
            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_AsignarVehiculos_EliminarVehiculoAsignadoBeneficiario", dbParams));
        }

        public static bool EsPlacaAsignada(string placa)
        {
            bool resultado = false;
            SqlDataReader dr = ObtenerPlacaAsignada(placa);
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    resultado = true;
                }
            }
            return resultado;

        }
        public static SqlDataReader ObtenerPlacaAsignada(string placa)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Placa", SqlDbType.VarChar, 0, placa)
                };
            return DBHelper.ExecuteDataReader("usp_AsignarVehiculos_ObtenerPlacaAsignada", dbParams);
        }
        private static void EstablecerEstadoOrganizacion(int codigoOrganizacion, int codigoEstado)
        {
            int codigoDeEstadoOrganizacion;
            SqlDataReader dr;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand command = null;
            dr = Organizacion.ObtenerDatosOrganizacion(codigoOrganizacion);
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    codigoDeEstadoOrganizacion = CodigoEstadoSegunCodigoParroquia(Convert.ToInt32(dr["ParroquiaID"]));
                    if (codigoDeEstadoOrganizacion != codigoEstado)
                    {
                        string updateQuery = "UPDATE Organizacion SET ParroquiaID = " + CodigoParroquiaSegunCodigoEstado(codigoEstado) + " WHERE OrganizacionID = " + codigoOrganizacion;
                        cn.Open();
                        command = new SqlCommand(updateQuery, cn);
                        var commandResult = command.ExecuteScalar();
                        command.Dispose();
                        cn.Close();
                        cn.Dispose();
                    }
                }

            }
        }
        private static int CodigoEstadoSegunCodigoParroquia(int codigoParroquia)
        {
            string consultaSQL = "SELECT  dbo.Parroquia.ParroquiaID, dbo.Municipio.EstadoID FROM dbo.Parroquia INNER JOIN  dbo.Municipio ON dbo.Parroquia.MunicipioID = dbo.Municipio.MunicipioID WHERE(dbo.Parroquia.ParroquiaID = "+ codigoParroquia+")";
            int resultado = 0;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("connectionString"));
            cn.Open();
            SqlCommand command = new SqlCommand(consultaSQL, cn);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    resultado = Convert.ToInt32(dr["EstadoID"]);
                    break;
                }
            }
            command.Dispose();
            cn.Close();
            cn.Dispose();
            return resultado;
        }
        private static int CodigoParroquiaSegunCodigoEstado(int codigoEstado)
        {
            string consultaSQL = "SELECT  dbo.Parroquia.ParroquiaID, dbo.Municipio.EstadoID FROM dbo.Parroquia INNER JOIN  dbo.Municipio ON dbo.Parroquia.MunicipioID = dbo.Municipio.MunicipioID WHERE dbo.Municipio.EstadoID =" + codigoEstado;
            int resultado = 0;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("connectionString"));
            cn.Open();
            SqlCommand command = new SqlCommand(consultaSQL, cn);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    resultado = Convert.ToInt32(dr["ParroquiaID"]);
                    break;
                }
            }
            command.Dispose();
            cn.Close();
            cn.Dispose();
            return resultado;
        }
    }
}