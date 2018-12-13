using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class EntregaInsumoDetalleJornada
    {
        public static int InsertarEntregaDetalleInsumoJornada(CEntregaInsumoDetalleJornada objetoEntregaInsumoDetalleJornada, int almacenID)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoDetalleID", SqlDbType.Int, 0, objetoEntregaInsumoDetalleJornada.EntregaInsumoDetalleID),
                    DBHelper.MakeParam("@EntregaInsumoID", SqlDbType.Int, 0, objetoEntregaInsumoDetalleJornada.EntregaInsumoID),
                    DBHelper.MakeParam("@Placa", SqlDbType.VarChar, 0, objetoEntregaInsumoDetalleJornada.Placa),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, objetoEntregaInsumoDetalleJornada.TipoInsumoDetalleID),
                    DBHelper.MakeParam("@UnidadMedidaID", SqlDbType.Int, 0,objetoEntregaInsumoDetalleJornada.UnidadMedidaID),
                    DBHelper.MakeParam("@CantidadEntregaInsumo", SqlDbType.Int, 0, objetoEntregaInsumoDetalleJornada.CantidadEntregaInsumo),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoEntregaInsumoDetalleJornada.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, almacenID)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_EntregaInsumoDetalle_Insertar]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int ActualizarPlacaRecepcionInsumo(string placa, int seguridadUsuarioDatosDespachoID)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Placa", SqlDbType.VarChar, 0, placa),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosDespachoID", SqlDbType.Int, 0, seguridadUsuarioDatosDespachoID)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_EntregaInsumoDetalle_PlacaRecepcionInsumo]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataSet ObtenerDetalleEntregaJornada(int entregaInsumoID, string placa,int organizacionID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoID", SqlDbType.Int, 0, entregaInsumoID),
                    DBHelper.MakeParam("@Placa", SqlDbType.VarChar, 0, placa),
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, organizacionID)
                };
            return DBHelper.ExecuteDataSet("usp_EntregaInsumoDetalleJornada_ObtenerDetalleEntregaJornada", dbParams);
        }
        public static DataSet ObtenerDetalleEntregaJornadaOrganizacion(int entregaInsumoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoID", SqlDbType.Int, 0, entregaInsumoID)
                };
            return DBHelper.ExecuteDataSet("usp_EntregaInsumoDetalleJornada_ObtenerDetalleEntregaJornadaOrganizacion", dbParams);
        }

        public static SqlDataReader ObtenerPlacaConInsumoAsignado(string placa, int tipoInsumoDetalleID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Placa", SqlDbType.VarChar, 0, placa),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, tipoInsumoDetalleID)
                };
            return DBHelper.ExecuteDataReader("usp_EntregaInsumoDetalleJornada_ObtenerPlacaConInsumoAsignado", dbParams);
        }
        public static SqlDataReader ObtenerPlacaConInsumoEntregado(int entregaInsumoDetalleID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoDetalleID", SqlDbType.Int, 0, entregaInsumoDetalleID)
                };
            return DBHelper.ExecuteDataReader("usp_EntregaInsumoDetalleJornada_ObtenerPlacaConInsumoEntregado", dbParams);
        }
    }
}