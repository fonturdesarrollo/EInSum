using Database.Classes;
using Seguridad.Clases;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Seguridad
{
    public partial class SeguridadCambiarClave
    {
        public static int CambiarClave(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoSeguridad.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@ClaveUsuario", SqlDbType.VarChar, 0, objetoSeguridad.ClaveUsuario)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_SeguridadUsuario_ActualizarClave", dbParams));
  
        }
    }
}