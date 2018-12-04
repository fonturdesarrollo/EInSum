using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class ModeloVehiculo
    {
        public static int InsertarModeloVehiculo(CMarcaModeloVehiculo objetoMMVechiculo)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@ModeloVehiculoID", SqlDbType.Int, 0, objetoMMVechiculo.ModeloVehiculoID),
                    DBHelper.MakeParam("@MarcaVehiculoID", SqlDbType.Int, 0, objetoMMVechiculo.MarcaVehiculoID),
                    DBHelper.MakeParam("@NombreModeloVehiculo", SqlDbType.VarChar, 0, objetoMMVechiculo.NombreModeloVehiculo),
                    DBHelper.MakeParam("@TipoVehiculoID", SqlDbType.Int, 0, objetoMMVechiculo.TipoVehiculoID),
                    DBHelper.MakeParam("@TipoCauchoID", SqlDbType.Int, 0, objetoMMVechiculo.TipoCauchoID),
                    DBHelper.MakeParam("@CantidadCauchos", SqlDbType.Int, 0, objetoMMVechiculo.CantidadCauchos),
                    DBHelper.MakeParam("@TipoAceiteID", SqlDbType.Int, 0, objetoMMVechiculo.TipoAceiteID),
                    DBHelper.MakeParam("@CantidadLitros", SqlDbType.Int, 0, objetoMMVechiculo.CantidadLitros),
                    DBHelper.MakeParam("@TipoBateriaID", SqlDbType.Int, 0, objetoMMVechiculo.TipoBateriaID),
                    DBHelper.MakeParam("@Capacidad", SqlDbType.Int, 0, objetoMMVechiculo.Capacidad)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_ModeloVehiculo_Insertar]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataSet ObtenerModelos(int marcaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@MarcaVehiculoID", SqlDbType.Int, 0, marcaID)
                };
            return DBHelper.ExecuteDataSet("usp_MarcaVehiculo_ObtenerMarcasModelosVehiculo", dbParams);
        }
    }
}