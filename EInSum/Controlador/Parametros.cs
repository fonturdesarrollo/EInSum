using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class Parametros
    {
        public static string ObtenerValorParametro(string nombreParametro)
        {
            string valorParametro = "";
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@NombreParametro", SqlDbType.VarChar, 0, nombreParametro)
                };

            SqlDataReader dr = DBHelper.ExecuteDataReader("usp_Pararametros_ObtenerValorParametro", dbParams);
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    valorParametro = dr.GetString(2);
                }
            }
            dr.Close();
            return valorParametro;
        }
    }
}