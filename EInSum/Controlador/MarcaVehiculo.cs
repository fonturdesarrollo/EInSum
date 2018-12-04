using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class MarcaVehiculo
    {
        public static int InsertarMarcaVehiculo(CMarcaModeloVehiculo objetoMMVechiculo)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@MarcaVehiculoID", SqlDbType.Int, 0, objetoMMVechiculo.MarcaVehiculoID),
                    DBHelper.MakeParam("@NombreMarcaVehiculo", SqlDbType.VarChar, 0, objetoMMVechiculo.NombreMarcaVehiculo)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_MarcaVehiculo_Insertar]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int EliminarMarcaVehiculo(int marcaVehiculoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@MarcaVehiculoID", SqlDbType.Int, 0, marcaVehiculoID)
                };
            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_MarcaVehiculo_EliminarMarcaVehiculo", dbParams));
        }
        public static DataSet ObtenerMarcas()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
   
                };
            return DBHelper.ExecuteDataSet("usp_MarcaVehiculo_ObtenerMarcasVehiculo", dbParams);
        }
    }
}