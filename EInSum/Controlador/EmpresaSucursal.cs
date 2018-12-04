using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class EmpresaSucursal
    {
        public static int InsertarEmpresaSucursal(CEmpresaSucursal objetoEmpresa)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, objetoEmpresa.EmpresaSucursalID),
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.VarChar, 0, objetoEmpresa.EmpresaID),
                    DBHelper.MakeParam("@NombreSucursal", SqlDbType.VarChar, 0, objetoEmpresa.NombreSucursal),
                    DBHelper.MakeParam("@DireccionSucursal", SqlDbType.VarChar, 0, objetoEmpresa.DireccionSucursal),
                    DBHelper.MakeParam("@TelefonoSucursal", SqlDbType.VarChar, 0, objetoEmpresa.TelefonoSucursal)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_EmpresaSucursal_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        public static DataSet ObtenerSucursal(int codigoEmpresa)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.Int, 0, codigoEmpresa),
                };

            return DBHelper.ExecuteDataSet("usp_EmpresaSucursal_ObtenerSucursal", dbParams);
        }
    }
}