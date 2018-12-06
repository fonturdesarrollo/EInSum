using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class EntregaInsumoJornada
    {
        public static int InsertarEntregaInsumoJornada(CEntregaInsumoJornada objetoEntregaInsumoJornada)
        {
            try
            {
                DateTime fechaDeJornada = Convert.ToDateTime(objetoEntregaInsumoJornada.FechaJornada);
                string fechaConvertida = fechaDeJornada.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoID", SqlDbType.Int, 0, objetoEntregaInsumoJornada.EntregaInsumoID),
                    DBHelper.MakeParam("@FechaJornada", SqlDbType.SmallDateTime, 0, fechaConvertida),
                    DBHelper.MakeParam("@NombreJornada", SqlDbType.VarChar, 0, objetoEntregaInsumoJornada.NombreJornada),
                    DBHelper.MakeParam("@EstadoID", SqlDbType.Int, 0, objetoEntregaInsumoJornada.EstadoID),
                    DBHelper.MakeParam("@DireccionEntregaInsumo", SqlDbType.VarChar, 0,objetoEntregaInsumoJornada.DireccionEntregaInsumo),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoEntregaInsumoJornada.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@EstatusEntregaInsumo", SqlDbType.VarChar, 0, objetoEntregaInsumoJornada.EstatusEntregaInsumo),
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, objetoEntregaInsumoJornada.AlmacenID)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_EntregaInsumo_Insertar]", dbParams));
            }
            catch (Exception)
            {

               throw;
            }
        }
        public static DataSet ObtenerJornadas(string statusJornada)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EstatusEntregaInsumo", SqlDbType.VarChar, 0, statusJornada)
                };
            return DBHelper.ExecuteDataSet("usp_EntregaInsumo_ObtenerEntregaInsumoJornadas", dbParams);
        }

        public static SqlDataReader ObtenerCodigoAlmacenPorJornada(int entregaInsumoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoID", SqlDbType.Int, 0, entregaInsumoID)
                };
            return DBHelper.ExecuteDataReader("usp_EntregaInsumo_CodigoAlmacenPorJornada", dbParams);
        }

        public static SqlDataReader ObtenerTotalItemAlmacenEntregaInsumoJornada(int almacenID, int tipoInsumoDetalleID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, tipoInsumoDetalleID),
                    DBHelper.MakeParam("@AlmacenID", SqlDbType.Int, 0, almacenID)
                };
            return DBHelper.ExecuteDataReader("usp_EntregaInsumo_ObtenerTotalItemAlmacenEntregaInsumo", dbParams);
        }
        public static int EliminarVehiculoAsignadoJornada(int entregaInsumoDetalleID)
        {
            int resultado = 0;
            SqlDataReader dr = ObtenerInventarioAsignacion(entregaInsumoDetalleID);
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand command = null;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string updateQuery = "INSERT INTO InventarioAsignacion (TipoInsumoDetalleID, AlmacenID, CantidadIngresoAsignacion, UnidadMedidaID,SeguridadUsuarioDatosID) VALUES (" + dr["TipoInsumoDetalleID"] + "," + dr["AlmacenID"] + "," + dr["CantidadEntregaInsumo"] + "," + dr["UnidadMedidaID"] + "," + dr["SeguridadUsuarioDatosID"] + ")";
                    cn.Open();
                    command = new SqlCommand(updateQuery, cn);
                    var commandResult = command.ExecuteScalar();
                    command.Dispose();
                    cn.Close();
                    cn.Dispose();
                }
            }
            command.Dispose();
            cn.Close();
            cn.Dispose();

            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoDetalleID", SqlDbType.Int, 0, entregaInsumoDetalleID)
                };
            resultado = Convert.ToInt32(DBHelper.ExecuteScalar("usp_EntregaInsumo_EliminarUndadAsignadaEntrega", dbParams));

            return resultado;
        }
        private static SqlDataReader ObtenerInventarioAsignacion(int entregaInsumoDetalleID)
        {
            string consultaSQL = "SELECT dbo.EntregaInsumoDetalle.EntregaInsumoDetalleID, dbo.EntregaInsumo.AlmacenID, dbo.EntregaInsumoDetalle.TipoInsumoDetalleID, dbo.EntregaInsumoDetalle.UnidadMedidaID,  dbo.EntregaInsumoDetalle.CantidadEntregaInsumo, dbo.EntregaInsumoDetalle.SeguridadUsuarioDatosID FROM  dbo.EntregaInsumo INNER JOIN  dbo.EntregaInsumoDetalle ON dbo.EntregaInsumo.EntregaInsumoID = dbo.EntregaInsumoDetalle.EntregaInsumoID WHERE dbo.EntregaInsumoDetalle.EntregaInsumoDetalleID = " + entregaInsumoDetalleID;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("connectionString"));
            cn.Open();
            SqlCommand command = new SqlCommand(consultaSQL, cn);
            return command.ExecuteReader();
        }
        public static int CerrarJornadaEntregaInsumo(int entregaInsumoID, int usuarioID)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EntregaInsumoID", SqlDbType.Int, 0, entregaInsumoID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosCierreID", SqlDbType.Int, 0, usuarioID)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_EntregaInsumo_CerrarJornada]", dbParams));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}