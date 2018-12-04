using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class InventarioEntrada
    {

        public static int InsertarInventarioEntrada(CInventarioEntrada objetoInventarioEntrada)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@InventarioEntradaID", SqlDbType.Int, 0, objetoInventarioEntrada.InventarioEntradaID),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, objetoInventarioEntrada.TipoInsumoDetalleID),
                    DBHelper.MakeParam("@UnidadMedidaID", SqlDbType.Int, 0, objetoInventarioEntrada.UnidadMedidaID),
                    DBHelper.MakeParam("@CantidadIngreso", SqlDbType.Int, 0, objetoInventarioEntrada.CantidadIngreso),
                    DBHelper.MakeParam("@CantidadEgreso", SqlDbType.Int, 0,objetoInventarioEntrada.CantidadEgreso),
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, objetoInventarioEntrada.AlmacenID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoInventarioEntrada.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@NumeroOrdenObservacion", SqlDbType.VarChar, 0, objetoInventarioEntrada.NumeroOrdenObservacion)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_InventarioEntrada_Insertar]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataSet ObtenerInventarioEntrada(int almacenID, int tipoInsumoID, int tipoInsumoDetalleID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, almacenID),
                    DBHelper.MakeParam("@TipoInsumoID", SqlDbType.Int, 0, tipoInsumoID),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, tipoInsumoDetalleID)
                };
            return DBHelper.ExecuteDataSet("usp_InventarioEntrada_ObtenerDetalleTotalInventario", dbParams);
        }
    }
}