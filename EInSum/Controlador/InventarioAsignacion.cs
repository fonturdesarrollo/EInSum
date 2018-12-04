using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class InventarioAsignacion
    {

        public static int InsertarInventarioAsignacion(CInventarioAsignacion objetoInventarioAsignacion)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@InventarioAsignacionID", SqlDbType.Int, 0, objetoInventarioAsignacion.InventarioAsignacionID),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, objetoInventarioAsignacion.TipoInsumoDetalleID),
                    DBHelper.MakeParam("@UnidadMedidaID", SqlDbType.Int, 0, objetoInventarioAsignacion.UnidadMedidaID),
                    DBHelper.MakeParam("@CantidadIngresoAsignacion", SqlDbType.Int, 0, objetoInventarioAsignacion.CantidadIngresoAsignacion),
                    DBHelper.MakeParam("@CantidadEngresoAsignacion", SqlDbType.Int, 0,objetoInventarioAsignacion.CantidadEngresoAsignacion),
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, objetoInventarioAsignacion.AlmacenID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoInventarioAsignacion.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("NumeroOrdenObservacion", SqlDbType.VarChar, 0, objetoInventarioAsignacion.NumeroOrdenObservacion)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_InventarioAsignacion_Insertar]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataSet ObtenerInventarioAsignacion(int almacenID, int tipoInsumoID, int tipoInsumoDetalleID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, almacenID),
                    DBHelper.MakeParam("@TipoInsumoID", SqlDbType.Int, 0, tipoInsumoID),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, tipoInsumoDetalleID)
                };
            return DBHelper.ExecuteDataSet("usp_InventarioAsignacion_ObtenerDetalleTotalInventarioAsignacion", dbParams);
        }
        public static SqlDataReader ObtenerInsumoAlmacenPrincipal(int TipoInsumoDetalleID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, TipoInsumoDetalleID)
                };
            return DBHelper.ExecuteDataReader("usp_InventarioAsignacion_ObtenerTotalItemDisponibleAlmacenPrincipal", dbParams);
        }
        public static SqlDataReader ObtenerInsumoAlmacenSecundario(int TipoInsumoDetalleID, int almacenID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, TipoInsumoDetalleID),
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, TipoInsumoDetalleID)
                };
            return DBHelper.ExecuteDataReader("usp_InventarioAsignacion_ObtenerItemDisponibleEnAlmacen", dbParams);
        }
    }
}