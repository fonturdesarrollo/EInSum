using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class Almacen
    {
        public static int InsertarAlmacen(CAlmacen objetoAlmacen)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, objetoAlmacen.AlmacenID),
                    DBHelper.MakeParam("@NombreAlmacen", SqlDbType.VarChar, 0, objetoAlmacen.NombreAlmacen),
                    DBHelper.MakeParam("@EstadoID", SqlDbType.Int, 0, objetoAlmacen.EstadoID),
                    DBHelper.MakeParam("@DireccionAlmacen", SqlDbType.VarChar, 0, objetoAlmacen.DireccionAlmacen),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoAlmacen.SeguridadUsuarioDatosID)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Almacen_Insertar]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet ObtenerAlmacenes()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return DBHelper.ExecuteDataSet("usp_Almacen_ObtenerAlmacenes", dbParams);
        }
    }
}