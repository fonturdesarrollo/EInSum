using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class Empresa
    {
        public static int InsertarEmpresa(CEmpresa objetoEmpresa)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.Int, 0, objetoEmpresa.EmpresaID),
                    DBHelper.MakeParam("@RIFEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.RIFEmpresa),
                    DBHelper.MakeParam("@NombreEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.NombreEmpresa),
                    DBHelper.MakeParam("@DireccionEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.DireccionEmpresa),
                    DBHelper.MakeParam("@TelefonoEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.TelefonoEmpresa),
                    DBHelper.MakeParam("@EMailEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.EMailEmpresa),
                    DBHelper.MakeParam("@WebEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.WebEmpresa),
                    DBHelper.MakeParam("@TwitterEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.TwitterEmpresa),
                    DBHelper.MakeParam("@InstagramEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.InstagramEmpresa),
                    DBHelper.MakeParam("@FacebookEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.FacebookEmpresa),
                    DBHelper.MakeParam("@LogoEmpresa", SqlDbType.VarChar, 0, objetoEmpresa.LogoEmpresa),
                    DBHelper.MakeParam("@EstatusEmpresaID", SqlDbType.Int, 0, objetoEmpresa.EstatusEmpresaID)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Empresa_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        public static DataSet ObtenerEmpresas(int empresaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.Int, 0, empresaID)
                };

           return DBHelper.ExecuteDataSet("usp_Empresa_ObtenerEmpresa", dbParams);

        }
        public static int EliminarEmpresa(int empresaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.Int, 0, empresaID),
                };
            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Empresa_EliminarEmpresa", dbParams));
        }
    }
}