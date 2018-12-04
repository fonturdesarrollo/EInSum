using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class Organizacion
    {
        public static int InsertarOrganizacion(COrganizacion objetoOrganizacion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, objetoOrganizacion.OrganizacionID),
                    DBHelper.MakeParam("@RifOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.RifOrganizacion),
                    DBHelper.MakeParam("@NombreOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.NombreOrganizacion),
                    DBHelper.MakeParam("@TipoOrganizacionID", SqlDbType.Int, 0, objetoOrganizacion.TipoOrganizacionID),
                    DBHelper.MakeParam("@ParroquiaID", SqlDbType.Int, 0,objetoOrganizacion.ParroquiaID),
                    DBHelper.MakeParam("@TelefonoLocalOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.TelefonoLocalOrganizacion),
                    DBHelper.MakeParam("@TelefonoCelularOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.TelefonoCelularOrganizacion),
                    DBHelper.MakeParam("@EmailOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.EmailOrganizacion),
                    DBHelper.MakeParam("@DireccionOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.DireccionOrganizacion),
                    DBHelper.MakeParam("@CedulaPresidente", SqlDbType.Int, 0, objetoOrganizacion.CedulaPresidente),
                    DBHelper.MakeParam("@NombrePresidente", SqlDbType.VarChar, 0, objetoOrganizacion.NombrePresidente),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoOrganizacion.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@BloqueID", SqlDbType.Int, 0,objetoOrganizacion.BloqueID)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Organizacion_Insertar]", dbParams));
        }
        public static SqlDataReader ObtenerDatosOrganizacion(int OrganizacionID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, @OrganizacionID)
                };
            return DBHelper.ExecuteDataReader("usp_Organizacion_ObtenerOrganizacion", dbParams);
        }
        public static DataSet ObtenerDatosOrganizacionPorEstadoBloque(int codigoEstado, int codigoBloque)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EstadoID", SqlDbType.Int, 0, codigoEstado),
                    DBHelper.MakeParam("@BloqueID", SqlDbType.Int, 0, codigoBloque)
                };
            return DBHelper.ExecuteDataSet("usp_Organizacion_ObtenerOrganizacionPorEstadoBloque", dbParams);
        }
        public static int ActualizarEjeOrganizacion(COrganizacion objetoOrganizacion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, objetoOrganizacion.OrganizacionID),
                    DBHelper.MakeParam("@EjeID", SqlDbType.Int, 0,objetoOrganizacion.EjeID)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Organizacion_ActualizarEjeOrganizacion]", dbParams));
        }
    }
}